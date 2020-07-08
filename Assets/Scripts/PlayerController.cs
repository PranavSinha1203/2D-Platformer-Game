using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator PlayerAnimator;
    BoxCollider2D PlayerCollider;
    Rigidbody2D PlayerRb;
    private Vector2 Playerpos;
    public float JumpForce;
    public float PlayerColliderNormalPosition, PlayerColliderCrouchPosition;
    public float NormalSizex, NormalSizey;
    public float CrouchSizex, CrouchSizey;
    public float Speed;
    private Vector2 PlayerPosition;
    private bool IsJump;
    
    void Start()
    {
        PlayerCollider = GetComponent<BoxCollider2D>();
        PlayerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerHorizontalMovement();
        PlayerCrouch();
        PlayerJump();
    }

    void PlayerHorizontalMovement()
    {
        float Horizontalspeed = Input.GetAxisRaw("Horizontal");
        PlayerAnimator.SetFloat("Speed", Mathf.Abs(Horizontalspeed));

        PlayerPosition = transform.position;
        PlayerPosition.x += Horizontalspeed * Speed * Time.deltaTime;
        transform.position = PlayerPosition;

        Vector2 scale = transform.localScale;
        if (Horizontalspeed < 0)
        {
            scale.x = -1 * Mathf.Abs(scale.x);
        }
        else if (Horizontalspeed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }

        transform.localScale = scale;
    }

    void PlayerCrouch()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            PlayerAnimator.SetBool("isCrouch", true);
            PlayerCollider.size = new Vector2(CrouchSizex, CrouchSizey);
            PlayerCollider.offset = new Vector2(Playerpos.x, Playerpos.y + PlayerColliderCrouchPosition);
        }
        else
        {
            PlayerAnimator.SetBool("isCrouch", false);
            PlayerCollider.size = new Vector2(NormalSizex, NormalSizey);
            PlayerCollider.offset = new Vector2(Playerpos.x, Playerpos.y + PlayerColliderNormalPosition);

        } 
    }

    void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.W) && IsJump)
        {
            PlayerAnimator.SetBool("Jump", true);
            PlayerRb.AddForce(Vector3.up * JumpForce);
            IsJump = false;
        }
        else
        {
            PlayerAnimator.SetBool("Jump", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Ground")
        {
            IsJump = true;
        }
       
    }

}
