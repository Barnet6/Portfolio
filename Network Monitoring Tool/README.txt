Network Monitoring Tool


Overview
This tool is designed to monitor network traffic and device activities in real-time, providing valuable insights into network performance and security.


Installation
1. Clone or download the repository from GitHub Repository Link.
2. Ensure that Python 3.x is installed on your system.
3. Install the required dependencies using the following command:
	pip install -r requirements.txt
4. Run the tool using the command:
	python network_monitor.py


Usage
Upon running the tool, you will be prompted to choose the network interface to monitor.
Enter the number corresponding to your desired interface.
Choose the type of scan or monitoring you want to perform:
-devices: Scan for connected devices on the network.
-ports: Scan for open ports on the network.
-snapshot: Take a snapshot of network traffic.
-live: Perform live monitoring of network speed and usage.
-none: Exit the program.

Follow the on-screen instructions to proceed with the chosen scan or monitoring type.
Press q at any time to stop monitoring and exit the program.


Features
-Discover connected devices on the network.
-Scan for open ports and services.
-Capture and analyze network traffic. (WiP)
-Real-time monitoring of network speed and usage. (WiP)
-Generate reports and statistics for network analysis. (WiP)


License
This project is licensed under the [License Name]. See the LICENSE file for details.

