public class WhiteMage : Class { 

    public WhiteMage()
    {
        attributes = new double[(int)Enums.Attr.All];
        attributes[(int)Enums.Attr.Str] = 6;
        attributes[(int)Enums.Attr.End] = 7;
        attributes[(int)Enums.Attr.Agi] = 10;
        attributes[(int)Enums.Attr.Int] = 8;
        attributes[(int)Enums.Attr.Spi] = 10;
        attributes[(int)Enums.Attr.Cha] = 8;
        attributes[(int)Enums.Attr.Lck] = 8;
        Refresh((int)Enums.Class.WhiteMage);
    }

    public override void LevelUp()
    {
        attributes[(int)Enums.Attr.Str] *= 1.1;
        attributes[(int)Enums.Attr.End] *= 1.1;
        attributes[(int)Enums.Attr.Agi] *= 1.3;
        attributes[(int)Enums.Attr.Int] *= 1.1;
        attributes[(int)Enums.Attr.Spi] *= 1.4;
        attributes[(int)Enums.Attr.Cha] *= 1.1;
        attributes[(int)Enums.Attr.Lck] *= 1.1;
        Refresh((int)Enums.Class.WhiteMage);
    }
}
