using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIDialoguePrefab : MonoBehaviour
{
    [SerializeField, TextArea(1,6)] private string[] dialogueLines;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private GameObject cinBars;

    private bool didDialoguePlay;
    private int stringIndex;
    private float typingTime = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(!didDialoguePlay)
            {
                StartDialogue();
            }else if(dialogueText.text == dialogueLines[stringIndex])
            {
                NextLineInDialogue();
            }else
            {
                StopAllCoroutines();
                dialogueText.text = dialogueLines[stringIndex];
            }
        }
    }

    private void StartDialogue()
    {
        didDialoguePlay = true;
        cinBars.GetComponent<CinematicBars>().ShowBars(100f, .5f);
        dialoguePanel.SetActive(true);
        stringIndex = 0;
        Time.timeScale = 0f;
        StartCoroutine(ShowLine());
    }
    private void NextLineInDialogue()
    {
        stringIndex++;
        if(stringIndex < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }else
        {
            didDialoguePlay = false;
            dialoguePanel.SetActive(false);
            cinBars.GetComponent<CinematicBars>().HideBars(.5f);
            Time.timeScale = 1f;
        }
    }
    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;
        foreach(char ch in dialogueLines[stringIndex])
        {
            dialogueText.text += ch;
            yield return new WaitForSecondsRealtime(typingTime);
        }
    }
}
