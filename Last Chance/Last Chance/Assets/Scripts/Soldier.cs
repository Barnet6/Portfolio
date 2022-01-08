public class Soldier : Class {

    public Soldier()
    {
        attributes = new double[(int)Enums.Attr.All];
        attributes[(int)Enums.Attr.Str] = 10;
        attributes[(int)Enums.Attr.End] = 10;
        attributes[(int)Enums.Attr.Agi] = 8;
        attributes[(int)Enums.Attr.Int] = 6;
        attributes[(int)Enums.Attr.Spi] = 6;
        attributes[(int)Enums.Attr.Cha] = 9;
        attributes[(int)Enums.Attr.Lck] = 8;
        Refresh((int)Enums.Class.Soldier);
    }

    public override void LevelUp()
    {
        attributes[(int)Enums.Attr.Str] *= 1.4;
        attributes[(int)Enums.Attr.End] *= 1.3;
        attributes[(int)Enums.Attr.Agi] *= 1.1;
        attributes[(int)Enums.Attr.Int] *= 1.1;
        attributes[(int)Enums.Attr.Spi] *= 1.1;
        attributes[(int)Enums.Attr.Cha] *= 1.1;
        attributes[(int)Enums.Attr.Lck] *= 1.1;
        Refresh((int)Enums.Class.Soldier);
    }
}
