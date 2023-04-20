using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotDirection : MonoBehaviour {
    

    public GameObject cannon;
    public GameObject arrow;

    private float rotationSpeed = 60f;

    private int rotationDirection = 0;

    private Quaternion startRotation;

    void Start() {
        startRotation = transform.rotation;
    }


    void Update() {
        float rotationSlowDownFactor = 1;
        if(Input.GetKey(KeyCode.LeftShift)) {
            rotationSlowDownFactor = 0.2f;
        }
        if(Input.GetKey(KeyCode.LeftArrow) && rotationDirection >= 0) {
            rotationDirection = 1;
        } else if(Input.GetKey(KeyCode.RightArrow) && rotationDirection <= 0) {
            rotationDirection = -1;
        } else {
            rotationDirection = 0;
        }
    }

  
    void FixedUpdate() {
        transform.Rotate(transform.forward * rotationSpeed * rotationDirection * Time.fixedDeltaTime);
        if(transform.localEulerAngles.z > 80 && transform.localEulerAngles.z < 180 ) {
            Vector3 rotation = transform.localEulerAngles;
            rotation.z = 80;
            transform.localEulerAngles = rotation;
        }
        if(transform.localEulerAngles.z < 280 && transform.localEulerAngles.z > 180 ) {
            Vector3 rotation = transform.localEulerAngles;
            rotation.z = 280;
            transform.localEulerAngles = rotation;
        } 
    }

    public void ChangeTool(Launcher.LauncherTool wichTool) {
        cannon.SetActive(wichTool == Launcher.LauncherTool.Cannon);
        arrow.SetActive(wichTool != Launcher.LauncherTool.Cannon);
        transform.rotation = startRotation;
    }
}
