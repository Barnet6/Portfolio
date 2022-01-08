public class Skill {

    private string name;
    private int element, damage, modifier, range, cost;

    public Skill(string nm, int ele, int dmg, int mod, int rng, int cst)
    {
        name = nm;
        element = ele;
        damage = dmg;
        modifier = mod;
        range = rng;
        cost = cst;
    }

    public string GetName()
    {
        return name;
    }
    public int GetElement()
    {
        return element;
    }
    public int GetDamage()
    {
        return damage;
    }
    public int GetMod()
    {
        return modifier;
    }
    public int GetRange()
    {
        return range;
    }
    public int GetCost()
    {
        return cost;
    }
}
