using UnityEngine;

public class ControlManager : MonoBehaviour {

    public GameManager GM;
    public CombatManager CM;
    public UIManager UM;
    public AIManager AM;

    public void Move (Unit selected, Tile target)
    {
        if (target.unit)
        {
            Debug.Log("CM:: Tile occupied");
        }
        else if (target.unit == GM.GetSelected())
        {
            Debug.Log("CM:: Unit already there");
        }
        else if (Distance(selected, target) <= 3)
        {
            Debug.Log("CM:: Unit moved");
            selected.tile.unit = null;
            selected.tile = target;
            target.unit = selected;
            selected.gameObject.transform.position = target.gameObject.transform.position;
            selected.SetMoved(true);
            GM.Reset();
        }
        else
            Debug.Log("CM:: Tile too far");
    }
    public void Attack(int skill, Unit selected, Unit target)
    {
        if (Distance(selected, target.tile) <= SkillList.list[skill].GetRange())
        {
            switch (CM.Attack(skill, selected, target))
            {
                case 0:
                    Debug.Log("UNIT:: Neither unit died");
                    break;
                case 1:
                    Debug.Log("UNIT:: Target unit died");
                    break;
                case 2:
                    Debug.Log("UNIT:: Selected unit died");
                    break;
                case 3:
                    Debug.Log("UNIT:: Both units died");
                    break;
            }

            selected.SetAttacked(true);
            GM.Reset();
            UM.UpdateConsole(selected);
            UM.UpdateConsole(target);
        }
        else
            Debug.Log("CONTROLMANAGER:: Target too far away");
    }

