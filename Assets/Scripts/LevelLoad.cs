using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoad : MonoBehaviour
{
    public string LevelComplete;
    public GameObject LevelCompletePanel;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.GetComponent< PlayerController>() != null)
        {
           // PlayerController.instance.PlayerMove = false;
            LevelCompletePanel.SetActive(true);
            
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(LevelComplete);
    }
}
