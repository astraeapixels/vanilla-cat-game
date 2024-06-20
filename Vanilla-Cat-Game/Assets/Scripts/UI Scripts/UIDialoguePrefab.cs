using Tween = PrimeTween.Tween;
using UnityEngine;
using TMPro;
using PrimeTween;
using UnityEngine.UI;

public class UIDialoguePrefab : MonoBehaviour
{
    [TextArea(1,6)] public string[] dialogueLines;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private CinematicBars cinBars;
    [SerializeField] private RectTransform dialogueRect;
    [SerializeField] private float fadeInTime;
    [SerializeField] private float fadeOutTime;
    [SerializeField] private Button exitButton;
    [SerializeField] private Image defaultEmoticon;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private EmotionsAndSprites emotionsAndSprites;
    [SerializeField] private Sprite currentEmoticons;
    private bool didDialoguePlay;
    private int stringIndex;
    private float typingTime = .20f;
    public delegate void ActivateDialogue();
    public event ActivateDialogue DialoguePlayed;

    // public void Emoticon()
    // {
    //     currentEmoticons = emotionType switch
    //     {
    //         Emotion.Default => emotionsAndSprites.defaultMood,
    //         Emotion.Happy => emotionsAndSprites.happy,
    //         Emotion.Sassy => emotionsAndSprites.sassy,
    //         Emotion.Flirty => emotionsAndSprites.flirty,
    //         Emotion.Soft => emotionsAndSprites.soft,
    //         Emotion.Angry => emotionsAndSprites.angry,
    //         Emotion.Confused => emotionsAndSprites.confused,
    //         Emotion.Sad => emotionsAndSprites.sad,
    //         Emotion.Surprised => emotionsAndSprites.surprised,
    //         Emotion.Scared => emotionsAndSprites.scared,
    //         Emotion.InLove => emotionsAndSprites.inLove,
    //         _ => emotionsAndSprites.defaultMood,
    //     };
    // }
    
    private void Start()
    {   
        currentEmoticons = emotionsAndSprites.defaultMood;
        spriteRenderer.sprite = currentEmoticons;
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
        //ShowSprite(spriteRenderer, dialogueText, dialogueLines, stringIndex, currentEmoticons, typingTime);
        ShowText(dialogueText, dialogueLines, stringIndex, typingTime); 
    }

    private void NextLineInDialogue()
    {   
        stringIndex++;
        if(stringIndex < dialogueLines.Length)
        {
            //ShowSprite(spriteRenderer, dialogueText, dialogueLines, stringIndex, currentEmoticons, typingTime);
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

    public void SetDialogueLines(string[] newLines)
    {
        dialogueLines = newLines;
    }

    // private static Tween ShowSprite(SpriteRenderer _spriteRenderer, TMP_Text _dialogueText, string[] _dialogueLines, int _stringIndex, Sprite _currentEmoticons, float _typingTime)
    // {   
    //     _dialogueText.SetText(_dialogueLines[_stringIndex]);
    //     int spriteCount = _dialogueLines.Length;
    //     float duration = _typingTime;
    //     _spriteRenderer.sprite = _currentEmoticons;
    //     return Tween.Alpha(_spriteRenderer, spriteCount, duration, Ease.Linear);
    // }

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
