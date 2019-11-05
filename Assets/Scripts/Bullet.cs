using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public GameObject hitEffect;
	public int damage = 20;

	//public int life = 10;

    public void OnCollisionEnter2D(Collision2D col)
    {
    	GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
    	
        /*
    	Enemigo enemigo = collision.GetComponent<Enemigo>();

    	if(enemigo != null)
    	{
    		enemigo.TakeDamage(damage);
    	}
        */
    	

    	//If the object that triggered this collision is tagged "bullet"
    	// if(col.gameObject.tag.Equals("Enemy"))
    	//if(collision.gameObject.tag == "Bullet")
    	Destroy(effect, 5f);
    	Destroy(this.gameObject);		

         if(col.gameObject.tag.Equals("Enemy"))
         {
         		Debug.Log("pitoo");
         		/*
                life -=1;
                
                if(life == 0)
                {
					Destroy(gameObject);
                }
                */

                
    			

                //FindObjectOfType<enemyHealth>().TakeDamage(20);
                col.gameObject.GetComponent<enemyHealth>().TakeDamage(5);

                
         }
    }
}
