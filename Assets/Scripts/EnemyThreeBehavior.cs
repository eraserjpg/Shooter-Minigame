using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThreeBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(1, -3, 0) * Time.deltaTime * 2);
        if (transform.position.y < -8f)
        {
            Destroy(this.gameObject);
        }
    }
}