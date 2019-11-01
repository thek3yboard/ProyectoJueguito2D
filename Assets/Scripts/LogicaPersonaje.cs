using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicaPersonaje : MonoBehaviour
{
    public float velocidad = 2f;
    public Vector2 direccion;
    private Animator animator;

    public Slider staminaBar;
    public Slider healthBar;

    public float stamina;
    public float staminaOverTime;

    public float health;
    public float healthOverTime;
    
    void Start()
    {
        animator = GetComponent<Animator>();

        staminaBar.maxValue = stamina;
        healthBar.maxValue = health;
    }

    
    void Update()
    {
        Movimiento();
        PresionarBotones();

    	if(Input.GetKey(KeyCode.LeftShift))
        {
            velocidad=5f;
            stamina -= staminaOverTime * Time.deltaTime;

            if(stamina <= 0){
                stamina = 0;
                velocidad=2f;
                stamina += staminaOverTime * Time.deltaTime;
            }    
        }
        else
        {
            velocidad=2f;
            stamina += staminaOverTime * Time.deltaTime;
        }

        updateUI();
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

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            direccion += Vector2.up;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            direccion += Vector2.down;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            direccion += Vector2.left;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
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

    private void updateUI()
    {
        stamina = Mathf.Clamp(stamina, 0, 100f);
        health = Mathf.Clamp(health, 0, 100f);

        staminaBar.value = stamina;
        healthBar.value = health;
    }

    public void OnCollisionEnter2D (Collision2D col){
        if(col.gameObject.tag.Equals("Enemy")){
            health -= healthOverTime * Time.deltaTime;
        }

        updateUI();
    }

    public void OnCollisionStay2D (Collision2D col){
        if(col.gameObject.tag.Equals("Enemy")){
            health -= healthOverTime * Time.deltaTime;
        }

        updateUI();
    }
}
