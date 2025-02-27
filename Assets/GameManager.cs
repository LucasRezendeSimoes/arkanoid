using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GUISkin layout;
    private int pontos;

    // Start is called before the first frame update
    void Start()
    {
        pontos = BallControl.pontos;
    }

    void OnGUI ()
    {
        if(pontos == 0)
        {
            GUI.skin = layout;
            GUI.skin.label.fontSize = 50;
            Vector2 titulo = GUI.skin.label.CalcSize(new GUIContent("Arkanoid"));
            GUI.Label(new Rect((Screen.width - titulo.x) / 2, 50, titulo.x, titulo.y), "Arkanoid");

            GUI.skin.label.fontSize = 20;
            Vector2 subTitulo = GUI.skin.label.CalcSize(new GUIContent("Aperte espaço para iniciar"));
            GUI.Label(new Rect((Screen.width - subTitulo.x) / 2, 400, subTitulo.x, subTitulo.y), "Aperte espaço para iniciar");
        }
        else{
            GUI.skin = layout;
            GUI.skin.label.fontSize = 50;
            Vector2 titulo = GUI.skin.label.CalcSize(new GUIContent("Fim do jogo"));
            GUI.Label(new Rect((Screen.width - titulo.x) / 2, 50, titulo.x, titulo.y), "Fim do jogo");

            GUI.skin.label.fontSize = 20;
            string score = "Sua pontuação foi "+ pontos;
            Vector2 subTitulo1 = GUI.skin.label.CalcSize(new GUIContent(score));
            GUI.Label(new Rect((Screen.width - subTitulo1.x) / 2, 300, subTitulo1.x, subTitulo1.y), score);

            GUI.skin.label.fontSize = 20;
            Vector2 subTitulo2 = GUI.skin.label.CalcSize(new GUIContent("Precione espaço para reiniciar"));
            GUI.Label(new Rect((Screen.width - subTitulo2.x) / 2, 400, subTitulo2.x, subTitulo2.y), "Precione espaço para reiniciar");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("Jogo");
            pontos = 0;
        }
    }
}
