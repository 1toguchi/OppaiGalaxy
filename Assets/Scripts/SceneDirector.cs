using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDirector : MonoBehaviour {
	//public GameObject sp;
	public GameObject Op;
	public void Opening ()
	{SceneManager.LoadScene ("Oppai");}

	// Update is called once per frame

	void Update () {
		string sceneName = SceneManager.GetActiveScene().name;
		switch (sceneName)
		{
		case "test":
			
			AudioSource bt = GameObject.Find ("BTN").GetComponent<AudioSource> ();
			if (Input.GetMouseButton(0)||Input.GetKey(KeyCode.UpArrow)||Input.GetKey(KeyCode.DownArrow)||Input.GetKey(KeyCode.LeftArrow)||Input.GetKey(KeyCode.RightArrow)) {
				//sp.SetActive (true);
				Op.SetActive (false);
				bt.Play ();
				Invoke ("Opening", 6);
			}



			//if (Opp = false) {
				//TM -= Time.deltaTime;
				//if (TM <= 0) {
					//SceneManager.LoadScene ("Oppai");
			//  || }
				
				break;
		case "Oppai":
			AudioSource ac = GameObject.Find ("BGM").GetComponent<AudioSource> ();


				if (PanelController.BgmLength < ac.time)
				{
				
					StartCoroutine(WaitForAnyTime(1.0f));
				}
			if (Input.GetKey(KeyCode.Space))
			{
				SceneManager.LoadScene ("EndingScene");
			}

				break;


		case "EndingScene":
			if (Input.GetMouseButton(0)||Input.GetKey(KeyCode.UpArrow)||Input.GetKey(KeyCode.DownArrow)||Input.GetKey(KeyCode.LeftArrow)||Input.GetKey(KeyCode.RightArrow))  SceneManager.LoadScene("test");
				break;
			default:
				break;
		}
	}

	IEnumerator WaitForAnyTime(float time)
	{
		yield return new WaitForSeconds(time);
		SceneManager.LoadScene("EndingScene");
	}

}
