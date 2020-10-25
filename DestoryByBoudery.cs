using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryByBoudery : MonoBehaviour {

	void OnTriggerExit(Collider other)
	{
		Destroy (other.gameObject);
	}
}
