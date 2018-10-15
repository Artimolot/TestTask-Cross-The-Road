using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public bool onMove = true;

	void Update()
	{
		if (onMove)
		{
			gameObject.transform.position = new Vector3(transform.position.x + (2f * Time.deltaTime), transform.position.y, transform.position.z);
		}
	}
}
