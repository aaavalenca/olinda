using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    // better jump
    public float speed = 0f;
    public bool isGrounded = false;
    public float jumpForce = 600f;
    public int life = 550;
    public int originalLife;
    private float drainage;
    public float originalDrainPos;
    public bool isHoldingJump = false;
    private float jumpTimeCounter;
    public float jumpTime;

    public GameController gameController;
    [SerializeField] GameOver gameOver;

    private Animator anim;
    private Rigidbody2D rig;

    public LayerMask LayerGround;
    public Transform checkground;
    public string isGroundBool = "isGround";

    public Transform drain;

    public SpriteRenderer redScreen;
    
    void Awake () {
        QualitySettings.vSyncCount = 0;  // VSync must be disabled
        Application.targetFrameRate = 60;
    }
    
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        drainage = 5.5f / life;
        originalLife = life;
        originalDrainPos = drain.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        
        if (transform.position.x < -7)
        {
            transform.position = new Vector3(pos.x + 0.1f, pos.y, pos.z);
        }

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            isHoldingJump = true;
            jumpTimeCounter = jumpTime;
            rig.velocity = Vector2.zero;
            rig.AddForce(new Vector2(0, jumpForce));
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isHoldingJump = false;
        }
    }

    private void FixedUpdate()
    {

        if (isHoldingJump)
        {
            if (jumpTimeCounter > 0)
            {
                rig.velocity = Vector2.zero;
                rig.AddForce(new Vector2(0, jumpForce));
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isHoldingJump = false;
            }


        }

        if (Physics2D.OverlapCircle(checkground.transform.position, 0.3f, LayerGround))
        {
            anim.SetBool(isGroundBool, true);
            isGrounded = true;
        }
        else
        {
            anim.SetBool(isGroundBool, false);
            isGrounded = false;
        }
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Crowd"))
        {
            
            life -= 1;
            Vector3 pos = drain.position;
            drain.position = new Vector3(pos.x - drainage, pos.y, pos.z);
            
            if (life < 0)
            {
                gameController.GameOver();
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        // fr.StartFlash();
        
        if (collision.CompareTag("Agua"))
        {
            Vector3 pos = drain.position;

            if (life > originalLife - 30)
            {
                life = originalLife;
                drain.position = new Vector3(originalDrainPos, pos.y, pos.z);
            }
            else
            {
                life += 30;
                drain.position = new Vector3(pos.x + drainage * 30, pos.y, pos.z);
            }

          
        }
        else if (collision.CompareTag("Axe")) {
            Debug.Log("Protected!");
        } else if (collision.CompareTag("Boi"))
        {
            gameController.GameOver();
        } else if (collision.CompareTag("Crowd"))
        {
            Color tmp = Color.red;
            tmp.a = 0.2f;
            redScreen.color = tmp;
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Crowd"))
        {
            Color tmp = Color.red;
            tmp.a = 0f;
            redScreen.color = tmp;
        }
    }
}
