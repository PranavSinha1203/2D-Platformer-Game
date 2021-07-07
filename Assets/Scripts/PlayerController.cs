using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public static PlayerController instance;
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
    public float PlayerDeadPos;
    public string RestartLevel;
    public int score;
    public Text ScoreUI;
    public GameObject DeadPlayer;
    public GameObject GameOverPanel;
    public GameObject PlayerAlive;
    public bool PlayerMove;
    private int Lives;
    public GameObject[] LivesImages;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        PlayerCollider = GetComponent<BoxCollider2D>();
        PlayerRb = GetComponent<Rigidbody2D>();
        score = 0;
        Lives = 3;
        PlayerMove = true;
        //PlayerAlive.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
            PlayerHorizontalMovement();
            PlayerCrouch();
            PlayerJump();

        if(Lives<1)
        {
            PlayerDead();
        }
        

    }

    void PlayerHorizontalMovement()
    {
        if(PlayerMove)
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

    public void ScoreIncrement()
    {
        score += 10;
        ScoreUI.text = score.ToString();
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
      
        if(col.gameObject.layer == 9)
        {
            IsJump = true;
        }
        if(col.gameObject.layer == 10 )
        {
            PlayerDead();
        }
        if(col.gameObject.layer == 12)
        {
            LivesImages[Lives-1].SetActive(false);
            Lives--;
        }
       
    }

    public void PlayerDead()
    {
        PlayerPosition = transform.position;
        Instantiate(DeadPlayer, PlayerPosition, transform.rotation);
        PlayerAlive.SetActive(false);
        GameOverPanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(RestartLevel);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.layer == 13 )
        {
            Destroy(col.gameObject);
            ScoreIncrement();
        }
    }

}
