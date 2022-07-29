using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    [SerializeField]
    private float speed = 10f;

    private void Update() {

        // moves the laser in upward with the speed value
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        // if laser is out of screen destroy that
        if (transform.position.y > 6)
        {
            Destroy(this.gameObject);
        }
    }
}