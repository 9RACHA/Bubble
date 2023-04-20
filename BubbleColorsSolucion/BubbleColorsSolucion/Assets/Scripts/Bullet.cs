using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    private float speed = 10f;
    
    void FixedUpdate() {
        transform.position += transform.up * speed * Time.fixedDeltaTime;        
    }

    void OnCollisionEnter2D(Collision2D other) {
        Destroy(gameObject);
    }
}
