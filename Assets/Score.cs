using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	private float score = 0.0f;
	private int difficulty = 1;
	private int maxDifficulty = 10;
	private int scoreForNextDifficulty = 10;
	public Text scoreText;
	private bool isDead = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isDead)
			return;
		if (score >= scoreForNextDifficulty)
			LevelUp();
		score += Time.deltaTime * difficulty;
		scoreText.text = ((int)score).ToString();
		
	}
	void LevelUp() 
	{
		if (difficulty == maxDifficulty)
			return;
		difficulty++;
		scoreForNextDifficulty *= 2;
		GetComponent<Movement>().SetSpeed(difficulty);
	}

	public void OnDeath()
	{
		isDead = true;
	}

}
