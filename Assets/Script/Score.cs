using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour {

    public int score = 0;
    public bool trigger = false;
    public TextMeshProUGUI scoreUI;


    void Update()
    {
        scoreUI.text = score.ToString();
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
