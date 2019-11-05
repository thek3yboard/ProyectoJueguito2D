using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public GameObject hitEffect;
	public int damage = 20;

    void OnCollisionEnter2D(Collision2D collision)
    {
    	GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
    	
        /*
    	Enemigo enemigo = collision.GetComponent<Enemigo>();

    	if(enemigo != null)
    	{
    		enemigo.TakeDamage(damage);
    	}
        */
    	Destroy(effect, 5f);
    	Destroy(gameObject);
    }
}
