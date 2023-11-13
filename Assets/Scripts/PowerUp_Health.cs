using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Health : MonoBehaviour
{
    void Update()
    {
        transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * 6);
        if (transform.position.x > 25f)
        {
            transform.position = new Vector3(Random.Range(-25f, -35f), Random.Range(0.5f, -3.5f), 0);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Power up picked up!");
            other.GetComponent<Player>().GainLife();
        }
    }
}


