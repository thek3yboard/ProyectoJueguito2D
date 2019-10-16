using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlacoPlayer : MonoBehaviour{

    /*Rigidbody2D flacoRB;
    public float maxVelocidad;

    //Voltear flaco
    bool voltearFlaco = true;
    SpriteRenderer flacoRender;

    // Start is called before the first frame update
    void Start(){
        flacoRB = GetComponent<Rigidbody2D>();
        flacoRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update(){
        //arriba
        //if(Input.GetKey(KeyCode.UpArrow))
        //{ transform.position += Vector3.up * maxVelocidad * Time.deltaTime; }
        //if (Input.GetKey(KeyCode.DownArrow))
        //{ transform.position += Vector3.down * maxVelocidad * Time.deltaTime; }

        float mover = Input.GetAxis("Horizontal");
        float mover = Input.GetAxis("Vertical");

        if (mover > 0 && !voltearFlaco){
            Voltear();
        }else if(mover < 0 && voltearFlaco){
            Voltear();
        }

        flacoRB.velocity = new Vector2(mover * maxVelocidad, flacoRB.velocity.y);
    }

    void Voltear(){
        voltearFlaco = !voltearFlaco;
        flacoRender.flipX = !flacoRender.flipX;
    }
    */
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;

    //Voltear flaco
    bool voltearFlaco = true;
    SpriteRenderer flacoRender;

    void Start(){
        myRigidbody = GetComponent<Rigidbody2D>();
        flacoRender = GetComponent<SpriteRenderer>();
    }

    void Update(){
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if(change != Vector3.zero)
        {
            MoveCharacter();
        }

        float mover = Input.GetAxis("Horizontal");

        if (mover > 0 && !voltearFlaco){
                Voltear();
            }else if(mover < 0 && voltearFlaco){
                Voltear();
        }

    }

    void MoveCharacter(){
        myRigidbody.MovePosition(transform.position + change * speed * Time.deltaTime);
    }

    void Voltear(){
        voltearFlaco = !voltearFlaco;
        flacoRender.flipX = !flacoRender.flipX;
    }

}
