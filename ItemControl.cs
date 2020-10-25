using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemControl : MonoBehaviour {
	public int TypeBullet;
	// Use this for initialization
	private void  OnTriggerEnter(Collider Item)
	{
		if (Item.gameObject.tag == "Player") 
		{
			ControPlay.bulletype = TypeBullet;
			Destroy(this.gameObject);
		}
	}
}
