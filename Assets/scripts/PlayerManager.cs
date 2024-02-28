using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    bool isCliming;
    public float distance;
    public LayerMask laddarLayer;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isCliming = false;
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");//‚˜•ûŒü‚Ì“ü—Í
        float y = Input.GetAxisRaw("Vertical");//y•ûŒü‚Ì“ü—Í
        rb.velocity = new Vector2(x, rb.velocity.y);


        //Physics2D.Raycast
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position,Vector2.up, 2,laddarLayer);
        if(hitInfo.collider != null)
        {
            if (y > 0)
            {
                isCliming = true;
            }
        }
        else
        {
            isCliming = false;
        }

        //ã‚É‚Ì‚Ú‚éğŒ
        //‚Í‚µ‚²‚ª‚ ‚é
        //ƒvƒŒƒCƒ„[‚ªª“ü—Í‚ğ‰Ÿ‚µ‚Ä‚¢‚é
        if (isCliming)
        {
            rb.velocity = new Vector2(rb.velocity.x, y * speed);
            rb.gravityScale = 0;
        }
        else
        {
            rb.gravityScale = 2;
        }
       
    }

}