public abstract class Class
{
    private int health, energy;
    protected double[] attributes;
    private int physAtt, physDef, magAtt, magDef;
    private int acc, dodge, move;
    //private Skill[] skills;
    protected Class() { }
    public virtual void LevelUp() { }

    public void Refresh(int type)
    {
        health = (int)(attributes[(int)Enums.Attr.End] * 2.5);
        switch (type)
        {
            case (int)Enums.Class.Soldier:
                energy = (int)(attributes[(int)Enums.Attr.End]);
                break;
            case (int)Enums.Class.BlackMage:
                energy = (int)(attributes[(int)Enums.Attr.Int]);
                break;
            case (int)Enums.Class.WhiteMage:
                energy = (int)(attributes[(int)Enums.Attr.Spi]);
                break;
        }
        physAtt = (int)(attributes[(int)Enums.Attr.Str] * 3);
        physDef = (int)(attributes[(int)Enums.Attr.Str] * 2 + attributes[(int)Enums.Attr.End] * 2);
        magAtt = (int)(attributes[(int)Enums.Attr.Int] * 3);
        magDef = (int)(attributes[(int)Enums.Attr.Spi] * 3);
        acc = 50 + (int)(attributes[(int)Enums.Attr.Agi] / 2);
        dodge = 25 + (int)(attributes[(int)Enums.Attr.Agi] * 3 / 2);
        move = (int)(attributes[(int)Enums.Attr.Agi] / 10);
    }

    public int GetHealth()
    {
        return health;
    }
    public int GetEnergy()
    {
        return energy;
    }
    public int GetPhysAtt()
    {
        return physAtt;
    }
    public int GetPhysDef()
    {
        return physDef;
    }
    public int GetMagAtt()
    {
        return magAtt;
    }
    public int GetMagDef()
    {
        return magDef;
    }
    public int GetAcc()
    {
        return acc;
    }
    public int GetDodge()
    {
        return dodge;
    }
    public int GetMove()
    {
        return move;
    }
}
