using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forever_Rotate2 : MonoBehaviour
{

	public float angle = 90; // �p�x�FInspector�Ŏw��

	void FixedUpdate()
	{ // �����ƍs���i��莞�Ԃ��ƂɁj
		this.transform.Rotate(0, 0, angle / 30);    // ��]����
	}
}