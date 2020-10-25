using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeatContant : MonoBehaviour {

	public GameObject explosion;//เอฟเฟคระเบิด
	public GameObject playerExplosion;
	private GameController gameController;
	public int health = 100;

	public int scoreValus;

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

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Boudery") {
			return;
		}

		Instantiate (explosion, transform.position, transform.rotation);

		if (other.tag == "Player")
		{
		Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
		gameController.GameOver ();
		Destroy (gameObject);//ลบตัวเอง	
		Destroy (other.gameObject);//ลบของที่ชน

		}


		if (other.tag == "Boit") // กระสุนปืนเหลือง
        {
			Instantiate (explosion, transform.position, transform.rotation);
			Destroy (gameObject);//ลบตัวเอง	
			Destroy (other.gameObject);//ลบของที่ชน
			gameController.AddScore (scoreValus);
		}
	}


	}
