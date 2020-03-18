using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicaPersonaje : MonoBehaviour
{
    public float velocidad = 2f;
    public Vector2 direccion;
    private Animator anim;
    //public bool isDead = false;

    public Slider staminaBar;
    public Slider healthBar;

    public float stamina;
    public float staminaOverTime;

    public float health;
    public float healthOverTime;

    public bool botonPresionado = false;

      //APUNTAR CON MOUSE
    public Rigidbody2D rb;
    public Camera cam;
    Vector2 mousePos;
    
    void Start()
    {
        anim = GetComponent<Animator>();

        staminaBar.maxValue = stamina;
        healthBar.maxValue = health;
    }

    
    void Update()
    {
        if(health == 0){
            FindObjectOfType<Shooting2>().DoNothing();
            return;
        }

        Movimiento();
        PresionarBotones();

    	if(Input.GetKey(KeyCode.LeftShift) && botonPresionado == true)
        {
            velocidad=5f;
            stamina -= staminaOverTime * Time.deltaTime;

            if(stamina <= 0){
                stamina = 0;
                velocidad = 2f;
                stamina += staminaOverTime * Time.deltaTime;
            }    
        }
        else
        {
            velocidad = 2f;
            stamina += staminaOverTime * Time.deltaTime;
        }
        botonPresionado = false;
        updateUI();

        //APUNTAR CON MOUSE
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    //APUNTAR CON MOUSE
    void FixedUpdate()
    {
        if(health == 0){
            FindObjectOfType<Shooting2>().DoNothing();
            return;
        }
            


        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
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
            anim.SetLayerWeight(1, 0);
        }
        
    }
    public void PresionarBotones()
    {
        direccion = Vector2.zero;

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            direccion += Vector2.up;
            botonPresionado = true;
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        /*
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            direccion += Vector2.down;
            botonPresionado = true;
        }
        
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            direccion += Vector2.left;
            botonPresionado = true;
        }
        
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            direccion += Vector2.right;
            botonPresionado = true;
        }
        */
    }

    public void AnimarMovimiento(Vector2 direccion)
    {
        anim.SetLayerWeight(1, 1);
        anim.SetFloat("x", direccion.x);
        anim.SetFloat("y", direccion.y);
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
            if(health <= 0)
            {
                anim.SetBool("IsDead", true);
                Destroy(gameObject,3f);

                FindObjectOfType<GameManager>().EndGameLost();
            }
        }

        updateUI();
    }

    public void OnCollisionStay2D (Collision2D col){
        if(col.gameObject.tag.Equals("Enemy")){
            health -= healthOverTime * Time.deltaTime;
            if(health <= 0)
            {
                anim.SetBool("IsDead", true);
                Destroy(gameObject,3f);

                FindObjectOfType<GameManager>().EndGameLost();
            }
        }

        updateUI();
    }
}
