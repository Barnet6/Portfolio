using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IPointerClickHandler
{
    public GameManager GM;
    public ControlManager CM;
    public Unit unit;
    public Tile left, right, up, down;
    public bool l, r, u, d;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (GM.GetMove())
            CM.Move(GM.GetSelected(), this);
        else
            GM.Reset();
    }
}
