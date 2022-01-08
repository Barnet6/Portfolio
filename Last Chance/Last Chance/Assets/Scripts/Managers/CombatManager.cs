using UnityEngine;

public class CombatManager : MonoBehaviour {

    public GameManager GM;
    private Character selectedChar, targetChar;
    private int damage, retDamage;

    public int Attack(int AttID, Unit selected, Unit target)
    {
        /* if neither unit died, return 0
         * if enemy died, return 1
         * if ally died, return 2
         * if both died, return 3
         */
        damage = retDamage = 0;

        selectedChar = selected.GetChar();
        targetChar = target.GetChar();
        
        if (SkillList.list[AttID].GetMod() == (int)Enums.Attr.Str || SkillList.list[AttID].GetMod() == (int)Enums.Attr.Agi)
        {
            damage = (int)((double)SkillList.list[AttID].GetDamage() * ((double)selectedChar.GetClass().GetPhysAtt() / (double)targetChar.GetClass().GetPhysDef()));
            retDamage = (int)((double)SkillList.list[AttID].GetDamage() * ((double)targetChar.GetClass().GetPhysAtt() / (double)selectedChar.GetClass().GetPhysDef()));
        }
        else
        {
            damage = (int)((double)SkillList.list[AttID].GetDamage() * ((double)selectedChar.GetClass().GetMagAtt() / (double)targetChar.GetClass().GetMagDef()));
            retDamage = 0;
        }

        int exp = (int)((double)damage * ((double)targetChar.GetLevel() / (double)selectedChar.GetLevel()));

        target.Damage(damage);
        if (!target.IsDead())
        {
            selected.Damage(retDamage);

            if (!selected.IsDead())
                selected.GainXP(exp);
        }

        if (target.IsDead())
            if (selected.IsDead())
                return 3;
            else
                return 1;
        else if (selected.IsDead())
            return 2;
        return 0;
    }
}
