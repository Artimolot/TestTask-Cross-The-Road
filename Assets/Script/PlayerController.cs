using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	private int point = 0;
	public GameObject particle;

	private void Update()
	{
#if UNITY_EDITOR
		if (Input.GetKeyDown(KeyCode.W))
		{
			MovePlayer();
		}
#else
		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);
			if(touch.phase == TouchPhase.Began)
			{
				MovePlayer();
			}
		}
#endif
		if (!gameObject.GetComponent<Renderer>().IsVisibleFrom(Camera.main))
		{
			Camera.main.GetComponent<CameraController>().onMove = false;
			UI.Instance.buttonRestart.SetActive(true);
			Destroy(this.gameObject);
		}
		
	}

	private void MovePlayer()
	{
		gameObject.transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
		point++;
		UI.Instance.textScore.text = "Score: " + point;
	}

	private void OnCollisionEnter(Collision collision)
	{
		Camera.main.GetComponent<CameraController>().onMove = false;
		Instantiate(particle, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(-90,0,0));
		UI.Instance.buttonRestart.SetActive(true);
		Destroy(this.gameObject);
	}	
}

