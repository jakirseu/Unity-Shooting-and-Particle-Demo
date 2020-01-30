using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ufo : MonoBehaviour
{
   
    private ParticleSystem particle;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider2D;
    private AudioSource audioSource;

    public float speed = 2;
 

    private void Awake()
    {
        particle = GetComponentInChildren<ParticleSystem>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();

    }


    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
     
    }

    void OnCollisionEnter2D(Collision2D other)
    {
            Destroy(other.gameObject);
            StartCoroutine(BreakUFO());
       
       
    }

    private IEnumerator BreakUFO()
    {
        particle.Play();
        audioSource.Play();

        spriteRenderer.enabled = false;
        boxCollider2D.enabled = false;

        yield return new WaitForSeconds(particle.main.startLifetime.constantMax);


        Destroy(gameObject);

    }
}
