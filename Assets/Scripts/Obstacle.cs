using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private int rejectionForce;
    [SerializeField] private ParticleSystem particleSystem;
    // Start is called before the first frame update
    void Start()
    {
        particleSystem = GetComponentInChildren<ParticleSystem>();
        particleSystem.Stop();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            var player = collision.GetComponent<Player>();
            player.GetHit(damage);
            StartCoroutine(DestroyObstacle());
           
        }
    }

    IEnumerator DestroyObstacle()
    {
        particleSystem.Play();
        var collider = GetComponent<Collider2D>();
        collider.enabled = false;
        var image = GetComponent<SpriteRenderer>();
        image.enabled = false;
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
}
