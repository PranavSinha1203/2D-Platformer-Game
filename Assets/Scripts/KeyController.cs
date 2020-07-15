using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    // Start is called before the first frame update
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.layer == 8)
        {
            PlayerController playercntrl = GetComponent<PlayerController>();
            playercntrl.ScoreIncrement();
          
        }
    }
}
