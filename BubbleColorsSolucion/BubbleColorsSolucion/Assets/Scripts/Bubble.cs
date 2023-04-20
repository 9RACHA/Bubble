using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour {
    private float speed = 8f;
    private Vector3 velocity;
    private bool anchored;

    public List<Sprite> sprites;
    public GameObject pointsPrefab;
    public AudioClip mismoColor;
    public AudioClip distintoColor;
    private AudioSource audioSource;
    private int spriteIndex;
    public int SpriteIndex { get { return spriteIndex; } }

    // Start is called before the first frame update
    void Start() {
        spriteIndex = Random.Range(0, sprites.Count);
        GetComponentInChildren<SpriteRenderer>().sprite = sprites[spriteIndex];
        velocity = Vector3.zero;
        audioSource = Camera.main.GetComponent<AudioSource>();
    }

    void FixedUpdate() {
        transform.position += velocity * Time.fixedDeltaTime;        
    }

    public void Launch(Vector3 velocityDirection) {
        velocity = velocityDirection * speed;
    }

    void OnCollisionEnter2D(Collision2D other) {
        velocity.x = -velocity.x;
        if(other.gameObject.CompareTag("Ball") && !anchored) {
            velocity = Vector3.zero;
            transform.position = Grid.NearestGridPoint(transform.position);

            if(other.gameObject.GetComponent<Bubble>().SpriteIndex == this.spriteIndex) {
                //Mesma cor, mostramos os 100 puntos
                Instantiate(pointsPrefab, transform.position + Vector3.back, Quaternion.identity);
                audioSource.PlayOneShot(mismoColor);
            } else {
                audioSource.PlayOneShot(distintoColor);
            }
            anchored = true;
        }

        if(other.gameObject.CompareTag("Roof") && !anchored) {
            velocity = Vector3.zero;
            transform.position = Grid.NearestGridPoint(transform.position);
            anchored = true;
        }

        if(other.gameObject.CompareTag("Bullet")) {
            Destroy(gameObject);
        }
    }
}
