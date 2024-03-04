using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rb;
    public float MovementSpeed;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float InputV = Input.GetAxis("Vertical");
        float InputH = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(InputH*MovementSpeed, InputV*MovementSpeed);
    }
}
