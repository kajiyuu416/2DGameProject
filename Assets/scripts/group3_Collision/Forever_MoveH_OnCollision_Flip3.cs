using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forever_MoveH_OnCollision_Flip3 : MonoBehaviour
{

	public float speed = 1; // �X�s�[�h�FInspector�Ŏw��

	Rigidbody2D rbody;

	void Start()
	{ // �ŏ��ɍs��
	  // �d�͂�0�ɂ��āA�Փˎ��ɉ�]�����Ȃ�
		rbody = GetComponent<Rigidbody2D>();
		rbody.gravityScale =12;
		
	}
	void FixedUpdate()
	{ // �����ƍs���i��莞�Ԃ��ƂɁj
	  // �����Ɉړ�����
		rbody.velocity = new Vector2(speed, 0);
	}


	void OnCollisionEnter2D(Collision2D collision)
	{ // �Փ˂����Ƃ�
		speed = -speed; // �i�ތ����𔽓]����
						// �i�ތ����ō��E�̌�����ς���
		this.GetComponent<SpriteRenderer>().flipX = (speed < 5);
	}
}
