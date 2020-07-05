using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator PlayerAnimator;
    BoxCollider2D PlayerCollider;
    Vector2 Playerpos;
    public float PlayerColliderNormalPosition, PlayerColliderCrouchPosition;
    void Start()
    {
        PlayerCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        PlayerControl();
    }

    void PlayerControl()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        PlayerAnimator.SetFloat("Speed", Mathf.Abs(speed));

        Vector2 scale = transform.localScale;
        if (speed < 0)
        {
            scale.x = -1 * Mathf.Abs(scale.x);
        }
        else if (speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }

        transform.localScale = scale;

        if (Input.GetKey(KeyCode.LeftControl))
        {
            PlayerAnimator.SetBool("isCrouch", true);
            PlayerCollider.size = new Vector2(1f, 1.2f);
            PlayerCollider.offset = new Vector2(Playerpos.x, Playerpos.y + PlayerColliderCrouchPosition);
        }
        else
        {
            PlayerAnimator.SetBool("isCrouch", false);
            PlayerCollider.size = new Vector2(0.5f, 2f);
            PlayerCollider.offset = new Vector2(Playerpos.x, Playerpos.y + PlayerColliderNormalPosition);

        }

        if (Input.GetKey(KeyCode.W))
        {
            PlayerAnimator.SetBool("Jump", true);
        }
        else
        {
            PlayerAnimator.SetBool("Jump", false);
        }
    }

 
}
