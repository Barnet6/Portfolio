using System.Collections;
using System.Linq;
using UnityEngine;

public class AIManager : MonoBehaviour {

    public GameManager GM;
    public ControlManager CM;
    private Character[] allyList, enemyList;

    void Start()
    {
        StartCoroutine(Delay(1));
    }

    IEnumerator Delay(int seconds)
    {
        print(Time.time);
        yield return new WaitForSeconds(seconds);
        print(Time.time);
    }

    public void Control(int turn)
    {
        foreach (Unit unit in GM.GetUnits(turn))
        {
            GM.SetSelected(unit);

            Unit target = FindClosest(unit);
            if (CM.Distance(unit, target.tile) == 1)
                Attack(unit, target);
            else
            {
                Tile[] tiles = TilesInRange(unit);
                Tile closest = ClosestToEnemy(tiles, target);

                CM.Move(unit, closest);
                Delay(1);
                Attack(unit, target);
                Delay(1);
            }
            unit.Reset();
        }
    }
    
    //Find the closest enemy to a unit, selected
    public Unit FindClosest(Unit selected)
    {
        Unit closest = GM.GetUnits((int)Enums.Group.Ally)[0];
        int distance = 100;
        for (int i = (int)Enums.Group.Ally; i < (int)Enums.Group.Last; i++)
        {
            if (i != selected.group)
            {
                foreach (Unit unit in GM.GetUnits(i))
                {
                    if (CM.Distance(selected, unit.tile) == 1)
                    {
                        return unit;
                    }
                    if (CM.Distance(selected, unit.tile) < distance)
                    {
                        distance = CM.Distance(selected, unit.tile);
                        closest = unit;
                    }
                }
            }
        }
        return closest;
    }
    //Find all tiles that a unit, selected, can move to in one turn
    public Tile[] TilesInRange(Unit selected)
    {
        GameObject[] objects;
        Tile temp;
        Tile[] tiles = new Tile[25];
        int count = 0;
        objects = GameObject.FindGameObjectsWithTag("Tile");
        foreach (GameObject tile in objects)
        {
            temp = tile.GetComponent<Tile>();
            if (CM.Distance(selected, temp) <= 3)
            {
                tiles[count++] = temp;
            }
        }
        return tiles;
    }
    //Find the closest tile to a unit, target
    public Tile ClosestToEnemy(Tile[] tiles, Unit target)
    {
        int distance = CM.Distance(target, tiles[0]);
        Tile closest = tiles[0];
        foreach (Tile tile in tiles)
        {
            if (CM.Distance(target, tile) < distance)
            {
                closest = tile;
                distance = CM.Distance(target, tile);
            }
        }
        return closest;
    }
    //The unit, selected, attacks the unit, target
    public void Attack(Unit selected, Unit target)
    {
        CM.Attack((int)Enums.ID.Attack, selected, target);
    }
}
