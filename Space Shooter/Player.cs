using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private GameObject laser;

    [SerializeField]
    private float fireRate = 0.25f;
    private float canFire = 0f;


    [SerializeField]
    private GameObject tripleShotLaser;

    public bool canTripleShot = false;
    public bool canSpeedBoost = false;


    private void Update()
    {

        Movement();

        if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space))
        {
            Shoot();
        }

    }


    // player shooting
    private void Shoot()
    {
        if (Time.time > canFire)
        {
            if (canTripleShot == true)
            {
                Instantiate(tripleShotLaser, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(laser, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity);
            }
            canFire = Time.time + fireRate;
        }
    }


    private void Movement()
    {
        // getting movement values using Input Manager
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");


        // if player gain speed boost power up then speed is 1.5x
        if (canSpeedBoost == true)
        {
            transform.Translate(Vector3.right * 1.5f * horizontalInput * speed * Time.deltaTime);
            transform.Translate(Vector3.up * 1.5f * verticalInput * speed * Time.deltaTime);
        }
        // else movement is normal 
        else
        {
            // getting user input and move 
            transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
            transform.Translate(Vector3.up * verticalInput * speed * Time.deltaTime);
        }



        // bound the player in screen
        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y < -4.2f)
        {
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        }

        // if player outof screen on x axis wrapping it!
        if (transform.position.x > 9.5f)
        {
            transform.position = new Vector3(-9.5f, transform.position.y, 0);
        }
        else if (transform.position.x < -9.5f)
        {
            transform.position = new Vector3(9.5f, transform.position.y, 0);
        }
    }


    // function for enable player triple shot powerup
    public void TripleShotPowerupOn()
    {
        canTripleShot = true;
        StartCoroutine(TripleShotPowerDown());
    }

    // function for enable player speed boost powerup
    public void SpeedBoostPowerupOn()
    {
        canSpeedBoost = true;
        StartCoroutine(SpeedBoostPowerDown());
    }


    // coroutine for disable player triple shot powerup
    public IEnumerator TripleShotPowerDown()
    {
        yield return new WaitForSeconds(5f);
        canTripleShot = false;
    }

    // coroutine for disable player speed boost powerup
    public IEnumerator SpeedBoostPowerDown()
    {
        yield return new WaitForSeconds(5f);
        canSpeedBoost = false;
    }

}