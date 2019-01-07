using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawning : MonoBehaviour {

    public GameObject player;
    public GameObject[] trianglePrefebs;
    private Vector3 spawnObstaclePosition;


	
	// Update is called once per frame
	void Update () {
        float distanceToHorizon = Vector3.Distance(player.gameObject.transform.position, spawnObstaclePosition);
        if(distanceToHorizon<=120){
            SpawnTriangles();
        }
	}

    void SpawnTriangles(){
        spawnObstaclePosition = new Vector3(0, 1, spawnObstaclePosition.z + 30);
        Instantiate(trianglePrefebs[(Random.Range(0,trianglePrefebs.Length))], spawnObstaclePosition, Quaternion.identity);
    }
}
