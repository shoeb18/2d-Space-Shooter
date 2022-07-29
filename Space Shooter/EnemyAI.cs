using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    [SerializeField]
    private float speed = 1f;

    void Start()
    {

    }

    void Update()
    {
        // move down
        transform.Translate(Vector3.down * speed * Time.deltaTime);


        // if enemy is out of screen spawn another one at random x position

        if (transform.position.y < -7f)
        {
            float randomX = Random.Range(-7f, 7f);
            transform.position = new Vector3(randomX, 7, 0);
        }
    }
}