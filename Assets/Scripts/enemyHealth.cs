using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
	int enemiesLeft = 0;
    //ATENCION LO DE ABAJO ES NUEVO Y PUEDE FALLARRRRRRRRRRRRRRRRRRRRRRRRRRRRRR
    private int health = 100;
    public GameObject deathEffect;

    public void TakeDamage(int damage)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesLeft = enemies.Length;
        
        
        Debug.Log("DAÑO: " + damage + "VIDA: " + health);
        health -= damage;

        if(health <= 0)
        {
            Debug.Log("hola putas ENEMIGOS RESTANTES:" + enemiesLeft);
            enemiesLeft--;
            Destroy(this.gameObject);
            if(enemiesLeft == 0)
            {
                FindObjectOfType<GameManager>().EndGameWon();
            }
            Die();
        }
    }
    
    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    //ATENCION LO DE ABRIBA ES NUEVO Y PUEDE FALLARRRRRRRRRRRRRRRRRRRRRRRRRRRR
}
