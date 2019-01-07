using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public GameObject player;
    public int cameraDistance;

	
	// Update is called once per frame
	void LateUpdate () {
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, player.transform.position.z - cameraDistance), Time.deltaTime * 100);
        
	}
}
