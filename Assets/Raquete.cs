using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raquete : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidade de movimentação
    private Rigidbody2D rb2d; // Referência para o Rigidbody2D
    private Vector2 moveDirection; // Direção do movimento
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
    // Obtendo a entrada do usuário para movimentação
    float moveX = Input.GetAxis("Horizontal"); // Movimento na horizontal (A/D ou setas)
    float moveY = Input.GetAxis("Vertical"); // Movimento na vertical (W/S ou setas)

    // Calculando a direção do movimento
    moveDirection = new Vector2(moveX, moveY).normalized; // Normalizando para evitar velocidade maior na diagonal
    }

    // FixedUpdate é chamado de forma mais consistente para física
    void FixedUpdate(){
    // Aplicando a movimentação no Rigidbody2D
        if(rb2d.position.x > 5){
            rb2d.MovePosition(new Vector2(5f,-4f));
        }
        else if(rb2d.position.x < -5){
            rb2d.MovePosition(new Vector2(-5f,-4f));
        }
        else{
            rb2d.MovePosition(rb2d.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
        }
    }
        
}
