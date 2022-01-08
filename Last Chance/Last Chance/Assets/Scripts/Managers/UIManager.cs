using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameManager GM;
    public ControlManager CM;
    public GameObject pause, console, options, skills, allyPanel, enemyPanel, end, victory;
    public Button moveButton, attackButton, skillButton;

    // Update is called once per frame
    void Update()
    {
        ScanForKeyStroke();
    }

    // Method for pause menu
    void ScanForKeyStroke()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (GM.GetMove() || GM.GetAtt() != -1)
            {
                GM.SetMove(false);
                GM.SetAttack(-1);
                options.SetActive(true);
            }
            else
                pause.SetActive(true);
        }
    }
    //Method for attack menu
    public void Options(bool attackMenu, bool attacked, bool moved)
    {
        options.SetActive(attackMenu);
        attackButton.interactable = !attacked;
        skillButton.interactable = !attacked;
        moveButton.interactable = !moved;
    }
    //Method for skills menu
    public void SkillsMenu(bool skillMenu)
    {
        options.SetActive(!skillMenu);
        skills.SetActive(skillMenu);
    }
    public void Pause(bool paused)
    {
        pause.SetActive(paused);
    }

    public void Move()
    {
        GM.SetMove(true);
        options.SetActive(false);
    }
    public void Attack()
    {
        GM.SetAttack((int)Enums.ID.Attack);
        options.SetActive(false);
    }
    public void Skills()
    {
        skills.SetActive(true);
        options.SetActive(false);
    }

    public void Confirm(int skill)
    {
        options.SetActive(false);
        skills.SetActive(false);
        GM.SetAttack(skill);
    }
    public void Cancel()
    {
        options.SetActive(false);
        skills.SetActive(false);
        GM.SetSelected(null);
    }

    public void Victory(bool won)
    {
        console.SetActive(!won);
        pause.SetActive(!won);
        skills.SetActive(!won);
        options.SetActive(!won);
        end.SetActive(!won);
        victory.SetActive(won);
    }

    public void UpdateConsole(Unit unit)
    {
        if (unit.group == (int)Enums.Group.Ally)
        {
            console.transform.Find("Ally/Name").GetComponent<Text>().text = unit.GetChar().GetName();
            console.transform.Find("Ally/Class").GetComponent<Text>().text = unit.GetChar().GetType();
            console.transform.Find("Ally/Health").GetComponent<Text>().text = unit.GetChar().GetHealth().ToString();
            console.transform.Find("Ally/Energy").GetComponent<Text>().text = unit.GetChar().GetEnergy().ToString();
            if (unit.GetChar().GetExp() < 0)
                console.transform.Find("Ally/Exp").GetComponent<Text>().text = "0";
            else
                console.transform.Find("Ally/Exp").GetComponent<Text>().text = unit.GetChar().GetExp().ToString();
        }
        else
        {
            console.transform.Find("Enemy/Name").GetComponent<Text>().text = unit.GetChar().GetName();
            console.transform.Find("Enemy/Class").GetComponent<Text>().text = unit.GetChar().GetType();
            console.transform.Find("Enemy/Health").GetComponent<Text>().text = unit.GetChar().GetHealth().ToString();
            console.transform.Find("Enemy/Energy").GetComponent<Text>().text = unit.GetChar().GetEnergy().ToString();
            if (unit.GetChar().GetExp() < 0)
                console.transform.Find("Enemy/Exp").GetComponent<Text>().text = "0";
            else
                console.transform.Find("Enemy/Exp").GetComponent<Text>().text = unit.GetChar().GetExp().ToString();
        }
    }
    public void ResetConsole()
    {
        console.transform.Find("Ally/Name").GetComponent<Text>().text = "???";
        console.transform.Find("Ally/Class").GetComponent<Text>().text = "???";
        console.transform.Find("Ally/Health").GetComponent<Text>().text = "???";
        console.transform.Find("Ally/Energy").GetComponent<Text>().text = "???";
        console.transform.Find("Ally/Exp").GetComponent<Text>().text = "???"; 
        console.transform.Find("Enemy/Name").GetComponent<Text>().text = "???";
        console.transform.Find("Enemy/Class").GetComponent<Text>().text = "???";
        console.transform.Find("Enemy/Health").GetComponent<Text>().text = "???";
        console.transform.Find("Enemy/Energy").GetComponent<Text>().text = "???";
        console.transform.Find("Enemy/Exp").GetComponent<Text>().text = "???";
    }
}
