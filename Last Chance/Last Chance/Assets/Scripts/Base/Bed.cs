using UnityEngine;
using UnityEngine.SceneManagement;

public class Bed : MonoBehaviour
{ 
    public void OnMouseDown()
    {
        SceneManager.LoadScene((int)Enums.Scenes.SaveGame);
    }
}
