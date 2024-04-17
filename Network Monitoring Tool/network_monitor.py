import socket
import threading
from scapy.all import ARP, Ether, srp
import click
import psutil
import time
import json
import os
import winsound
import msvcrt
from scapy.all import sniff, ARP, IP
import requests
import signal
import subprocess
import sys

# Global variables
chosen_interface = None
network_name = None
stop_monitoring = False
devices_file = None

connected_devices = []
traffic = {}

def list_interfaces():
    interfaces = psutil.net_if_addrs()
    print("Available network interfaces:")
    for i, (interface, addresses) in enumerate(interfaces.items(), start=1):
        ip_address = next((addr.address for addr in addresses if addr.family == socket.AF_INET), "No IP address")
        print(f"{i}. {interface} - IP: {ip_address}")
    return list(interfaces.keys())

def choose_interface():
    global chosen_interface
    interfaces = list_interfaces()
    choice = input("Enter the number of the interface to use: ")
    while not choice.isdigit() or int(choice) < 1 or int(choice) > len(interfaces):
        print("Invalid choice. Please enter a valid number.")
        choice = input("Enter the number of the interface to use: ")
    chosen_interface = interfaces[int(choice) - 1]
    return chosen_interface

def get_local_ip(interface_name):
    interfaces = psutil.net_if_addrs()
    if interface_name in interfaces:
        ip_address = interfaces[interface_name][1].address
        return ip_address
    else:
        print(f"Error: Interface '{interface_name}' not found.")
        return "Unknown"

def discover_devices(local_ip):
    global connected_devices
    print("Discovering devices on the network...")
    arp = ARP(pdst=f"{local_ip}/24")
    ether = Ether(dst="ff:ff:ff:ff:ff:ff")
    packet = ether / arp
    result = srp(packet, timeout=5, verbose=False)[0]

    all_devices = load_devices()  # Load all known devices
    current_devices = []  # List to store currently connected devices

    current_time = time.time()
    for sent, received in result:
        device = {'ip': received.psrc, 'mac': received.hwsrc, 'last_seen': current_time}
        existing_device = next((d for d in all_devices if d['mac'] == device['mac']), None)
        if existing_device:
            existing_device['last_seen'] = current_time
        else:
            all_devices.append(device)
            print(f"New device found: IP: {device['ip']}, MAC: {device['mac']}")
            send_alert(device)
        current_devices.append(device)

    connected_devices = sorted(current_devices, key=lambda d: d['ip'])
    save_devices(sorted(all_devices, key=lambda d: d['ip']))  # Save all known devices

def get_connected_wifi_name():
    result = subprocess.run(["netsh", "wlan", "show", "interfaces"], capture_output=True, text=True)
    output_lines = result.stdout.splitlines()
    for line in output_lines:
        if "SSID" in line:
            return line.split(":")[1].strip()
            
def forget(network_name):
    if os.path.exists(devices_file):
        os.remove(devices_file)
        print(f"All known devices for network '{network_name}' have been forgotten.")
    else:
        print(f"No devices file found for network '{network_name}'.")

def save_devices(devices):
    with open(devices_file, 'w') as f:
        for device in devices:
            f.write(f"{json.dumps(device)}\n")

def load_devices():
    devices = []
    if os.path.exists(devices_file):
        with open(devices_file, 'r') as f:
            lines = f.readlines()
            for line in lines:
                device = json.loads(line.strip())
                devices.append(device)
    return devices

def list_devices(devices):
    print("Devices found on the network:")
    for device in devices:
        ip = device['ip']
        mac = device['mac']
        last_seen = time.ctime(device['last_seen'])
        print(f"IP: {ip:<15} | MAC: {mac:<17} | Last Seen: {last_seen}")

def send_alert(device):
    print("Alert: New device found!")
    print(f"IP: {device['ip']}, MAC: {device['mac']}, Last Seen: {time.ctime(device['last_seen'])}")
    winsound.PlaySound("SystemExclamation", winsound.SND_ALIAS)

def packet_handler(pkt, device_ip):
    global traffic
    if pkt.haslayer(IP) and (pkt[IP].src == device_ip or pkt[IP].dst == device_ip):
        if device_ip in traffic:
            traffic[device_ip]['sent'] += len(pkt) if pkt[IP].src == device_ip else 0
            traffic[device_ip]['received'] += len(pkt) if pkt[IP].dst == device_ip else 0
        else:
            traffic[device_ip] = {'sent': 1 if pkt[IP].src == device_ip else 0, 'received': 1 if pkt[IP].dst == device_ip else 0}

