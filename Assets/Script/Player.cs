using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject ground;
    public GameObject sene;

    public float playerSpeed;
    public float leftLimit;
    public float rightLimit;
    public AudioClip scoreUp;
    public AudioClip damage;

	// Use this for initialization
	void Start () {
        leftLimit = (ground.transform.position.x - ground.transform.localScale.x / 2)+(float)0.5;
        Debug.Log(leftLimit);
        rightLimit = (ground.transform.position.x + ground.transform.localScale.x / 2) - (float)0.5;
        Debug.Log(rightLimit);
    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody>().velocity = Vector3.forward * playerSpeed * Time.deltaTime;
        //Mobile Control
        Vector2 touch = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10f));
        if(Input.touchCount>0){
            Debug.Log("touched!");
            if(touch.x<leftLimit){
                transform.position = new Vector3(leftLimit, transform.position.y, transform.position.z);
                //Debug.Log(1);
            }
            else if(touch.x > rightLimit)
            {
                transform.position = new Vector3(rightLimit, transform.position.y, transform.position.z);
                //Debug.Log(2);
            }
            else{
                transform.position = new Vector3(touch.x, transform.position.y, transform.position.z);
                //Debug.Log(3);
            }
        }

        
	}

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "Gap")
        {
            GetComponent<AudioSource>().PlayOneShot(scoreUp, 1.0f);
        }
        if (other.gameObject.tag == "Tri")
        {
            GetComponent<AudioSource>().PlayOneShot(damage, 1.0f);
            sene.GetComponent<AppInit>().Gameover();
            //Score = 0;
        }
    }
}
