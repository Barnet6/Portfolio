using System;

public class Character
{

    private string name;
    private Class unit;
    private int type, level, exp, health, energy;

    // Use this for initialization
    public Character(string nm = "Ethan", int tp = (int)Enums.Class.Soldier)
    {
        name = nm;
        type = tp;
        switch (type)
        {
            case (int)Enums.Class.Soldier:
                unit = new Soldier();
                break;
            case (int)Enums.Class.BlackMage:
                unit = new BlackMage();
                break;
            case (int)Enums.Class.WhiteMage:
                unit = new WhiteMage();
                break;
        }
        health = unit.GetHealth();
        energy = unit.GetEnergy();
        exp = 0;
    }

    public void Refresh()
    {
        health = unit.GetHealth();
        energy = unit.GetEnergy();
    }


    public void LevelUp()
    {
        level++;
        unit.LevelUp();
        Refresh();
    }
    public void GainXP(int xp)
    {
        exp += xp;
        int nextLevel = (int)(100 * (Math.Pow(2, level)));
        while (exp > nextLevel)
        {
            LevelUp();
        }
    }

    public string GetName()
    {
        return name;
    }
    public int GetLevel()
    {
        return level;
    }
    public int GetHealth()
    {
        return health;
    }
    public int GetEnergy()
    {
        return energy;
    }
    public int GetExp()
    {
        return exp;
    }

    public Class GetClass()
    {
        return unit;
    }
    public new string GetType()
    {
        switch (type)
        {
            case (int)Enums.Class.Soldier:
                return "Soldier";
            case (int)Enums.Class.BlackMage:
                return "Black Mage";
            case (int)Enums.Class.WhiteMage:
                return "White Mage";
            default:
                return "Unknown";
        }
    }

    public void Damage(int damage)
    {
        health -= damage;
    }
    public void Heal(int heal)
    {
        health += heal;
        if (health > unit.GetHealth())
            health = unit.GetHealth();
    }
    public void UseEnergy(int use)
    {
        energy -= use;
    }
    public void GainEnergy(int gain)
    {
        energy += gain;
        if (energy > unit.GetEnergy())
            energy = unit.GetEnergy();
    }
}
