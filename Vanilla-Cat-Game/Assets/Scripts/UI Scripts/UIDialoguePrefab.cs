using Tween = PrimeTween.Tween;
using UnityEngine;
using TMPro;
using PrimeTween;

public class UIDialoguePrefab : MonoBehaviour
{
    [TextArea(1,6)] public string[] dialogueLines;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private CinematicBars cinBars;
    [SerializeField] private RectTransform dialogueRect;
    [SerializeField] private float fadeInTime;
    [SerializeField] private float fadeOutTime;
    [SerializeField] private CameraZoomController cameraZoom;
    private bool didDialoguePlay;
    private int stringIndex;
    private float typingTime = .20f;

    public delegate void ActivateDialogue();
    public event ActivateDialogue DialoguePlayed;
    
    void Update()
    {
        DialoguePlayed?.Invoke();
    }

    public void TriggerDialogue()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(!didDialoguePlay)
            {  
                cinBars.ShowBars();

                StartDialogue();
            }else if(dialogueText.text == dialogueLines[stringIndex])
            {
                NextLineInDialogue();
            }else
            {
                dialogueText.text = dialogueLines[stringIndex];
            }
        }
    }

    private void StartDialogue()
    {
        didDialoguePlay = true;
        cameraZoom.OnDialogueEvent();
        PanelFadeIn();
        stringIndex = 0;
        Time.timeScale = .5f;
        ShowLine(dialogueText, dialogueLines, stringIndex, typingTime);
    }

    private void NextLineInDialogue()
    {
        stringIndex++;
        if(stringIndex < dialogueLines.Length)
        {
            ShowLine(dialogueText, dialogueLines, stringIndex, typingTime);
        }else
        {
            didDialoguePlay = false;
            cinBars.HideBars();
            PanelFadeOut();
            Time.timeScale = 1f;
        }
    }

    public void SetDialogueLines(string[] newLines)
    {
        dialogueLines = newLines;
    }

    private static Tween ShowLine(TMP_Text _dialogueText, string[] _dialogueLines, int _stringIndex, float charsPerSecond)
    {
        _dialogueText.text = _dialogueLines[_stringIndex];
        int characterCount = _dialogueLines[_stringIndex].Length;
        float duration = charsPerSecond;
        return Tween.TextMaxVisibleCharacters(_dialogueText, 0, characterCount, duration, Ease.Linear);
    }
    
    private void PanelFadeIn()
    {
        dialogueRect.transform.localPosition = new Vector3(0f, -180f, 0f);
        Tween.UIAnchoredPosition(dialogueRect, new Vector2(0f, 75f), fadeInTime, Ease.InOutQuint, 1);
    }

    private void PanelFadeOut()
    {
        dialogueRect.transform.localPosition = new Vector3(0f, -105f, 0f);
        Tween.UIAnchoredPosition(dialogueRect, new Vector2(0f, -75f), fadeOutTime, Ease.InOutQuint, 1);
    }
}
