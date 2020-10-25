using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public GameObject hazard;
	public GameObject EmyObj;
	public int hazardCount;
	public float spawnWaite;
	public Vector3 spawnValues;
	public float waveWaite;
	public float startwaveWaite;

	public Text ScoreText;
	public Text gameOverTxet;
	public Text RestartTxet;

	private int score;
	private bool gameOver;
	private bool Restart;

	// Use this for initialization
	void Start () 
	{
		gameOver = false;
		Restart = false;

		gameOverTxet.text = "";
		RestartTxet.text = "";

		score = 0;


		StartCoroutine(SpawnWaves());	

		InvokeRepeating ("AddEmy", 2f, 5f);
	}
	void AddEmy()
	{
		if (gameOver == false) {
			Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
			Instantiate (EmyObj, spawnPosition, Quaternion.identity);
		}
		else 
		{
			CancelInvoke ("AddEmy");
		}
	}

	public void AddScore(int newScoreValus)
	{
		score += newScoreValus;
	}

	void UpScore()
	{
		ScoreText.text ="Score:" +score.ToString();
	}


	public void GameOver()
	{
		gameOverTxet.text = "Game Over";
		gameOver = true;
	}



	void Update()
	{
		UpScore();
		if (gameOver) 
		{
			Restart = true;
			RestartTxet.text = "Press 'R' for Resart";
			ControPlay.bulletype = 0;

		}

		if (Restart) 
		{
			if (Input.GetKeyDown(KeyCode.R)) 
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}

	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds (startwaveWaite);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);

				yield return new WaitForSeconds (spawnWaite);
			}
			yield return new WaitForSeconds (waveWaite);
		}

	}
}
