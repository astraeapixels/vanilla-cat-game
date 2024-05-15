using System.Collections;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class UIDialoguePrefab : MonoBehaviour
{
    [TextArea(1,6)] public string[] dialogueLines;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private GameObject cinBars;
    [SerializeField] private RectTransform dialogueRect;
    [SerializeField] private float fadeInTime;
    [SerializeField] private float fadeOutTime;
    [SerializeField] private CanvasGroup dialogueGroup;
    private bool didDialoguePlay;
    private int stringIndex;
    private float typingTime = 0.05f;
    public CameraZoomController cameraZoom;
    


    // Start is called before the first frame update
    void Update()
    {
        TriggerDialogue("Start Dialogue");
    }

    // Update is called once per frame
    public void TriggerDialogue(string eventName)
    {
        // if (eventName == "Start Dialogue")
        // {
            if(Input.GetMouseButtonDown(0))
            {
                if(!didDialoguePlay)
                {  
                    cinBars.GetComponent<CinematicBars>().ShowBars();

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
        //}
    }

    private void StartDialogue()
    {
        didDialoguePlay = true;
        cameraZoom.OnDialogueEvent();
        PanelFadeIn();;
        stringIndex = 0;
        Time.timeScale = .5f;
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
            cinBars.GetComponent<CinematicBars>().HideBars();
            PanelFadeOut();
            Time.timeScale = 1f;
        }
    }

    public void SetDialogueLines(string[] newLines)
    {
        dialogueLines = newLines;
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

    private void PanelFadeIn(){
        dialogueGroup.alpha = 1f;
        dialogueRect.transform.localPosition = new Vector3(0f, -180f, 0f);
        dialogueRect.DOAnchorPos(new Vector2(0f, 75f), fadeInTime, false).SetEase(Ease.InOutQuint);
        dialogueGroup.DOFade(1, fadeInTime);
    }

        private void PanelFadeOut(){
        dialogueGroup.alpha = 1f;
        dialogueRect.transform.localPosition = new Vector3(0f, -105f, 0f);
        dialogueRect.DOAnchorPos(new Vector2(0f, -75f), fadeOutTime, false).SetEase(Ease.InOutQuint);
        dialogueGroup.DOFade(1, fadeOutTime);
    }
}