def monitor_device_traffic(device_ip):
    global chosen_interface
    sniff(prn=lambda pkt: packet_handler(pkt, device_ip), filter=f"host {device_ip}", iface=chosen_interface, timeout=30)

def monitor_devices():
    global connected_devices, stop_monitoring
    threads = []

    while not stop_monitoring:
        for device in connected_devices:
            thread = threading.Thread(target=monitor_device_traffic, args=[device['ip']])
            threads.append(thread)
            thread.start()
        time.sleep(45)

    for thread in threads:
        thread.join()

def print_traffic():    
    global stop_monitoring, connected_devices
    
    while not stop_monitoring:
        time.sleep(30)
        for device in connected_devices:
            ip = device['ip']
            if ip in traffic:
                sent_count = traffic[ip]['sent']
                received_count = traffic[ip]['received']
                print(f"{ip} - Sent: {sent_count}, Received: {received_count}")

def live(local_ip):
    global stop_monitoring, connected_devices
    print("Live monitoring of network usage...")

    monitor = threading.Thread(target=monitor_devices)
    monitor.start()  # Start the thread that monitors the devices
    
    traffic = threading.Thread(target=print_traffic)
    traffic.start()    # Start the thread that prints the devices' traffic usages
    while not stop_monitoring:
        discover_devices(local_ip)
        time.sleep(20)  # Adjust the interval for device scanning
    
    monitor.join()
    traffic.join()

def wait_for_stop():
    global stop_monitoring
    print("Press 'q' to stop monitoring...")
    while True:
        if msvcrt.kbhit():
            key = msvcrt.getch()
            if key == 'q':
                stop_monitoring = True
                break

def signal_handler(sig, frame):
    global stop_monitoring
    print("Exiting the program...")
    stop_monitoring = True
    print("Waiting for threads to end (60 seconds)");
    time.sleep(10)
    print("Waiting for threads to end (50 seconds)");
    time.sleep(10)
    print("Waiting for threads to end (40 seconds)");
    time.sleep(10)
    print("Waiting for threads to end (30 seconds)");
    time.sleep(10)
    print("Waiting for threads to end (20 seconds)");
    time.sleep(10)
    print("Waiting for threads to end (10 seconds)");
    time.sleep(10)
    sys.exit(0)
    
# python network_monitor.py --scan live --network-name Jailhouse
@click.command()
@click.option('--scan', type=click.Choice(['devices', 'ports', 'snapshot', 'live', 'none']), prompt='Choose what to scan or monitor', help='Choose whether to scan for devices, open ports, or live monitoring of network speed')
@click.option('--network-name', type=str, help='Specify the network name')
@click.option('--forget-devices', is_flag=True, help='Forget all known devices for the specified network')
@click.option('--ip-address', type=str, help='Specify the network name')
def main(scan, network_name, forget_devices, ip_address):
    global chosen_interface, connected_devices, stop_monitoring

    if not network_name:
        network_name = get_connected_wifi_name()

    global devices_file
    devices_file = f"devices_{network_name}.txt"

    if not ip_address:
        chosen_interface = choose_interface()
        ip_address = get_local_ip(chosen_interface)

    if ip_address != "Unknown":
        print(f"Chosen interface: {chosen_interface}, IP address: {ip_address}")
        if forget_devices:
            forget(network_name)

        if scan == 'devices':
            discover_devices(ip_address)
            list_devices(connected_devices)
        elif scan == 'ports':
            scan_host(ip_address)
        elif scan == 'snapshot':
            wait = threading.Thread(target=wait_for_stop)
            wait.start()  # Start the thread for waiting to stop monitoring
            live(ip_address)
            sleep(60)
            stop_monitoring = True
            wait.join()
        elif scan == 'live':
            wait = threading.Thread(target=wait_for_stop)
            wait.start()  # Start the thread for waiting to stop monitoring
            live(ip_address)
            wait.join()
        elif scan == 'none':
            return
    else:
        print("Error: IP address not found for the chosen interface.")


if __name__ == "__main__":
    signal.signal(signal.SIGINT, signal_handler)
    main()
