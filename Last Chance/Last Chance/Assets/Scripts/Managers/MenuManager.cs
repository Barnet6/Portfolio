using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static SaveFile file;
    public GameObject newGame, resume;
    public Slots slots;
    private int members, money, time, percent;
    private string crew;

    public void Start()
    {

    }
    /***************************************************************/

    public void Resume()
    {
        file = new SaveFile("");
        file.Load(PlayerPrefs.GetInt("last"));
        SceneManager.LoadScene((int)Enums.Scenes.Base);
    }

    public void NewGame()
    {
        SceneManager.LoadScene((int)Enums.Scenes.NewGame);
    }

    public void SaveGame()
    {
        SceneManager.LoadScene((int)Enums.Scenes.SaveGame);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene((int)Enums.Scenes.LoadGame);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Base()
    {
        SceneManager.LoadScene((int)Enums.Scenes.Base);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene((int)Enums.Scenes.MainMenu);
        Debug.Log("GAMEMANAGER:: Returned to main menu");
    }

    /***************************************************************/

    public void Create()
    {
        string name = newGame.transform.Find("NameField/Text").GetComponent<Text>().text;
        if (name == "")
            name = newGame.transform.Find("NameField/Placeholder").GetComponent<Text>().text;
        string crew = newGame.transform.Find("CrewField/Text").GetComponent<Text>().text;
        if (crew == "")
            crew = newGame.transform.Find("CrewField/Placeholder").GetComponent<Text>().text;
        string type = newGame.transform.Find("ClassField/Label").GetComponent<Text>().text;

        file = new SaveFile(crew);
        int typeInt;
        switch (type)
        {
            case "Soldier":
                typeInt = (int)Enums.Class.Soldier;
                break;
            case "Black Mage":
                typeInt = (int)Enums.Class.BlackMage;
                break;
            case "White Mage":
                typeInt = (int)Enums.Class.WhiteMage;
                break;
            default:
                typeInt = (int)Enums.Class.Soldier;
                break;
        }

        file.Recruit(new Character(name, typeInt));
        
        SceneManager.LoadScene((int)Enums.Scenes.Base);
        Debug.Log("GAMEMANAGER:: Created character: " + name + ", " + type);
    }

    /***************************************************************/


    public void LoadSlot1()
    {
        Debug.Log("Slot1");
        file = new SaveFile(slots.slot1.transform.Find("Name").GetComponent<Text>().text);
        file.Load(1);
    }
    public void LoadSlot2()
    {
        Debug.Log("Slot2");
        file = new SaveFile(slots.slot2.transform.Find("Name").GetComponent<Text>().text);
        file.Load(2);
    }
    public void LoadSlot3()
    {
        Debug.Log("Slot3");
        file = new SaveFile(slots.slot3.transform.Find("Name").GetComponent<Text>().text);
        file.Load(3);
    }
    
    public void SaveSlot1()
    {
        Debug.Log("Slot1");
        file.Save(1);
    }

    public void SaveSlot2()
    {
        Debug.Log("Slot2");
        file.Save(2);
    }

    public void SaveSlot3()
    {
        Debug.Log("Slot3");
        file.Save(3);
    }
}
