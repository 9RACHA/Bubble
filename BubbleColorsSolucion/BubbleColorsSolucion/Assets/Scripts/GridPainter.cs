using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPainter : MonoBehaviour {
    public GameObject beaconPrefab;
    // Start is called before the first frame update
    void Start() {
        SpawnGridBeacons();        
    }

    private void SpawnGridBeacons() {
        /* 
        for(float x = -10; x < 5; x+=0.5f) {
            for(float y = 5; y >-1; y-=0.3f) {
                Vector3 point = new Vector3 (x, y, 0.5f);
                Instantiate(beaconPrefab, Grid.NearestGridPoint(point), Quaternion.identity);
            }
        }
        */

        Vector3 gridPoint;
        for(int i=-5; i<5; i++) {
            for(int j=0; j<10; j++) {
                gridPoint =  Grid.GridPoint(i, j);
                if(gridPoint.x != Mathf.Infinity) {
                    gridPoint.z = 0.5f;
                    Instantiate(beaconPrefab, gridPoint, Quaternion.identity).transform.parent = transform;
                }
            }
        }
        
/*
        Instantiate(beaconPrefab, Grid.NearestGridPoint(Vector3.up*4), Quaternion.identity);
        Instantiate(beaconPrefab, Grid.NearestGridPoint(Vector3.up*4 + Vector3.right * 0.5f * 1), Quaternion.identity);
        Instantiate(beaconPrefab, Grid.NearestGridPoint(Vector3.up*4 + Vector3.right * 0.5f * 2), Quaternion.identity);
        */
    }
}
