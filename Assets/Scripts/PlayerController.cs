using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 0f;
    public bool isGrounded = false;
    public float jumpForce = 950f;
    public int life = 1000;
    
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

        MovePlayer();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

    }

    private void MovePlayer()
    {
        transform.Translate(new Vector3(speed, 0, 0));

    }

    private void FixedUpdate()
    {
        transform.Translate(new Vector3(speed, 0, 0));

        if (Physics2D.OverlapCircle(checkground.transform.position, 0.2f, LayerGround))
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

    public void Jump()
    {
        if (isGrounded)
        {
            rig.velocity = Vector2.zero;
            rig.AddForce(new Vector2(0, jumpForce));
            
        }

    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Crowd")
        {
            life = life - 1;
            Debug.Log(life.ToString());
        }

    }

}
