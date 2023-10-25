using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeChangeColor : MonoBehaviour
{
    public bool zmienKolor = false;
    private SpriteRenderer spriteRenderer;
    Color poprzedniKolor;

    // Start is called before the first frame update
    void Start()
    {
        // Pobierz komponent SpriteRenderer z obiektu
        spriteRenderer = GetComponent<SpriteRenderer>();
        poprzedniKolor = spriteRenderer.color;
        // Sprawdü, czy spriteRenderer zosta≥ znaleziony
        if (spriteRenderer == null)
        {
            Debug.LogError("Komponent SpriteRenderer nie zosta≥ znaleziony!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Sprawdü, czy zmienna zmienKolor zosta≥a ustawiona na true
        if (zmienKolor)
        {
            // Zmien kolor sprite'a na czerwony
            spriteRenderer.color = Color.yellow;

            // Opcjonalnie: Zresetuj zmiennπ zmienKolor, aby uniknπÊ ciπg≥ej zmiany koloru w kaødej klatce
            zmienKolor = false;
        }
    }

    public void PoprzedniKolor()
    {
        spriteRenderer.color= poprzedniKolor;
    }

}
