using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour 
{
    public int index;

    void OnTriggerEnter( Collider kys)
    {
        if (kys.CompareTag("LevC"))
            SceneManager.LoadScene(index);
    }
}
