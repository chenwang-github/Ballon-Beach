using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour {

    public int score = 0;
    public int highestScore = 0;
    public bool trigger = false;
    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI highestScoreUI;

    void Start()
    {
        highestScore = PlayerPrefs.GetInt("highestScore");
    }

    void Update()
    {
        if(score > highestScore){
            highestScore = score;
            PlayerPrefs.SetInt("highestScore", highestScore);
        }
        scoreUI.text = score.ToString();
        highestScoreUI.text = PlayerPrefs.GetInt("highestScore").ToString();
    }

    private void OnTriggerExit(Collider other)
    {
        trigger = !trigger;
        if (other.gameObject.tag == "Tri")
        {
            Debug.Log("GameOver");
        }
        if (trigger)
        {
            if (other.gameObject.tag == "Gap")
            {
                score++;
                Debug.Log(score);
            }
        }
    }
}
