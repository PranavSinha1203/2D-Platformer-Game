using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    Vector2 EnemyScale;
    void Start()
    {
        EnemyScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }

    void EnemyMove()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 14)
        {
            speed = -1 * speed;
            EnemyScale.x = -1 * EnemyScale.x;

            transform.localScale = EnemyScale;
        }
    }


}
