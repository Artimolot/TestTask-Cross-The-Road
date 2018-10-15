using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
	public static UI Instance;

	private void Awake()
	{
		if(Instance == null)
		{
			Instance = this;
		}
	}

	public Text textScore;
	public GameObject buttonRestart;


	public void RestartGame()
	{
		Application.LoadLevel("Game");
	}
}
