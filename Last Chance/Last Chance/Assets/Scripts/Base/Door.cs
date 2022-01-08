using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public void OnMouseDown()
    {
        SceneManager.LoadScene((int)Enums.Scenes.Map);
    }
}