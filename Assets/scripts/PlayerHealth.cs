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
        // Poni�ej wybieramy, kt�rej sceny chcemy u�y� do zresetowania gry.
        // Je�li u�ywasz pojedynczej sceny, wstaw tutaj nazw� bie��cej sceny.
        // Je�li korzystasz z wielu scen, wprowad� odpowiedni� nazw� sceny do zresetowania.
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Resetujemy gr�, �aduj�c ponownie bie��c� scen�.
        SceneManager.LoadScene(currentSceneName);
    }

}
