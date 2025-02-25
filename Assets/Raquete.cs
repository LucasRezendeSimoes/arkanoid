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
    float moveX = Input.GetAxisRaw("Horizontal"); // Movimento na horizontal (A/D ou setas)

    // Calculando a direção do movimento
    moveDirection = new Vector2(moveX, 0);
    }

    // FixedUpdate é chamado de forma mais consistente para física
    void FixedUpdate()
    {
        // Movimentação no Rigidbody2D
        Vector2 newPos = rb2d.position + moveDirection * moveSpeed * Time.fixedDeltaTime;

        // Limitar a posição dentro dos valores especificados
        newPos.x = Mathf.Clamp(newPos.x, -5, 5);  // Limitar o movimento na horizontal

        rb2d.MovePosition(newPos);
    }
        
}
