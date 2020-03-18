using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting2 : MonoBehaviour
{
	public Transform firePoint;
	public GameObject bulletPrefab;
    private bool playerDied = false;

	public float bulletForce = 10f;

    // Update is called once per frame
    void Update()
    {
        if(playerDied == false){
            if(Input.GetMouseButtonDown(0))
            {
                Shoot();
            }
            }else{
                return;
            }
        
    }

    void Shoot()
    {
    	GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    	Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
    	rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    public void DoNothing(){
        playerDied = true;
    }
}
