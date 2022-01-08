using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static SaveFile file;
    public UIManager UM;
    public AIManager AI;
    private Unit user, target, selected;
    private bool move;
    private int attack, turn;

    // Use this for initialization
    void Start()
    {
        selected = null;
        attack = -1;
    }

    public void Reset()
    {
        Debug.Log("GM:: User: " + user + " - null");
        Debug.Log("GM:: Selected: " + selected + " - null");
        Debug.Log("GM:: Target: " + target + " - null");
        Debug.Log("GM:: Move: " + move + " - false");
        Debug.Log("GM:: Attack: " + attack + " - -1");

        user = selected = target = null;
        move = false;
        attack = -1;
        UM.Options(false, false, false);
    }
    public void Base()
    {
        SceneManager.LoadScene((int)Enums.Scenes.Base);
        UM.Pause(false);
        Debug.Log("GAMEMANAGER:: Returned to base");
    }
    public void Castle()
    {
        SceneManager.LoadScene((int)Enums.Scenes.Castle);
        UM.Pause(false);
        Debug.Log("GAMEMANAGER:: Started castle level");
    }
    public void Exit()
    {
        SceneManager.LoadScene((int)Enums.Scenes.MainMenu);
        UM.Pause(false);
        Debug.Log("GAMEMANAGER:: Exit to main menu");
    }
    public void Victory()
    {
        UM.Victory(true);
    }
    public void Defeat()
    {
        SceneManager.LoadScene((int)Enums.Scenes.GameOver);
    }

    public Unit[] GetUnits(int turn)
    {
        GameObject[] objects;
        Unit[] units;
        switch (turn)
        {
            case (int)Enums.Group.Ally:
                objects = GameObject.FindGameObjectsWithTag("Ally");
                break;
            case (int)Enums.Group.Enemy:
                objects = GameObject.FindGameObjectsWithTag("Enemy");
                break;
            case (int)Enums.Group.Monster:
                objects = GameObject.FindGameObjectsWithTag("Monster");
                break;
            default:
                objects = GameObject.FindGameObjectsWithTag("Ally");
                SetTurn((int)Enums.Group.Ally);
                break;
        }
        units = new Unit[objects.Length];
        for (int i = 0; i < objects.Length; i++)
            units[i] = objects[i].GetComponent<Unit>();
        return units;
    }
    public Unit GetSelected()
    {
        return selected;
    }
    public void SetSelected(Unit select)
    {
        Debug.Log("GM:: Selected: " + selected + " - " + select);
        selected = select;
    }
    public Unit GetUser()
    {
        return user;
    }
    public void SetUser(Unit usr)
    {
        Debug.Log("GM:: User: " + user + " - " + usr);
        user = usr;
    }
    public Unit GetTarget()
    {
        return target;
    }
    public void SetTarget(Unit trgt)
    {
        Debug.Log("GM:: Target: " + target + " - " + trgt);
        target = trgt;
    }
    public bool GetMove()
    {
        return move;
    }
    public void SetMove(bool mv)
    {
        Debug.Log("GM:: Move: " + move + " - " + mv);
        move = mv;
    }
    public int GetAtt()
    {
        return attack;
    }
    public void SetAttack(int att)
    { 
        Debug.Log("GM:: Attack: " + attack + " - " + att);
        attack = att;
    }
    public int Turn()
    {
        return ++turn;
    }
    public int GetTurn()
    {
        return turn;
    }
    public void SetTurn(int ally)
    {
        Debug.Log("GM:: Turn: " + turn + " - " + ally);
        turn = ally;
    }
}
