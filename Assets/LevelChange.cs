using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour 
{
    public int index;
    public bool quit = false;

    void Update()
    {
        if (quit && Time.time >= 5)
            Application.Quit();
    }
    void OnTriggerEnter( Collider kys)
    {
        if (kys.CompareTag("LevC"))
        {
            SceneManager.LoadScene(index);
        }
    }
}
