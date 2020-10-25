using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour {
	public int maxHealth = 100;
	public int currentHealth;
	public int health = 100;
	public HealthBar healthBar;
	public bool isInvulnerable = false;
	public GameObject explosion;//เอฟเฟคระเบิด
	private GameController gameController;

	// Use this for initialization
	void Start () 
	{
		currentHealth = maxHealth;
		healthBar.SetMaxHealth (maxHealth);
	}
		
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag( "Hin")) 
		{
			TakeDamageHp (50);
            if (health <= 0)
            {
                Destroy(this.gameObject);
            }
        }
		
	}

	void TakeDamageHp(int damage)
	{
		currentHealth -= damage;
		healthBar.SetHealth (currentHealth);
	}

	public void Damage(int damage)
	{
		if (isInvulnerable)
			return;
		health -= damage;
		StartCoroutine (DamagePlayer ());
		if (health <= 0)
		{
			Destroy (this.gameObject);
			{
				string Deat = PlayerDeat (maxHealth);
				print (Deat);
			}
		}
	}

	string PlayerDeat(int DeatPlayer)
	{
		DeatPlayer = maxHealth;
		{
			GameObject Deatexplosion = Instantiate (explosion, transform.position,Quaternion.identity);
			gameController.GameOver ();
			Destroy (this.gameObject);//ลบตัวเอง	
		}
		return"DeatPlayer";

	}

	IEnumerator DamagePlayer() //กระพิบๆเมื่อโดนสิ่งกีดขวาง
	{
		SpriteRenderer[] srs = GetComponentsInChildren<SpriteRenderer> ();

		for (int i = 0; i < 3; i++) 
		{
			foreach (SpriteRenderer sr in srs)
			{
				Color c = sr.color;
				c.a = 0;
				sr.color = c;
			}

			yield return new WaitForSeconds (.1f);

			foreach (SpriteRenderer sr in srs)
			{
				Color c = sr.color;
				c.a = 1;
				sr.color = c;
			}
			yield return new WaitForSeconds (.1f);
		}

	}
}
