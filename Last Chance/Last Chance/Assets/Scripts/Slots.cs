using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Slots : MonoBehaviour {

    public MenuManager MM;
    public Button slot1, slot2, slot3;
    
	// Use this for initialization
	void Start ()
    {
        StreamReader reader;
        string crew;

        if (slot1 && File.Exists(@"saves\slot1.txt"))
        {
            reader = new StreamReader("saves/slot1.txt");
            crew = reader.ReadLine();
            int members, money, time, percent;
            int.TryParse(reader.ReadLine(), out members);
            int.TryParse(reader.ReadLine(), out money);
            int.TryParse(reader.ReadLine(), out time);
            int.TryParse(reader.ReadLine(), out percent);
            slot1.transform.Find("Crew").GetComponent<Text>().text = crew;
            slot1.transform.Find("Members").GetComponent<Text>().text = members.ToString();
            slot1.transform.Find("Money").GetComponent<Text>().text = "$ " + money.ToString();
            slot1.transform.Find("Playtime").GetComponent<Text>().text = ((time / 3600).ToString() + ":" + 
                        ((time % 3600) / 60).ToString() + ":" + (time % 60).ToString());
            slot1.transform.Find("Percent").GetComponent<Text>().text = percent.ToString() + " %";

            string name, typeName;
            int level, type;
            name = reader.ReadLine();
            int.TryParse(reader.ReadLine(), out level);
            int.TryParse(reader.ReadLine(), out type);
            switch (type)
            {
                case (int)Enums.Class.Soldier:
                    typeName = "Soldier";
                    break;
                case (int)Enums.Class.BlackMage:
                    typeName = "Black Mage";
                    break;
                case (int)Enums.Class.WhiteMage:
                    typeName = "White Mage";
                    break;
                default:
                    typeName = "Soldier";
                    break;
            }
            slot1.transform.Find("Name").GetComponent<Text>().text = name;
            slot1.transform.Find("Level").GetComponent<Text>().text = "Lv " + level.ToString();
            slot1.transform.Find("Class").GetComponent<Text>().text = typeName;

            reader.Close();
        }

        if (slot2 && File.Exists(@"saves\slot2.txt"))
        {
            reader = new StreamReader("saves/slot2.txt");
            crew = reader.ReadLine();
            int members, money, time, percent;
            int.TryParse(reader.ReadLine(), out members);
            int.TryParse(reader.ReadLine(), out money);
            int.TryParse(reader.ReadLine(), out time);
            int.TryParse(reader.ReadLine(), out percent);
            slot2.transform.Find("Crew").GetComponent<Text>().text = crew;
            slot2.transform.Find("Members").GetComponent<Text>().text = members.ToString();
            slot2.transform.Find("Money").GetComponent<Text>().text = "$ " + money.ToString();
            slot2.transform.Find("Playtime").GetComponent<Text>().text = ((time / 3600).ToString() + ":" +
                        ((time % 3600) / 60).ToString() + ":" + (time % 60).ToString());
            slot2.transform.Find("Percent").GetComponent<Text>().text = percent.ToString() + " %";

            string name, typeName;
            int level, type;
            name = reader.ReadLine();
            int.TryParse(reader.ReadLine(), out level);
            int.TryParse(reader.ReadLine(), out type);
            switch(type)
            {
                case (int)Enums.Class.Soldier:
                    typeName = "Soldier";
                    break;
                case (int)Enums.Class.BlackMage:
                    typeName = "Black Mage";
                    break;
                case (int)Enums.Class.WhiteMage:
                    typeName = "White Mage";
                    break;
                default:
                    typeName = "Soldier";
                    break;
            }
            slot2.transform.Find("Name").GetComponent<Text>().text = name;
            slot2.transform.Find("Level").GetComponent<Text>().text = "Lv " + level.ToString();
            slot2.transform.Find("Class").GetComponent<Text>().text = typeName;

            reader.Close();
        }

        if (slot3 && File.Exists(@"saves\slot3.txt"))
        {
            reader = new StreamReader("saves/slot3.txt");
            crew = reader.ReadLine();
            int members, money, time, percent;
            int.TryParse(reader.ReadLine(), out members);
            int.TryParse(reader.ReadLine(), out money);
            int.TryParse(reader.ReadLine(), out time);
            int.TryParse(reader.ReadLine(), out percent);
            slot3.transform.Find("Crew").GetComponent<Text>().text = crew;
            slot3.transform.Find("Members").GetComponent<Text>().text = members.ToString();
            slot3.transform.Find("Money").GetComponent<Text>().text = "$ " + money.ToString();
            slot3.transform.Find("Playtime").GetComponent<Text>().text = ((time / 3600).ToString() + ":" +
                        ((time % 3600) / 60).ToString() + ":" + (time % 60).ToString());
            slot3.transform.Find("Percent").GetComponent<Text>().text = percent.ToString() + " %";

            string name, typeName;
            int level, type;
            name = reader.ReadLine();
            int.TryParse(reader.ReadLine(), out level);
            int.TryParse(reader.ReadLine(), out type);
            switch (type)
            {
                case (int)Enums.Class.Soldier:
                    typeName = "Soldier";
                    break;
                case (int)Enums.Class.BlackMage:
                    typeName = "Black Mage";
                    break;
                case (int)Enums.Class.WhiteMage:
                    typeName = "White Mage";
                    break;
                default:
                    typeName = "Soldier";
                    break;
            }
            slot3.transform.Find("Name").GetComponent<Text>().text = name;
            slot3.transform.Find("Level").GetComponent<Text>().text = "Lv " + level.ToString();
            slot3.transform.Find("Class").GetComponent<Text>().text = typeName;

            reader.Close();
        }
    }
}
