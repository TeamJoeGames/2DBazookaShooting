using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMakerScript : MonoBehaviour {

	public GameObject enemyGo;
	public Sprite[] myImages;

	void Start () 
	{
		InvokeRepeating ("makeAnEnemyAction", 0, 3);
	}

	void makeAnEnemyAction ()
	{
		GameObject newEnemyGo = (GameObject)Instantiate (enemyGo) as GameObject;
		float x = Random.Range (-12.75f, 13.0f);
		float y = -5;
		float z = 4;

		newEnemyGo.transform.position = new Vector3 (x, y, z);
		newEnemyGo.GetComponent<SpriteRenderer> ().sprite = myImages [Random.Range(0,myImages.Length)];
		newEnemyGo.GetComponent<Rigidbody2D> ().AddForce (Vector3.up * 500);

	}
	

}
