using UnityEngine;

public class EnemyManager2 : MonoBehaviour
{
    //[SerializeField] GameManager gameManager;
    public string targetObjectName;

    [SerializeField] LayerMask blockLayer;
    [SerializeField] GameObject deathEffect;
    Rigidbody2D rigidbody2D;
    GameObject targetObject;
    Rigidbody2D rbody;
    float speed = 0;


    //右、左、止まる
    public enum MOVE_DIRECTION
    {
        STOP,
        LEFT,
        RIGHT,
    }
    //動き出しは右側から
    MOVE_DIRECTION moveDirection = MOVE_DIRECTION.RIGHT;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        // 目標オブジェクトを見つけておく
        targetObject = GameObject.Find(targetObjectName);
        // 重力を0にして、衝突時に回転させない
        rbody = GetComponent<Rigidbody2D>();
        rbody.gravityScale = 0;
        rbody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }


    //爆破アニメーション及びゲームオブジェクトを消去
    public void DestroyEnemy()
    {
        Instantiate(deathEffect, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);
    }



private void FixedUpdate()
    {
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

        { // ずっと行う（一定時間ごとに）
          // 目標オブジェクトの方向を調べて
            Vector3 dir = (targetObject.transform.position - this.transform.position).normalized;
            // その方向へ指定した量で進む
            float vx = dir.x * speed;
            float vy = dir.y * speed;
            rbody.velocity = new Vector2(vx, vy);
            // 移動の向きで左右に向きを変える
            this.GetComponent<SpriteRenderer>().flipX = (vx < 0);
        }
    }

}
  
