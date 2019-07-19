using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private int count;
    private int lives;
    public Text countText;
    public Text winText;
    public Text lifeText;
    public Text loseText;
    public float speed;
    public float jumpForce;
    public AudioSource tick;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        lives = 3;
        winText.text = "";
        loseText.text = "";
        SetCountText();
        SetLivesText();
        tick = GetComponent<AudioSource> ();
    }
    void Update()
    {

    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0);
        rb2d.AddForce(movement * speed);
        if (Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();}
    }

     void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            if(Input.GetKey(KeyCode.UpArrow))
            {
                rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse); 
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag ("Pick Up"))
        {
            other.gameObject.SetActive (false);
            count = count + 1;
            SetCountText();
            NextLevel();
        }
        if (other.gameObject.CompareTag("Enemy Pick Up"))
        {
            other.gameObject.SetActive (false);
            lives = lives - 1;
            SetCountText();
            SetLivesText();
        }

    }
    void SetCountText()    
    {
        countText.text = "Score: " + count.ToString ();
        if (count >= 8)
        {
            winText.text = "You Win!";
            tick.Play();
        }
    }
    void SetLivesText()
    {
        lifeText.text = "Lives: " + lives.ToString ();
        if (lives <= 0)
        {
            loseText.text = "You Lose...";
            gameObject.SetActive(false);
        }
    }
    void NextLevel()
    {
        if (count == 4)
        {
         transform.position = new Vector3 (23.68f,0,0);
        }
    }
}