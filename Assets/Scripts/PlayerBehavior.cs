using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    //1. access (public or private)
    //2. type (int, float, bool)
    //3. name (naming conventions) they always start with a letter that is not capitalized, but you can have multiple words with no spaces and follows with words that may be capitalized.
    //4. OPTIONAL: you can give it a value
    //borders: horizontal is from -8.5 to 8.5. vertical is from -3.5 to 5.5.

    public float speed;
    public float horizontalInput;
    public float verticalInput;
    public float horizontalScreenLimitRight;
    public float horizontalScreenLimitLeft;
    public float verticalScreenLimitTop;
    public float verticalScreenLimitBottom;
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        speed = 4f;
        horizontalScreenLimitRight = 8.5f;
        horizontalScreenLimitLeft = -8.5f;
        verticalScreenLimitTop = 0.5f;
        verticalScreenLimitBottom = -3.5f;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Shooting();
    }
    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * speed);
        if (transform.position.x > horizontalScreenLimitRight)
        {
            //I am outside the screen from the right
            transform.position = new Vector3(horizontalScreenLimitLeft, transform.position.y, 0);
        }
        else if (transform.position.x < horizontalScreenLimitLeft)
        {
            //I am outside the screen from the left
            transform.position = new Vector3(horizontalScreenLimitRight, transform.position.y, 0);
        }

        if (transform.position.y >= verticalScreenLimitTop)
        {
            //I am touching middle of the screen
            transform.position = new Vector3(transform.position.x, verticalScreenLimitTop, 0);
        }
        else if (transform.position.y <= verticalScreenLimitBottom)
        {
            //I am touching bottom of the screen
            transform.position = new Vector3(transform.position.x, verticalScreenLimitBottom, 0);
        }
    }

    void Shooting()
    {
        //If I press SPACE, spawn a bullet.
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //Spawn a bullet.
            Instantiate(bulletPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }
}
