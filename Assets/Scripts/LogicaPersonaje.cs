using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaPersonaje : MonoBehaviour
{
    public float velocidad = 2f;
    public Vector2 direccion;
    private Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        Movimiento();
        PresionarBotones();

    	if(Input.GetKey(KeyCode.LeftShift))
        {
            velocidad=5f;
        }
        else
        {
            velocidad=2f;
        }
    }

    public void Movimiento()
    {
        transform.Translate(direccion * velocidad * Time.deltaTime);

        if(direccion.x != 0 || direccion.y !=0)
        {
            AnimarMovimiento(direccion);
        }
        else
        {
            animator.SetLayerWeight(1, 0);
        }
        
    }
    public void PresionarBotones()
    {
        direccion = Vector2.zero;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            direccion += Vector2.up;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            direccion += Vector2.down;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direccion += Vector2.left;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direccion += Vector2.right;
        }
    }

    public void AnimarMovimiento(Vector2 direccion)
    {
        animator.SetLayerWeight(1, 1);
        animator.SetFloat("x", direccion.x);
        animator.SetFloat("y", direccion.y);
    }
}
