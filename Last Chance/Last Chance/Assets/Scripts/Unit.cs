using UnityEngine;
using UnityEngine.EventSystems;

public class Unit : MonoBehaviour, IPointerClickHandler
{
    public new string name;
    private bool moved, attacked, dead;
    private Character character;

    public GameManager GM;
    public UIManager UM;
    public ControlManager CM;
    public Tile tile;
    public int group, type;

    // Use this for initialization
    void Start()
    {
        moved = attacked = dead = false;
        character = new Character(name, type);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        UM.UpdateConsole(this);
        if (GM.GetSelected() == this)
            return;

        Debug.Log("UNIT:: Turn: " + GM.GetTurn());
        if (GM.GetTurn() == (int)Enums.Group.Ally)
        {
            if (GM.GetMove())
            {
                Debug.Log("UNIT:: Tile occupied");
            }

            else if (group == (int)Enums.Group.Ally)
            {
                if (!GM.GetMove() && GM.GetAtt() == -1)
                {
                    GM.Reset();
                    GM.SetSelected(this);
                    Debug.Log("UNIT:: Selected: true");
                    UM.Options(true, attacked, moved);
                }
            }
            else if (group == (int)Enums.Group.Enemy)
            {
                Debug.Log("UNIT:: Selected an enemy");
                if (GM.GetAtt() >= 0)
                    CM.Attack(GM.GetAtt(), GM.GetSelected(), this);
            }
            else
            {
                Debug.Log("UNIT:: Selected a monster");
                if (GM.GetAtt() >= 0)
                    CM.Attack(GM.GetAtt(), GM.GetSelected(), this);
            }
        }
    }
    
    public void GainXP(int xp)
    {
        character.GainXP(xp);
    }
    public Character GetChar()
    {
        return character;
    }
    public bool Moved()
    {
        return moved;
    }
    public void SetMoved(bool mvd)
    {
        moved = mvd;
    }
    public bool Attacked()
    {
        return attacked;
    }
    public void SetAttacked(bool att)
    {
        attacked = att;
    }
    public void Damage(int damage)
    {
        character.Damage(damage);
        if (character.GetHealth() <= 0)
            Die(true);
    }
    public void Die(bool die)
    {
        dead = die;
        tile.unit = null;
        tile = null;
        DestroyImmediate(this.gameObject);

        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            if (GameObject.FindGameObjectsWithTag("Monster").Length == 0)
                GM.Victory();
        if (GameObject.FindGameObjectsWithTag("Ally").Length == 0)
            GM.Defeat();
    }
    public bool IsDead()
    {
        return dead;
    }
    public void Reset()
    {
        moved = attacked = false;
    }
}
