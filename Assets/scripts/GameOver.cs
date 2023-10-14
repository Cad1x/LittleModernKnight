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

        
        // Poni¿ej wybieramy, której sceny chcemy u¿yæ do zresetowania gry.
        // Jeœli u¿ywasz pojedynczej sceny, wstaw tutaj nazwê bie¿¹cej sceny.
        // Jeœli korzystasz z wielu scen, wprowadŸ odpowiedni¹ nazwê sceny do zresetowania.
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Resetujemy grê, ³aduj¹c ponownie bie¿¹c¹ scenê.
        SceneManager.LoadScene(currentSceneName);
    }
}
