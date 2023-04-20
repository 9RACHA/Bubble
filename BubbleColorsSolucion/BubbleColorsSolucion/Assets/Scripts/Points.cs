using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour {
    void OnPointsAnimationFinished() {
        Destroy(gameObject, 1.5f);
    }
}
