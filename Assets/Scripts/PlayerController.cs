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
    public int life = 1000;
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
    
    void Awake () {
        QualitySettings.vSyncCount = 0;  // VSync must be disabled
        Application.targetFrameRate = 60;
    }
    
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -7)
        {
            transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z);
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

            life = life - 1;
            Debug.Log(life.ToString());
            if (life < 0)
            {
                gameController.GameOver();
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Agua"))
        {
            life = life + 15;
            Debug.Log(life);
        }
        else if (collision.CompareTag("Axe")) {
            Debug.Log("Protected!");
        } else if (collision.CompareTag("Boi"))
        {
            gameController.GameOver();
        }
    }

}
