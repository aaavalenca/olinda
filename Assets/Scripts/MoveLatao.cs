using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MoveLatao : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

        if (transform.position.x < -14)
        {
            Destroy(this.gameObject);
        }        
        transform.Translate(Vector2.left * 2 * Time.smoothDeltaTime);


    }
}
