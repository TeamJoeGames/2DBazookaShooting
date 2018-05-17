 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayScript : MonoBehaviour 
{
	public GameObject gameOverPanel;

	public ParticleSystem muzzleFlashPar;

	AudioSource gunShotAudioSource;
	public AudioClip gunShptClip;

	public GameObject timerTextView;


	public GameObject scoreTextView;
	int roundsShot = 0;
	int enemyKilled = 0;



	public GameObject bazookaGo;
	public GameObject crossHairGo;




	bool gameIsPaused = false;

	public int gameTime = 150;
	int timeMinutes;
	int timeSeconds;


	// Use this for initialization
	void Start () 
	{
		scoreTextView.GetComponent<Text> ().text = enemyKilled.ToString () + " / " + roundsShot.ToString ();

		gunShotAudioSource = gameObject.GetComponent<AudioSource> ();
		InvokeRepeating ("timeCounterAction", 0, 1);
	}




	void timeCounterAction ()
	{
		if (gameTime > 0) {
			
			timeMinutes = (int)(gameTime / 60);
			timeSeconds = gameTime % 60;


			string timerTextString = timeMinutes.ToString ("D1") + "\' " + timeSeconds.ToString ("D2") + "\"";
			timerTextView.GetComponent<Text> ().text = timerTextString;
			gameTime = gameTime - 1;
		} 
		else
		{
			//this is game over
			Time.timeScale = 0;
			gameIsPaused = true;
			gameOverPanel.GetComponent<CanvasGroup> ().alpha = 1;
			gameOverPanel.GetComponent<CanvasGroup> ().interactable = true;
			gameOverPanel.GetComponent<CanvasGroup> ().blocksRaycasts = true;
		}
			
	}
		



	void shootAction ()
	{
		gunShotAudioSource.PlayOneShot (gunShptClip);
		muzzleFlashPar.Emit (1);
	
		roundsShot = roundsShot + 1;


		Vector2 dir = new Vector2 (crossHairGo.transform.position.x, crossHairGo.transform.position.y);
		RaycastHit2D hit = Physics2D.Raycast (Camera.main.transform.position, dir);
			
		if (hit.collider != null && hit.collider.gameObject != crossHairGo) 
		{
			enemyKilled++;
			Destroy (hit.collider.gameObject);
		
		}
		scoreTextView.GetComponent<Text> ().text = enemyKilled.ToString () + "/" +  roundsShot.ToString();


			
	}





	// Update is called once per frame
	void Update () 
	{
		if (!gameIsPaused) {

			if (Input.GetKeyUp (KeyCode.Space)) 
			{
				shootAction ();
			}
		
			bazookaGo.transform.LookAt (crossHairGo.transform);

			float h = Input.GetAxis ("Mouse X") / 3;
			float v = Input.GetAxis ("Mouse Y") / 3;

			Vector3 crossHairMov = new Vector3 (h, v, 0);
			crossHairGo.transform.Translate (crossHairMov);


			float x = crossHairGo.transform.position.x;
			float y = crossHairGo.transform.position.y;

			if (x > 9)
				x = 9;
			if (x < -9)
				x = -9;

			if (y > 5)
				y = 5;
			if (y < -5)
				y = -5;

			crossHairGo.transform.position = new Vector3 (x, y, 0);
		}
	}

	public void RestartAction()
	{
		//this is game restart
		Time.timeScale = 1;
		gameIsPaused = false;
		gameOverPanel.GetComponent<CanvasGroup> ().alpha = 0;
		gameOverPanel.GetComponent<CanvasGroup> ().interactable = false;
		gameOverPanel.GetComponent<CanvasGroup> ().blocksRaycasts = false;

		gameTime = 5;
		enemyKilled = 0;
		roundsShot = 0;
		scoreTextView.GetComponent<Text> ().text = enemyKilled.ToString () + "/" +  roundsShot.ToString();
		timeCounterAction ();

	}
}
