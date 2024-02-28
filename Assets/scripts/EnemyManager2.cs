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
        // �ڕW�I�u�W�F�N�g�������Ă���
        targetObject = GameObject.Find(targetObjectName);
        // �d�͂�0�ɂ��āA�Փˎ��ɉ�]�����Ȃ�
        rbody = GetComponent<Rigidbody2D>();
        rbody.gravityScale = 0;
        rbody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }


    //���j�A�j���[�V�����y�уQ�[���I�u�W�F�N�g������
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

        { // �����ƍs���i��莞�Ԃ��ƂɁj
          // �ڕW�I�u�W�F�N�g�̕����𒲂ׂ�
            Vector3 dir = (targetObject.transform.position - this.transform.position).normalized;
            // ���̕����֎w�肵���ʂŐi��
            float vx = dir.x * speed;
            float vy = dir.y * speed;
            rbody.velocity = new Vector2(vx, vy);
            // �ړ��̌����ō��E�Ɍ�����ς���
            this.GetComponent<SpriteRenderer>().flipX = (vx < 0);
        }
    }

}
  
