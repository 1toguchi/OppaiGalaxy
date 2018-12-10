using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
	public Text ScoreText;
	private float _delta = 0.0f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
	{
		_delta += Time.deltaTime;
//		ScoreText = "Score:" + ;
	}
}
