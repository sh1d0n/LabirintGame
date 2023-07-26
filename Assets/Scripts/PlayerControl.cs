using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed;
    private CircleCollider2D cc;
    private Vector2 direction;
    private Rigidbody2D rb;

    void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        cc = GetComponent<CircleCollider2D>();
    }

    void Update() 
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");

        if(Input.GetKeyDown(KeyCode.Q))
        {
            cc.GetComponent<CircleCollider2D>().enabled = !cc.GetComponent<CircleCollider2D>().enabled;
        }
        if(Input.GetKeyDown(KeyCode.Z))
        {
            PlayerPrefs.DeleteKey("BestTime");
        }
    }

    void FixedUpdate() 
    {
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }
}
