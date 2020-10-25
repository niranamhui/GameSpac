using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emyboilcontro : MonoBehaviour {
	public GameObject playerExplosion;//เอฟเฟคระเบิด
	private GameController gameController;

	// Use this for initialization
	void Start ()
	{

		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");

		if (gameControllerObject != null) 
		{
			gameController = gameControllerObject.GetComponent<GameController>();
		}
		if (gameControllerObject == null) 
		{
			Debug.Log ("Cannot find 'gameController' script");
		}
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider other)
	{
		
		if (other.tag == "Player")
		{
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);

			gameController.GameOver ();
			Destroy (gameObject);//ลบตัวเอง	
			Destroy (other.gameObject);//ลบของที่ชน

		}


	}
}
