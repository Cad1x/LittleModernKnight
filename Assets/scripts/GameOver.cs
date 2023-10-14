using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1"))
        {
            ResetGame();
        }
    }

    private void ResetGame()
    {

        
        // Poni�ej wybieramy, kt�rej sceny chcemy u�y� do zresetowania gry.
        // Je�li u�ywasz pojedynczej sceny, wstaw tutaj nazw� bie��cej sceny.
        // Je�li korzystasz z wielu scen, wprowad� odpowiedni� nazw� sceny do zresetowania.
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Resetujemy gr�, �aduj�c ponownie bie��c� scen�.
        SceneManager.LoadScene(currentSceneName);
    }
}
