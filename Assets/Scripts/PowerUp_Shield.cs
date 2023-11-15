using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Shield : MonoBehaviour
{
    void Update()
    {
        transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * 10);
        if (transform.position.x < -35f)
        {
            transform.position = new Vector3(Random.Range(35f, 45f), Random.Range(0.5f, -3.5f), 0);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Shield picked up!");
            other.GetComponent<Player>().GainShield();
        }
    }
}


