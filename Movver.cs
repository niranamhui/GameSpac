using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movver : MonoBehaviour {

	public float speed;
	// Use this for initialization
	void Start () 
	{
		if (ControPlay.bulletype == 0)
		{
			GetComponent<Rigidbody> ().velocity = transform.forward * speed;
		}
	}

}
