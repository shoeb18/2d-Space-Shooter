using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private int powerupID; // 0 for triple shot, 1 for speed boost , 2 for shields

    private void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // if we collided with player 
        if (other.tag == "Player")
        {
            // access the Player script
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                if (powerupID == 0)
                {
                    // enable the triple shot
                    player.TripleShotPowerupOn();
                }
                else if (powerupID == 1)
                {
                    // enable the speed boost
                    player.SpeedBoostPowerupOn();
                }
                else if (powerupID == 2)
                {
                    // enable the shields
                }
            }



            // destroy the powerup
            Destroy(this.gameObject);
        }

    }
}