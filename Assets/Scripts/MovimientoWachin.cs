using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoWachin : MonoBehaviour
{
    public float velocidadMovimiento = 2f;
    public Rigidbody2D rb;


    Animator wachinAnimator;
    
    bool voltearWachin = true;
    SpriteRenderer WachinRender;

    Vector2 movimiento;
    // Start is called before the first frame update
    void Start()
    {   
        rb = GetComponent<Rigidbody2D>();
        WachinRender = GetComponent<SpriteRenderer>();
        wachinAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update(){
        movimiento.x = Input.GetAxisRaw("Horizontal");
        movimiento.y = Input.GetAxisRaw("Vertical");
        

        float mover = Input.GetAxis("Horizontal");

        if (mover > 0 && !voltearWachin){
                Voltear();
            }else if(mover < 0 && voltearWachin){
                Voltear();
        }

        //sprint
       
        if(Input.GetKey(KeyCode.LeftShift))
            velocidadMovimiento=5f;
        else
            velocidadMovimiento=2f;

    }

    void FixedUpdate(){
        rb.MovePosition(rb.position + movimiento * velocidadMovimiento * Time.fixedDeltaTime);

        wachinAnimator.SetFloat("VelMovimiento", Mathf.Abs(movimiento.x));
    }

    void Voltear(){
        voltearWachin = !voltearWachin;
        WachinRender.flipX = !WachinRender.flipX;
    }


}
