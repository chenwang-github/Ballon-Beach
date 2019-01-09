using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AppInit : MonoBehaviour {

    public GameObject inMenuUI;
    public GameObject inGameUI;
    public GameObject gameOverUI;
    public GameObject player;
    private bool hasGameStarted = false;


    void Awake()
    {
        Shader.SetGlobalFloat("_Curvature", 2.0f);
        Shader.SetGlobalFloat("_Trimming", 0.1f);
        Application.targetFrameRate = 60;
    }

    // Use this for initialization
    void Start () {
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        inMenuUI.gameObject.SetActive(true);
        inGameUI.gameObject.SetActive(false);
        gameOverUI.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Gameover()
    {
        inMenuUI.gameObject.SetActive(false);
        inGameUI.gameObject.SetActive(false);
        gameOverUI.gameObject.SetActive(true);
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        hasGameStarted = false;
    }

    public void Restart(){
        SceneManager.LoadScene(0);
        StartCoroutine(StartGame(1.0f));
    }

    public void PlayButton(){
        if(hasGameStarted == true){
            StartCoroutine(StartGame(1.0f));
        }else{
            StartCoroutine(StartGame(0.0f));
            hasGameStarted = true;
        }
    }

    public void ShowAd(){
        //showAd
        StartCoroutine(StartGame(1.0f));
    }

    public void PauseButton(){
        inMenuUI.gameObject.SetActive(true);
        inGameUI.gameObject.SetActive(false);
        gameOverUI.gameObject.SetActive(false);
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
    }

    IEnumerator StartGame(float waitTime){
        inMenuUI.gameObject.SetActive(false);
        inGameUI.gameObject.SetActive(true);
        gameOverUI.gameObject.SetActive(false);
        yield return new WaitForSeconds(waitTime);
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;

    }
}
