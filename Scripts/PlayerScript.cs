using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D RD2D;
    public float speed;
    public Text score;
    private int scoreValue = 0;
    public Text winText;
    private int lives = 3;
    public Text loseText;
    public Text life;

    // Start is called before the first frame update
    void Start()
    {
        RD2D = GetComponent<Rigidbody2D>();
        score.text = scoreValue.ToString();
        life.text = lives.ToString();
    }

    private void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        RD2D.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Coin")
        {
            scoreValue += 1;
            score.text = scoreValue.ToString();
            if (scoreValue >= 8)
            {
                winText.text = "You Win! Game Made By Cameron Howell.";
            }

            Destroy(collision.collider.gameObject);
        }

        if (collision.collider.tag == "Enemy")
        {
            lives -= 1;
            life.text = lives.ToString();
            if (lives <= 0)
            {
                loseText.text = "You Lose! Game Made By Cameron Howell.";
            }

            Destroy(collision.collider.gameObject);
        }

        if (scoreValue == 4)
        {
            transform.position = new Vector2(58.0f, 0.0f);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.W))
            {
                RD2D.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
            }
        }
    }
}