    /*public int Distance(Tile user, Tile target, int turn = 1)
    {
        if (turn == 10)
            return 100; ;

        int left, right, up, down;
        left = right = up = down = 20;
        int distance;

        if (user.l)
        {
            if (user.left == target)
            {
                return turn;
            }
            else if (user.left.unit == null)
            {
                left = Distance(user.left, target, turn + 1);
            }
        }
        if (user.r)
        {
            if (user.right == target)
            {
                return turn;
            }
            else if (user.right.unit == null)
            {
                right = Distance(user.right, target, turn + 1) + 1;
            }
        }
        if (user.u)
        {
            if (user.up == target)
            {
                return turn;
            }
            else if (user.up.unit == null)
            {
                up = Distance(user.up, target, turn + 1) + 1;
            }
        }
        if (user.d)
        {
            if (user.down == target)
            {
                return turn;
            }
            else if (user.down.unit == null)
            {
                down = Distance(user.down, target, turn + 1) + 1;
            }
        }

        distance = (left < right) ? left : right;
        distance = (distance < up) ? distance : up;
        distance = (distance < down) ? distance : down;

        return distance;
    }//*/
    public int Distance(Unit selected, Tile target)
    {
        Tile user = selected.tile;

        if (user.l)
        {
            if (user.left == target)
            {
                return 1;
            }
            if (user.left.l && user.left.unit == null)
            {
                if (user.left.left == target)
                {
                    return 2;
                }
                if (user.left.left.l && user.left.left.unit == null)
                {
                    if (user.left.left.left == target)
                    {
                        return 3;
                    }
                }
                if (user.left.left.u && user.left.left.unit == null)
                {
                    if (user.left.left.up == target)
                    {
                        return 3;
                    }
                }
                if (user.left.left.d && user.left.left.unit == null)
                {
                    if (user.left.left.down == target)
                    {
                        return 3;
                    }
                }
            }
            if (user.left.u && user.left.unit == null)
            {
                if (user.left.up == target)
                {
                    return 2;
                }
                if (user.left.up.u && user.left.up.unit == null)
                {
                    if (user.left.up.up == target)
                    {
                        return 3;
                    }
                }
                if (user.left.up.l && user.left.up.unit == null)
                {
                    if (user.left.up.left == target)
                    {
                        return 3;
                    }
                }
                if (user.left.up.r && user.left.up.unit == null)
                {
                    if (user.left.up.right == target)
                    {
                        return 3;
                    }
                }
            }
            if (user.left.d && user.left.unit == null)
            {
                if (user.left.down == target)
                {
                    return 2;
                }
                if (user.left.down.l && user.left.down.unit == null)
                {
                    if (user.left.down.left == target)
                    {
                        return 3;
                    }
                }
                if (user.left.down.d && user.left.down.unit == null)
                {
                    if (user.left.down.down == target)
                    {
                        return 3;
                    }
                }
                if (user.left.down.r && user.left.down.unit == null)
                {
                    if (user.left.down.right == target)
                    {
                        return 3;
                    }
                }
            }
        }
        if (user.u)
        {
            if (user.up == target)
            {
                return 1;
            }
            if (user.up.l && user.up.unit == null)
            {
                if (user.up.left == target)
                {
                    return 2;
                }
                if (user.up.left.l && user.up.left.unit == null)
                {
                    if (user.up.left.left == target)
                    {
                        return 3;
                    }
                }
                if (user.up.left.u && user.up.left.unit == null)
                {
                    if (user.up.left.up == target)
                    {
                        return 3;
                    }
                }
                if (user.up.left.d && user.up.left.unit == null)
                {
                    if (user.up.left.down == target)
                    {
                        return 3;
                    }
                }
            }
            if (user.up.u && user.up.unit == null)
            {
                if (user.up.up == target)
                {
                    return 2;
                }
                if (user.up.up.u && user.up.up.unit == null)
                {
                    if (user.up.up.up == target)
                    {
                        return 3;
                    }
                }
                if (user.up.up.l && user.up.up.unit == null)
                {
                    if (user.up.up.left == target)
                    {
                        return 3;
                    }
                }
                if (user.up.up.r && user.up.up.unit == null)
                {
                    if (user.up.up.right == target)
                    {
                        return 3;
                    }
                }
            }
            if (user.up.r && user.up.unit == null)
            {
                if (user.up.right == target)
                {
                    return 2;
                }
                if (user.up.right.u && user.up.right.unit == null)
                {
                    if (user.up.right.up == target)
                    {
                        return 3;
                    }
                }
                if (user.up.right.r && user.up.right.unit == null)
                {
                    if (user.up.right.right == target)
                    {
                        return 3;
                    }
                }
                if (user.up.right.d && user.up.right.unit == null)
                {
                    if (user.up.right.down == target)
                    {
                        return 3;
                    }
                }
            }
        }
        if (user.r)
        {
            if (user.right == target)
            {
                return 1;
            }
            if (user.right.unit == null)
            {
                if (user.right.u)
                {
                    if (user.right.up == target)
                    {
                        return 2;
                    }
                    if (user.right.up.unit == null)
                    {
                        if (user.right.up.l)
                        {
                            if (user.right.up.left == target)
                            {
                                return 3;
                            }
                        }
                        if (user.right.up.u)
                        {
                            if (user.right.up.up == target)
                            {
                                return 3;
                            }
                        }
                        if (user.right.up.r)
                        {
                            if (user.right.up.right == target)
                            {
                                return 3;
                            }
                        }
                    }
                }
                if (user.right.r)
                {
                    if (user.right.right == target)
                    {
                        return 2;
                    }
                    if (user.right.right.unit == null)
                    {
                        if (user.right.right.u)
                        {
                            if (user.right.right.up == target)
                            {
                                return 3;
                            }
                        }
                        if (user.right.right.r)
                        {
                            if (user.right.right.right == target)
                            {
                                return 3;
                            }
                        }
                        if (user.right.right.d)
                        {
                            if (user.right.right.down == target)
                            {
                                return 3;
                            }
                        }
                    }
                }
                if (user.right.d)
                {
                    if (user.right.down == target)
                    {
                        return 2;
                    }
                    if (user.right.down.unit == null)
                    {
                        if (user.right.down.r)
                        {
                            if (user.right.down.right == target)
                            {
                                return 3;
                            }
                        }
                        if (user.right.down.d)
                        {
                            if (user.right.down.down == target)
                            {
                                return 3;
                            }
                        }
                        if (user.right.down.l)
                        {
                            if (user.right.down.left == target)
                            {
                                return 3;
                            }
                        }
                    }
                }
            }
        }
        if (user.d)
        {
            if (user.down == target)
            {
                return 1;
            }
            if (user.down.r && user.down.unit == null)
            {
                {
                    if (user.down.right == target)
                    {
                        return 2;
                    }
                }
                if (user.down.right.u && user.down.right.unit == null)
                {
                    if (user.down.right.up == target)
                    {
                        return 3;
                    }
                }
                if (user.down.right.r && user.down.right.unit == null)
                {
                    if (user.down.right.right == target)
                    {
                        return 3;
                    }
                }
                if (user.down.right.d && user.down.right.unit == null)
                {
                    if (user.down.right.down == target)
                    {
                        return 3;
                    }
                }
            }
            if (user.down.d && user.down.unit == null)
            {
                if (user.down.down == target)
                {
                    return 2;
                }
                if (user.down.down.r && user.down.down.unit == null)
                {
                    if (user.down.down.right == target)
                    {
                        return 3;
                    }
                }
                if (user.down.down.d && user.down.down.unit == null)
                {
                    if (user.down.down.down == target)
                    {
                        return 3;
                    }
                }
                if (user.down.down.l && user.down.down.unit == null)
                {
                    if (user.down.down.left == target)
                    {
                        return 3;
                    }
                }
            }
            if (user.down.l && user.down.unit == null)
            {
                if (user.down.left == target)
                {
                    return 2;
                }
                if (user.down.left.d && user.down.left.unit == null)
                {
                    if (user.down.left.down == target)
                    {
                        return 3;
                    }
                }
                if (user.down.left.l && user.down.left.unit == null)
                {
                    if (user.down.left.left == target)
                    {
                        return 3;
                    }
                }
                if (user.down.left.u && user.down.left.unit == null)
                {
                    if (user.down.left.up == target)
                    {
                        return 3;
                    }
                }
            }
        }
        return 4;
    }//*/

    public void EndTurn()
    {
        UM.Options(false, false, false);
        GM.Reset();
        
        foreach (Unit unit in GM.GetUnits((int)Enums.Group.Ally))
        {
            unit.Reset();
        }
        Debug.Log("CM:: Enemy's turn");
        AM.Control((int)Enums.Group.Enemy);
        AM.Control((int)Enums.Group.Monster);
    }
}
