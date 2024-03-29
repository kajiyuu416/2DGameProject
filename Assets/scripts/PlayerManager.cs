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
        float x = Input.GetAxisRaw("Horizontal");//ｘ方向の入力
        float y = Input.GetAxisRaw("Vertical");//y方向の入力
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

        //上にのぼる条件
        //はしごがある
        //プレイヤーが↑入力を押している
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