using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private bool mov = false;
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    
    void OnCollisionEnter2D(Collision2D coll){
        if (coll.gameObject.tag == "Brick"){
            Destroy(coll.gameObject);  
        }
        if(coll.collider.CompareTag("Player")){
            Vector2 vel;
            vel.x = rb2d.velocity.x;
            vel.y = (rb2d.velocity.y / 2) + (coll.collider.attachedRigidbody.velocity.y / 3);
            rb2d.velocity = vel;
        }

    }

    void ResetBall(){
        rb2d.velocity = Vector2.zero;
        transform.position = new Vector2(0f, -3.7f);
    }

    // Reinicializa o jogo
    void RestartGame(){
        //ResetBall();
        mov = false;
        rb2d.velocity = Vector2.zero;
        transform.position = new Vector2(0f, -3.7f);
    }


    void Start () {
        rb2d = GetComponent<Rigidbody2D>(); // Inicializa o objeto bola
    }


    // Update is called once per frame
    void Update()
    {
        if(!mov && Input.GetAxisRaw("Horizontal") != 0f) {
            mov = true;
            rb2d.AddForce(new Vector2(0, 15));
        }
    }
}
