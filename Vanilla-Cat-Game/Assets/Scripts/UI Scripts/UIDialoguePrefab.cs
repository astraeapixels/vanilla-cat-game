using Tween = PrimeTween.Tween;
using UnityEngine;
using TMPro;
using PrimeTween;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class UIDialoguePrefab : MonoBehaviour
{
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private TMP_Text[] optionButtonText;
    [SerializeField] private CinematicBars cinBars;
    [SerializeField] private RectTransform dialogueRect;
    [SerializeField] private RectTransform textRect;
    [SerializeField] private float fadeInTime;
    [SerializeField] private float fadeOutTime;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button[] choiceButton;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private GameObject choicesPanel;
    [SerializeField] private LemonSoloConversation conversation;
    [SerializeField] private LemonSoloConversation[] newConversations;
    [SerializeField] private Image defaultImage;
    [SerializeField] private Sprite currentEmotion;
    [SerializeField] private List<Sprite> emotions;
    [TextArea(1,6)] private string[] dialogueLines;
    private int currentEmotionIndex;
    private int stringIndex;
    private bool didDialoguePlay;
    private float typingTime = .20f;
    public delegate void ActivateDialogue();
    public event ActivateDialogue DialoguePlayed;
    
    private void Start()
    {   
        dialoguePanel.SetActive(false);
        choicesPanel.SetActive(false);
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
            dialoguePanel.SetActive(true);
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
            if(conversation.conversationTypes[stringIndex] == ConversationType.Regular)
            {
                StartDialogue();
            }
            if(conversation.conversationTypes[stringIndex] == ConversationType.Branch)
            {
                StartBranch();
            }
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
        UpdatePortrait();
        ShowText(dialogueText, dialogueLines, stringIndex, typingTime);   
    }

    private void NextLineInDialogue()
    {  
        if(stringIndex < conversation.conversationTypes.Length && conversation.conversationTypes[stringIndex] == ConversationType.Branch)
        {
            StartBranch();
        }
        else
        {
            stringIndex++;
            if(stringIndex < dialogueLines.Length)
            {
                UpdatePortrait();
                ShowText(dialogueText, dialogueLines, stringIndex, typingTime);
            }
            else
            {
                EndDialogue();
            }
        }
    }

    private void EndDialogue()
    {
        didDialoguePlay = false;
        cinBars.HideBars();
        PanelEnterAndExit(-74, fadeOutTime);
        Time.timeScale = 1f;
        dialoguePanel.SetActive(false);
        choicesPanel.SetActive(false);
    }

    private void StartBranch()
    {
        choicesPanel.SetActive(true);
        if(conversation.optionText.Length > 0)
        { 
            if(choiceButton.Length == conversation.optionText.Length && optionButtonText.Length == conversation.optionText.Length)
            foreach(int i in Enumerable.Range(0, conversation.optionText.Length))
            {
                if(conversation.optionText[i] == null)
                {
                    choiceButton[i].gameObject.SetActive(false);
                }
                else
                {
                    optionButtonText[i].text = conversation.optionText[i];
                    choiceButton[i].gameObject.SetActive(true);
                    Tween.UIAnchoredPosition(textRect, new Vector2(58.73706f, -9.5f), .05f, Ease.Linear);
                }
                choiceButton[i].Select();
            }
            else
            {
                Debug.LogError("Option button and text arrays must be the same length as optionText array");
            }
        }
        else
        {
            Debug.LogError("Option text array is empty.");
        }
    }

    public void OptionSelected(int _optionIndex)
    {
        foreach(Button button in choiceButton)
        {
            button.gameObject.SetActive(false);

            switch(_optionIndex)
            {
                case 0:
                    conversation = newConversations[0];
                    break;
                case 1:
                    conversation = newConversations[1];
                    break;
                case 2:
                    conversation = newConversations[2];
                    break;
                case 3:
                    conversation = newConversations[3];
                    break;
            };
            stringIndex = 0;
            if(newConversations[_optionIndex].conversationTypes[_optionIndex] == ConversationType.Regular)
            {
                dialogueLines = newConversations[_optionIndex].dialogue;
                UpdatePortrait();
                ShowText(dialogueText, dialogueLines, stringIndex, typingTime);
            }
        }
    }

    private void UpdatePortrait()
    {
        currentEmotionIndex++;
        if(currentEmotionIndex >= emotions.Count)
        {
            currentEmotionIndex = 0;
        }
        defaultImage.sprite = emotions[currentEmotionIndex];
    }

    private static Tween ShowText(TMP_Text _dialogueText, string[] _dialogueLines, int _stringIndex, float _typingTime)
    {
        _dialogueText.text = string.Empty;
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
public enum ConversationType {Regular, Branch};