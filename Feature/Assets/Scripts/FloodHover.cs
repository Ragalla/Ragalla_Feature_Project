using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloodHover : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    public bool isOnGround = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            isOnGround = false;
        }

        if (Input.GetKeyUp(KeyCode.L))
        {
            isOnGround = true;
        }
    
        if (Input.GetKey(KeyCode.L) & isOnGround == false)
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
        }
        else
        {
            Destroy(bulletPrefab);
        }
    }
}