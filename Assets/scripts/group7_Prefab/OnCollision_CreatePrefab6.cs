using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision_CreatePrefab6 : MonoBehaviour
{

	public string targetObjectName; // �ڕW�I�u�W�F�N�g���FInspector�Ŏw��
	public GameObject newPrefab;    // ���v���n�u�FInspector�Ŏw��

	void OnCollisionEnter2D(Collision2D collision)
	{ // �Փ˂����Ƃ�
	  // �����A�Փ˂������̖̂��O���ڕW�I�u�W�F�N�g��������
		if (collision.gameObject.name == targetObjectName)
		{
			// �Փˈʒu�Ƀv���n�u�����
			GameObject newGameObject = Instantiate(newPrefab) as GameObject;
			Vector3 pos = collision.contacts[0].point;
			pos.y = 1; // ��O�ɕ\��
			newGameObject.transform.position = pos;
		}
	}
}