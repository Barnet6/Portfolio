using UnityEngine;
using UnityEngine.EventSystems;

public class Background : MonoBehaviour, IPointerClickHandler {

    public GameManager GM;
    public UIManager UM;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (GM.GetTurn() == (int)Enums.Group.Ally)
        {
            GM.SetSelected(null);
            UM.ResetConsole();
        }
    }
}
