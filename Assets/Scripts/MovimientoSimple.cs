using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoSimple : MonoBehaviour
{

	public GameObject startPoint;
	public GameObject endPoint;

	public float enemySpeed;

	public bool isGoingRight;

	public bool voltearZombie = true;
	SpriteRenderer zombieRender;
    // Start is called before the first frame update
    void Start()
    {
        if(isGoingRight){
        	transform.position = startPoint.transform.position;
        }else{
        	transform.position = endPoint.transform.position;
        }

        zombieRender = GetComponent<SpriteRenderer>();
    }

    void Voltear(){
        voltearZombie = !voltearZombie;
        zombieRender.flipX = !zombieRender.flipX;
    }
    // Update is called once per frame
    void Update()
    {
        if(isGoingRight){
        	transform.position = Vector3.MoveTowards(transform.position, endPoint.transform.position, enemySpeed * Time.deltaTime);
        	
        	if(transform.position == endPoint.transform.position){
        		isGoingRight = false;
        		Voltear();
        	}		
        }

        if(!isGoingRight){
        	transform.position = Vector3.MoveTowards(transform.position, startPoint.transform.position, enemySpeed * Time.deltaTime);
        	
        	if(transform.position == startPoint.transform.position){
        		isGoingRight = true;
        		Voltear();
        	}
        }
    }
}
