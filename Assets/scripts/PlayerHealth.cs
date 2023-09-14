using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 10;

    
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0 )
        {
            Destroy(gameObject, 0.2f);
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
