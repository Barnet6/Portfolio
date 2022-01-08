using UnityEngine;
using UnityEngine.SceneManagement;

public class Map : MonoBehaviour {

    public bool Base, Castle;
    
    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update ()
    {

    }

    private void OnMouseDown()
    {
        if (Base)
        {
            SceneManager.LoadScene((int)Enums.Scenes.Base);
        }
        if (Castle)
        {
            SceneManager.LoadScene((int)Enums.Scenes.Castle);
        }
    }
}
