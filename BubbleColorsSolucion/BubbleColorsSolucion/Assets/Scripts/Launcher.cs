using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour {
    public Transform spawnPoint;
    public enum LauncherTool { Arrow, Cannon };

    public GameObject bubblePrefab;
    public GameObject bulletPrefab;
    public ShotDirection shotDirection;

    private Bubble spawnedBubble;
    private LauncherTool activeTool;
    // Start is called before the first frame update
    void Start() {
        SpawnBubble();
        activeTool = LauncherTool.Arrow;
        shotDirection.ChangeTool(activeTool);
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            if(activeTool == LauncherTool.Arrow) {
                LaunchBubble();
            } else {
                LaunchBullet();
            }
        }
        
    }

    public void ChangeTool(LauncherTool newTool) {
        activeTool = newTool;
        shotDirection.ChangeTool(activeTool);
        if(activeTool == LauncherTool.Cannon) {
            if(spawnedBubble != null) {
                Destroy(spawnedBubble.gameObject);
            }
        } else {
            SpawnBubble();
        }

    }

    private void SpawnBubble() {
        if(spawnedBubble != null) {
            return;
        }
        GameObject bubbleGO = Instantiate(bubblePrefab,  transform.position + 2*Vector3.back, Quaternion.identity);
        spawnedBubble = bubbleGO.GetComponent<Bubble>();
    }

    private void LaunchBubble() {
        if(spawnedBubble != null) {
            spawnedBubble.Launch(shotDirection.transform.up);
            spawnedBubble = null;
            Invoke("SpawnBubble" , 1f);
        }
    }

    private void LaunchBullet() {
        Instantiate(bulletPrefab, spawnPoint.position,  shotDirection.transform.rotation);
    }


}
