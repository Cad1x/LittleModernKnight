using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    
        // Wywo³ywane, gdy inny obiekt wchodzi w obszar kolizyjny
        private void OnTriggerEnter2D(Collider2D collision)
        {
            // SprawdŸ, czy obiekt, który wszed³ w obszar kolizyjny, to gracz (lub inny obiekt, który ma odpowiedni tag)
            if (collision.CompareTag("Player1"))
            {
                // Wy³¹cz grê
                Application.Quit();

                // Lub u¿yj tej linii, aby zatrzymaæ grê w edytorze Unity
                // UnityEditor.EditorApplication.isPlaying = false;
            }
        }
    
}
