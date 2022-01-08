public class BlackMage : Class {

    public BlackMage()
    {
        attributes = new double[(int)Enums.Attr.All];
        attributes[(int)Enums.Attr.Str] = 6;
        attributes[(int)Enums.Attr.End] = 6;
        attributes[(int)Enums.Attr.Agi] = 9;
        attributes[(int)Enums.Attr.Int] = 10;
        attributes[(int)Enums.Attr.Spi] = 8;
        attributes[(int)Enums.Attr.Cha] = 7;
        attributes[(int)Enums.Attr.Lck] = 8;
        Refresh((int)Enums.Class.BlackMage);
    }

    public override void LevelUp()
    {
        attributes[(int)Enums.Attr.Str] *= 1.1;
        attributes[(int)Enums.Attr.End] *= 1.1;
        attributes[(int)Enums.Attr.Agi] *= 1.2;
        attributes[(int)Enums.Attr.Int] *= 1.4;
        attributes[(int)Enums.Attr.Spi] *= 1.1;
        attributes[(int)Enums.Attr.Cha] *= 1.2;
        attributes[(int)Enums.Attr.Lck] *= 1.1;
        Refresh((int)Enums.Class.BlackMage);
    }
}
