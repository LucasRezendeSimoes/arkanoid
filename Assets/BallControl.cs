using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallControl : MonoBehaviour
{
    private bool mov = false;
    public static int pontos = 0;
    private Rigidbody2D rb2d;

    private GameObject[] tijolos;
    // Start is called before the first frame update
    
    void OnCollisionEnter2D(Collision2D coll){
        tijolos = GameObject.FindGameObjectsWithTag("Brick");
        if (coll.gameObject.tag == "Brick"){
            Destroy(coll.gameObject);
            pontos += 10;
        }
        if(coll.gameObject.name == "Perder" || tijolos.Length == 0){
            SceneManager.LoadScene("Fim");
        }
        if(coll.collider.CompareTag("Player")){
            Vector2 vel;
            vel.y = rb2d.velocity.y *1.1f;
            vel.x = (rb2d.velocity.x / 2) + (coll.collider.attachedRigidbody.velocity.x / 3)*1.1f;
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
        pontos = 0;
    }


    // Update is called once per frame
    void Update()
    {
        if(!mov && Input.GetAxisRaw("Horizontal") != 0f)
        {
            mov = true;
            rb2d.AddForce(new Vector2(15, 15));
        }
        if(Input.GetKey(KeyCode.Backspace))
        {
            GameObject[] kabum = GameObject.FindGameObjectsWithTag("Brick");
            foreach(GameObject t in kabum)
            {
                Destroy(t);
                pontos += 10;
            }
        }
    }
}
