using System.IO;
using UnityEngine;

public class LoadGameSlots : MonoBehaviour {

    private Slots slots;

    public void Start()
    {
        slots = this.gameObject.GetComponent<Slots>();
        if (!File.Exists("saves\\slot1.txt"))
        {
            slots.slot1.interactable = false;
        }
        if (!File.Exists("saves\\slot2.txt"))
        {
            slots.slot2.interactable = false;
        }
        if (!File.Exists("saves\\slot3.txt"))
        {
            slots.slot3.interactable = false;
        }
    }
}
