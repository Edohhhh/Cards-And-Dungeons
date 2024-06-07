using System.Collections;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{

    [SerializeField] private GameObject exclamationMark;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(4,6)] private string[] dialogueLines;

    [SerializeField] private GameObject CardFire;
    [SerializeField] private GameObject CardWater;
    [SerializeField] private GameObject CardRock;

    [SerializeField] private Transform cardContainer; // Contenedor de cartas en la UI

    private float typingTime = 0.05f;

    private bool IsPlayerInRange;
    private bool didDialogueStart;
    private int lineIndex;

    void Update()
    {
        if (IsPlayerInRange && Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (!didDialogueStart)
            {
                StartDialogue();
            }
            else if (dialogueText.text == dialogueLines[lineIndex])
            {
                NextDialogueLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = dialogueLines[lineIndex];
            }
        }
    }

    private void StartDialogue()
    { 
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        exclamationMark.SetActive(false);
        lineIndex = 0;
        StartCoroutine (ShowLine());
    }

    private void NextDialogueLine()
    { 
        lineIndex++;
        if (lineIndex < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        { 
            didDialogueStart = false;
            dialoguePanel.SetActive(false);
            exclamationMark.SetActive(true);

            // Mostrar las cartas al finalizar el diálogo
            ShowCards();
        }
    }

    private IEnumerator ShowLine()
    { 
        dialogueText.text = string.Empty;

        foreach (char ch in dialogueLines[lineIndex])
        { 
            dialogueText.text += ch;
            yield return new WaitForSeconds(typingTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.transform.CompareTag("MainCharacter"))
        {
            IsPlayerInRange = true;
            exclamationMark.SetActive(true);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.transform.CompareTag("MainCharacter"))
        {
            IsPlayerInRange = false;
            exclamationMark.SetActive(false);
        }
    }

    private void ShowCards()
    {
            Instantiate(CardFire, cardContainer);
            Instantiate(CardWater, cardContainer);
            Instantiate(CardRock, cardContainer);
       
    }
}
