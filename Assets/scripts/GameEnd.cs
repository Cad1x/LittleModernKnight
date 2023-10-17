using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    
        // Wywo�ywane, gdy inny obiekt wchodzi w obszar kolizyjny
        private void OnTriggerEnter2D(Collider2D collision)
        {
            // Sprawd�, czy obiekt, kt�ry wszed� w obszar kolizyjny, to gracz (lub inny obiekt, kt�ry ma odpowiedni tag)
            if (collision.CompareTag("Player1"))
            {
                // Wy��cz gr�
                Application.Quit();

                // Lub u�yj tej linii, aby zatrzyma� gr� w edytorze Unity
                // UnityEditor.EditorApplication.isPlaying = false;
            }
        }
    
}
