using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //[SerializeField] GameManager gameManager;

    [SerializeField] LayerMask blockLayer;
    [SerializeField] GameObject deathEffect;
    Rigidbody2D rigidbody2D;
    float speed = 0;

    //�E�A���A�~�܂�
    public enum MOVE_DIRECTION
    {
        STOP,
        LEFT,
        RIGHT,
    }
    //�����o���͉E������
    MOVE_DIRECTION moveDirection = MOVE_DIRECTION.RIGHT;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(!IsGround())
        {
            ChangeDirection();
        }
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
    }
    
    bool IsGround()
    {
        Vector3 startVec = transform.position + transform.right * 0.5f * transform.localScale.x;
        Vector3 endVec = startVec - transform.up * 0.5f;
        Debug.DrawLine(startVec, endVec);
        return Physics2D.Linecast(startVec, endVec, blockLayer);  
    }

    void ChangeDirection()
    {
        if (moveDirection == MOVE_DIRECTION.RIGHT)
        {
            // ���Ɉړ�
            moveDirection = MOVE_DIRECTION.LEFT;
        }
        else
        {
            // �E�Ɉړ�
            moveDirection = MOVE_DIRECTION.RIGHT;
        }
    }
    //���j�A�j���[�V�����y�уQ�[���I�u�W�F�N�g������
    public void DestroyEnemy()
    {
        Instantiate(deathEffect, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);
    }
}