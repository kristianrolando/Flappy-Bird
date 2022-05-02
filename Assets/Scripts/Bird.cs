using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    Rigidbody2D rb;
    GameManager gm;

    [SerializeField] float jumpForce;
    [SerializeField] GameObject tutorial;

    [SerializeField] AudioSource jumpSound;
    [SerializeField] AudioSource hitSound;
    [SerializeField] AudioSource scoreSound;

    [HideInInspector] public bool isPlayed;
    [HideInInspector] public bool isDie;
    


    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        gm = GameObject.Find("Main Camera").GetComponent<GameManager>();
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }
    
    private void Jump()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            tutorial.SetActive(false);
            rb.gravityScale = 1;
            isPlayed = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpSound.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Score")
        {
            gm.ScoreIncrement();
            scoreSound.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            isDie = true;
            hitSound.Play();
            Time.timeScale = 0f;
        }
    }

}
