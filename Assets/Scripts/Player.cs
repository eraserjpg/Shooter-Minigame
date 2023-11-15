using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject explosionPrefab;
    public float playerSpeed;
    private float horizontalScreenLimit = 10f;
    private float verticalScreenLimit = 4f;
    public int lives;
    public int shield;
    public TMPro.TextMeshProUGUI livesText;
    public TMPro.TextMeshProUGUI shieldText;
    public PowerUp_Health powerUp_HealthScript;
    public PowerUp_Shield powerUp_ShieldScript;

    // Start is called before the first frame update
    void Start()
    {
        playerSpeed = 6f;
        lives = 3;
        shield = 0;
        livesText = GameObject.Find("GameManager").GetComponent<GameManager>().livesText;
        livesText.text = "Lives: " + lives;
        shieldText = GameObject.Find("GameManager").GetComponent<GameManager>().shieldText;
        shieldText.text = "Shield: " + shield;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Shooting();
    }

    void Movement()
    {
        transform.Translate(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * Time.deltaTime * playerSpeed);
        if (transform.position.x > horizontalScreenLimit || transform.position.x <= -horizontalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x * -1f, transform.position.y, 0);
        }
        if (transform.position.y < -verticalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x, -verticalScreenLimit, 0);
        }
        else if (transform.position.y >= 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
    }

    void Shooting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }
    public void GainLife()
    {
        lives += 1;
        livesText.text = "Lives: " + lives;
        if (lives >= 3)
        {
            //keeps live at 3
            lives = 3;
            livesText.text = "Lives: " + lives;
        }

    }
    public void LoseLife()
    {
            lives--;
            livesText.text = "Lives: " + lives;
            //lives -= 1;
            //lives = lives - 1;
            if (lives == 0)
            {
                //Game Over
                GameObject.Find("GameManager").GetComponent<GameManager>().GameOver();
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        
        }
        public void GainShield()
    {
        shield += 1;
        shieldText.text = "Shield: " + shield;
        if (shield >= 3)
        {
            //keep shield at 3
            shield = 3;
            shieldText.text = "Shield: " + shield;
        }
    }
    public void LoseShield()
    {
        shield--;
        shieldText.text = "Shield: " + shield;
        //shield -= 1;
        //shield = shield - 1

        if (shield <= 0)
        {
            LoseLife();
            //keep shield at 0
            shield = 0;
            shieldText.text = "Shield: " + shield;
            
        }
    }
}
