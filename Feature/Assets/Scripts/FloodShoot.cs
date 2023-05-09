using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloodShoot : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;


    // Update is called once per frame

    void Awake()
    {
        
    }


    void Update()
    {
        if(Input.GetKeyUp(KeyCode.J))
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
        }

       
        
    }

    
}
