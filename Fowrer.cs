using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fowrer : MonoBehaviour {
	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		GetComponent<Rigidbody> ().velocity = new Vector3( 0.5f,0f,2f);
	}
}
