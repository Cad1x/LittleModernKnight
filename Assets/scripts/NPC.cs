using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text dialogueText;
    public string[] dialogue;
    private int index;

    public float wordSpeed;
    public float pickupRange;
    private bool isDialogueActive = false;
    private bool isTyping = false;
    private bool isPlayerInRange = false;
    private bool wasPlayerInRange = false;

    public Vector3 dialogueOffset;

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (isDialogueActive)
            {
                if (isTyping)
                {
                    CompleteTyping();
                }
                else
                {
                    NextLine();
                }
            }
            else
            {
                if (!wasPlayerInRange)
                {
                    index = 0;
                }
                StartDialogue();
            }
        }

        if (isDialogueActive && !isTyping)
        {
            StartCoroutine(Typing());
        }

        wasPlayerInRange = isPlayerInRange;
    }

    public void StartDialogue()
    {
        isDialogueActive = true;
        dialoguePanel.SetActive(true);
        dialoguePanel.transform.position = transform.position + dialogueOffset;
    }

    public void NextLine()
    {
        if (index < dialogue.Length)
        {
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            EndDialogue();
        }
    }

    IEnumerator Typing()
    {
        isTyping = true;
        string currentLine = dialogue[index];
        int letterIndex = 0;

        while (letterIndex < currentLine.Length)
        {
            dialogueText.text += currentLine[letterIndex];
            letterIndex++;
            yield return new WaitForSeconds(wordSpeed);
        }

        isTyping = false;
        index++;
    }

    private void CompleteTyping()
    {
        StopCoroutine(Typing());
        dialogueText.text = dialogue[index];
        isTyping = false;
    }

    public void EndDialogue()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
        isDialogueActive = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1"))
        {
            isPlayerInRange = false;
            EndDialogue();
        }
    }
}