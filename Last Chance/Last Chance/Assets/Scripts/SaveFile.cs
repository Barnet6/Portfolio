using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveFile {

    const int MAX_MEMBERS = 30;

    private Character[] List;
    private string crew;
    private int members, money, time, percent;

    public SaveFile(string name)
    {
        List = new Character[MAX_MEMBERS];
        crew = name;
        members = 0;
        money = 0;
        percent = 0;
    }

    public Character[] GetList()
    {
        return List;
    }
    public void Recruit(Character unit)
    {
        Debug.Log("SAVEFILE:: Members: " + members);
        Debug.Log("SAVEFILE:: Max Members: " + MAX_MEMBERS);
        if (members < MAX_MEMBERS)
            List[members++] = unit;
        else
            Debug.Log("SAVEFILE:: Can't recruit any more units");
    }

    public void Load(int slot)
    {
        PlayerPrefs.SetInt("last", slot);
        StreamReader reader = new StreamReader("saves\\slot" + slot + ".txt");

        crew = reader.ReadLine();
        int.TryParse(reader.ReadLine(), out members);
        int.TryParse(reader.ReadLine(), out money);
        int.TryParse(reader.ReadLine(), out time);
        int.TryParse(reader.ReadLine(), out percent);

        string name;
        int type, level, exp;
        for (int i = 0; i < members; i++)
        {
            name = reader.ReadLine();
            int.TryParse(reader.ReadLine(), out type);
            int.TryParse(reader.ReadLine(), out level);
            int.TryParse(reader.ReadLine(), out exp);
            Character unit = new Character(name, type);
            Recruit(unit);
        }
        reader.Close();

        SceneManager.LoadScene((int)Enums.Scenes.Base);
    }
    public void Save(int slot)
    {
        PlayerPrefs.SetInt("last", slot);
        if (!File.Exists("saves\\slot" + slot.ToString()))
        {
            File.Create("saves\\slot" + slot.ToString());
        }
        StreamWriter writer = new StreamWriter("saves\\slot" + slot.ToString() + ".txt");
        writer.WriteLine(crew);
        writer.WriteLine(members);
        writer.WriteLine(money);
        writer.WriteLine(time);
        writer.WriteLine(percent);

        for (int i = 0; i < members; i++)
        {
            writer.WriteLine(List[i].GetName());
            writer.WriteLine(List[i].GetLevel().ToString());
            writer.WriteLine(List[i].GetExp().ToString());
            writer.WriteLine(List[i].GetClass().ToString());
        }
        writer.Close();
        SceneManager.LoadScene((int)Enums.Scenes.Base);
    }

    public string GetName()
    {
        return crew;
    }
    public string GetCrew()
    {
        return crew;
    }
    public int GetMembers()
    {
        return members;
    }
    public int GetTime()
    {
        return time;
    }
    public int GetMoney()
    {
        return money;
    }
    public void SetMoney(int amount)
    {
        money = amount;
    }
    public int GetPercent()
    {
        return percent;
    }
    public void SetPercent(int completed)
    {
        percent = completed;
    }
}
