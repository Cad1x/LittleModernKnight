using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    public GameObject TutorialCanvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1"))
        {
            AktywujPanel();
        }
    }

    void AktywujPanel()
    {
        if (TutorialCanvas != null)
        {
            TutorialCanvas.SetActive(true);
        }
    }
}
