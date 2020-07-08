using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoad : MonoBehaviour
{
    public string Level2;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.GetComponent< PlayerController>() != null)
        {
            SceneManager.LoadScene(Level2);
        }
    }
}
