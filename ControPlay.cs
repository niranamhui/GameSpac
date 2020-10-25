using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]
//public class Boundary
//{
//	public float xMin , xMax , zMin , zMax;
//}

public class ControPlay : MonoBehaviour {

	private Rigidbody rb;
	public float speed;
	public float titl;//องศาการเอียงยาน
	public GameObject shot;//แทนกระสุน
	public Transform shotSpawn;//แทนตำแหน่ง
	public float fireRate;//ตัวรั้งเวลาการยิง
	private float nextFire;//เวลาที่เราจะยิงนัดต่อไปได้
	public static int bulletype;
	public float speedbullet;


	//public Boundary boundary;
	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal,0.0f,moveVertical);
		rb.velocity = movement * speed; //เคลื่อนที่ตามความเร็ว
		//กำหนดขอบเขตการบิน
		rb.position = new Vector3 
		(

				//x
			Mathf.Clamp(rb.position.x,-9,9),	
				//y
			0.0f,
				//z
			Mathf.Clamp(rb.position.z,-1,7)
		);

		rb.rotation = Quaternion.Euler(0.0f,0.0f,rb.velocity.x*-titl);
	}

	void Update()
	{
		if (Input.GetKey(KeyCode.Space) && Time.time > nextFire && bulletype == 0) 
		{
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);//เพิ่มวัตถุ
			//GetComponent<AudioSource>().Play();
		}
		if (bulletype == 1 && Input.GetKey(KeyCode.Space) && Time.time > nextFire) 
		{
			Bullet1 ();
			nextFire = Time.time + fireRate;
		}
	}

	void Bullet1()
	{
		GameObject Bullet1 = Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		GameObject Bullet2 = Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		GameObject Bullet3 = Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		Bullet1.GetComponent<Rigidbody>().velocity = transform.forward * speedbullet;
		Bullet2.GetComponent<Rigidbody> ().velocity = new Vector3 (speedbullet, 0f, speedbullet);
		Bullet3.GetComponent<Rigidbody> ().velocity = new Vector3 (-speedbullet, 0f, speedbullet);
	}

}
