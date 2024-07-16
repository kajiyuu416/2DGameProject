using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    //Jump,Animation
    [SerializeField] LayerMask blockLayer;
    Rigidbody2D rigidbody2D;
    float speed = 0;
    float jumpPower = 550;
    Animator animator;
    bool isDead;
    //SE
    [SerializeField] AudioClip getItemSE;
    [SerializeField] AudioClip jumpSE;
    [SerializeField] AudioClip stampSE;
    AudioSource audioSource;

    public enum MOVE_DIRECTION
    {
        STOP,
        LEFT,
        RIGHT,
    }
    MOVE_DIRECTION moveDirection = MOVE_DIRECTION.STOP;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        isDead = false;

    }

    void Update()
    {
        if (isDead)
        {
            return;
        }
        float x = Input.GetAxis("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(x));
        if (x == 0)
        {
            // 止まる
            moveDirection = MOVE_DIRECTION.STOP;
        }
        else if (x > 0)
        {
            // 右に移動
            moveDirection = MOVE_DIRECTION.RIGHT;
        }
        else if (x < 0)
        {
            // 左に移動
            moveDirection = MOVE_DIRECTION.LEFT;
        }
        if (IsGround())
        {
            if (Input.GetKeyDown("space"))
            {
                animator.SetBool("isJumping", true);
                jump();
                audioSource.PlayOneShot(jumpSE);
            }
            else
            {
                animator.SetBool("isJumping", false);
            }
        }

    }
    private void FixedUpdate()
    {
        if (isDead)
        {
            return;
        }

        switch (moveDirection)
        {
            case MOVE_DIRECTION.STOP:
                speed = 0;
                break;
            case MOVE_DIRECTION.LEFT:
                transform.localScale = new Vector3(-1, 1, 1);
                speed = -3;
                break;
            case MOVE_DIRECTION.RIGHT:
                transform.localScale = new Vector3(1, 1, 1);
                speed = 3;
                break;
        }
        rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);
    }

    //踏んだらプレイヤーをジャンプさせる
    private void jump()
    {
        rigidbody2D.AddForce(Vector2.up * jumpPower);
       
    }
    private bool IsGround()
    {
        return Physics2D.Linecast(transform.position - transform.right * 0.2f, transform.position - transform.up * 0.1f, blockLayer)
            || Physics2D.Linecast(transform.position + transform.right * 0.2f, transform.position - transform.up * 0.1f, blockLayer);
    }

    //プレイヤーを何かが接触したときの処理
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDead)
        {
            return;
        }

        if (collision.CompareTag("Trap"))
        {
            PlayerDeath();
        }

        if (collision.gameObject.tag == "END")
        {
            gameManager.GameClear();
        }

        if (collision.gameObject.tag == "Item")
        {
            collision.gameObject.GetComponent<ItemManager>().GetItem();
            audioSource.PlayOneShot(getItemSE);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            EnemyManager enemy = collision.gameObject.GetComponent<EnemyManager>();
            if (this.transform.position.y + 0.3f > enemy.transform.position.y)
            {
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0);
                jump();
                enemy.DestroyEnemy();
                audioSource.PlayOneShot(stampSE);
            }
            else
            {
                PlayerDeath();
            }
            if (collision.gameObject.tag == "Enemy2")
            {
                EnemyManager2 enemy2 = collision.gameObject.GetComponent<EnemyManager2>();
                if (this.transform.position.y + 0.3f > enemy2.transform.position.y)
                {
                    rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0);
                    jump();
                    enemy2.DestroyEnemy();
                    audioSource.PlayOneShot(stampSE);
                }
                else
                {
                    PlayerDeath();
                }
            }
        }
    }
    //プレイヤーが死亡した際の処理
    void PlayerDeath()
    {
        isDead = true;
        animator.Play("PlayerDeathAnimation");
        rigidbody2D.velocity = new Vector2(0, 0);
        jump();
        BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D>();
        CircleCollider2D circleCollider2D = GetComponent<CircleCollider2D>();
        Destroy(boxCollider2D);
        Destroy(circleCollider2D);
        gameManager.GameOver();
    }
}