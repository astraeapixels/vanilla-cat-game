using Tween = PrimeTween.Tween;
using UnityEngine;
using TMPro;
using PrimeTween;
using UnityEngine.UI;

public class UIDialoguePrefab : MonoBehaviour
{
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private TMP_Text[] optionButtonText;
    [SerializeField] private CinematicBars cinBars;
    [SerializeField] private RectTransform dialogueRect;
    [SerializeField] private float fadeInTime;
    [SerializeField] private float fadeOutTime;
    [SerializeField] private Button exitButton;
    [SerializeField] private GameObject[] optionButton;
    [SerializeField] private GameObject[] options;
    [SerializeField] private LemonSoloConversation conversation;
    [SerializeField] private ConversationType conversationType;
    [SerializeField] private Image defaultImage;
    [SerializeField] private Sprite currentEmotion;
    [TextArea(1,6)] private string[] dialogueLines;
    private bool didDialoguePlay;
    private int stringIndex;
    private float typingTime = .20f;
    public delegate void ActivateDialogue();
    public event ActivateDialogue DialoguePlayed;
    
    private void Start()
    {   
        dialogueLines = conversation.dialogue;
        exitButton.onClick.AddListener(ExitDialogue);
    }

    private void Update()
    {
        DialoguePlayed?.Invoke();
    }

    public void PlayerInput()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            TriggerDialogue();
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            EndDialogue();
        }
    }

    public void ExitDialogue()
    {
        EndDialogue();
    }

    private void TriggerDialogue()
    {
        if(!didDialoguePlay)
        {
            cinBars.ShowBars();
            StartDialogue();       
        }
        else if(dialogueText.text == dialogueLines[stringIndex])
        {
            NextLineInDialogue();
        }
        else
        {
            dialogueText.text = dialogueLines[stringIndex];
            Tween.StopAll(dialogueText);
        }
    }

    private void StartDialogue()
    {
        didDialoguePlay = true;
        PanelEnterAndExit(74f, fadeInTime);
        stringIndex = 0;
        Time.timeScale = .5f;
        ShowText(dialogueText, dialogueLines, stringIndex, typingTime); 
    }

    private void NextLineInDialogue()
    {   
        stringIndex++;
        if(stringIndex < dialogueLines.Length)
        {
            ShowText(dialogueText, dialogueLines, stringIndex, typingTime);
        }
        else
        {
            EndDialogue();
        }
    }

    public void EndDialogue()
    {
        didDialoguePlay = false;
        cinBars.HideBars();
        PanelEnterAndExit(-74, fadeOutTime);
        Time.timeScale = 1f;
    }

    private void StartBranch()
    {
        for(int i = 0; i < conversation.optionText.Length; i++)
        {
            if(conversation.optionText[i] == null)
            {
                optionButton[i].SetActive(false);
            }
            else
            {
                optionButtonText[i].text = conversation.optionText[i];
                options[i].SetActive(true);
            }
        } 
    }

    private static Tween ShowText(TMP_Text _dialogueText, string[] _dialogueLines, int _stringIndex, float _typingTime)
    {
        _dialogueText.SetText(_dialogueLines[_stringIndex]);
        int characterCount = _dialogueLines[_stringIndex].Length;
        float duration = _typingTime;
        return Tween.TextMaxVisibleCharacters(_dialogueText, 0, characterCount, duration, Ease.Linear);
    }
    
    private void PanelEnterAndExit(float _panelYPos, float _fadeTime)
    {
        Tween.UIAnchoredPosition(dialogueRect, new Vector2(0f, _panelYPos), _fadeTime, Ease.InOutQuint, 1);
    }
}
