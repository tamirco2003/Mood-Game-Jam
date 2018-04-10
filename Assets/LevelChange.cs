using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour 
{
    public int index;
    public bool quit = false;

    void OnTriggerEnter( Collider kys)
    {
        if (kys.CompareTag("LevC"))
        {
            if (quit)
                Application.Quit();
            SceneManager.LoadScene(index);
        }
    }
}
