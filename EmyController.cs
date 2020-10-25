using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmyController : MonoBehaviour {

	public float speed;
	GameObject player;
	private Rigidbody rb;
	public float tilt;
	public GameObject emyBolt;
	public float startshooting;
	public float loopshooting;
	private GameController gameController;
	public GameObject playerExplosion;//เอฟเฟคระเบิด

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


		rb = GetComponent<Rigidbody> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		InvokeRepeating ("OnShooting",startshooting,loopshooting);


	}

	void OnShooting()
	{
		Instantiate (emyBolt,transform.position, Quaternion.identity);
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (player != null) 
		{
			float moveX = 0f;

			//ถ้าผู้เล่นมีแกนxมากกว่า
			if (Mathf.Round (player.transform.position.x) > Mathf.Round (transform.position.x)) 
			{
				moveX = 1f;
			}
			else if (Mathf.Round (player.transform.position.x) < Mathf.Round (transform.position.x)) 
			{
				moveX = -1f;
			}
			rb.velocity = new Vector3 (moveX, 0f, -1f) * speed;
			rb.rotation = Quaternion.Euler (0f, 180f, rb.velocity.x * tilt);
		}
	}

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
