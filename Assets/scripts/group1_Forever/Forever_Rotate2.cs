using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forever_Rotate2 : MonoBehaviour
{

	public float angle = 90; // 角度：Inspectorで指定

	void FixedUpdate()
	{ // ずっと行う（一定時間ごとに）
		this.transform.Rotate(0, 0, angle / 30);    // 回転する
	}
}