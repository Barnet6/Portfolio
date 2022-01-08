using UnityEngine;

public class SkillList : MonoBehaviour {

    private const int skills = 100;
    private const int melee = 1;
    private const int ranged = 2;
    public static Skill[] list;

    // Use this for initialization
    void Start () {
        list = new Skill[skills];

        list[(int)Enums.ID.Attack] = new Skill("Attack", (int)Enums.Elements.Physical, 10, (int)Enums.Attr.Str, melee, 0);
        list[(int)Enums.ID.Cure] = new Skill("Cure", (int)Enums.Elements.Healing, -10, (int)Enums.Attr.Spi, ranged, 4);
        list[(int)Enums.ID.Fire] = new Skill("Fire", (int)Enums.Elements.Fire, 10, (int)Enums.Attr.Int, ranged, 4);
        list[(int)Enums.ID.Thunder] = new Skill("Thunder", (int)Enums.Elements.Lightning, 10, (int)Enums.Attr.Int, ranged, 4);
        list[(int)Enums.ID.Blizzard] = new Skill("Thunder", (int)Enums.Elements.Ice, 10, (int)Enums.Attr.Int, ranged, 4);
    }
}
