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
    public float life = 550f;
    public float originalLife;
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
    private bool axeProtects = false;
    private float timeLeft = 10f;
    private Material axeMat;
    
    
    public SpriteRenderer redScreen;
    private GameObject ground;
    private GroundRotation groundRotation;
    private bool up;
    private bool isFlashRedStarted = false;
    
    private AudioSource _as;
    
    
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
        axeMat = GetComponent<SpriteRenderer>().material;
        ground = GameObject.FindGameObjectWithTag("RotatingGround");
        groundRotation = ground.GetComponent<GroundRotation>();
        _as = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        if (axeMat.color == Color.white)
        {
            Color tmp = Color.clear;
            tmp.a = 0f;
            redScreen.color = tmp;
        }

        
        // Damage from rotation
        if (groundRotation.up)
        {
            life -= 0.1f;
            Vector3 pos2 = drain.position;
            drain.position = new Vector3(pos2.x - (drainage)/10, pos2.y, pos2.z);
            if (!isFlashRedStarted)
            {
                StartCoroutine("FlashRed");
            }
        }
        else
        {
            isFlashRedStarted = false;
        }

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

        if (axeProtects)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            { 
                axeProtects = false;
                timeLeft = 7f;
                axeMat.color = Color.white;
            }
        }
    }

    
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Crowd") && !axeProtects)
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
            _as.PlayOneShot(_as.clip);

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
        else if (collision.CompareTag("Axe"))
        {
            _as.PlayOneShot(_as.clip);
            axeMat.color = Color.green;
            axeProtects = true;
        } else if (collision.CompareTag("Boi"))
        {
            gameController.GameOver();
        } else if (collision.CompareTag("Crowd") && !axeProtects)
        {
            axeMat.color = Color.red;
            StartCoroutine(FadeInRed());
        }
    }

    IEnumerator FadeInRed()
    {
        Color tmp = Color.red;
        for (float r = 0f; r <= 0.3f; r += 0.05f)
        {
            tmp.a = r;
            redScreen.color = tmp;
            yield return null;
        }
    }
    
    IEnumerator FadeOutRed()
    {
        Color tmp = Color.red;
        for (float r = 0.3f; r >= 0f; r -= 0.05f)
        {
            tmp.a = r;
            redScreen.color = tmp;
            yield return null;
        }
    }
    
    IEnumerator FlashRed()
    {
        isFlashRedStarted = true;
        yield return new WaitForSeconds(1f);
        StartCoroutine("FadeInRed");
        yield return new WaitForSeconds(0.8f);
        StartCoroutine("FadeOutRed");
        yield return new WaitForSeconds(1f);

        if (isFlashRedStarted)
        {
            StartCoroutine("FlashRed");
        }
    }
    
    

    private void OnTriggerExit2D(Collider2D other)
    {
            Color tmp = Color.clear;
            tmp.a = 0f;
            redScreen.color = tmp;
            axeMat.color = Color.white;
    }
}
