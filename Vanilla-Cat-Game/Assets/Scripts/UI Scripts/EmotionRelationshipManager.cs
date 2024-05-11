using System;
using System.ComponentModel.Design.Serialization;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;

public class EmotionRelationshipManager : MonoBehaviour
{
    public EmotionAndDialogueRelationships relationships;
    public Image[] emoticonImages;
    public Emotion currentEmotion;
    public string currentDialogueText;
    public Image currentEmoticonImage;

    [SerializeField] private TMP_Text textComponent;

    // Start is called before the first frame update
    public void Start()
    {
    }
    public void ProcessText()
    {   
        relationships.dialogueTexts = textComponent.text.Split('\n');
        for (int i = 0; i < relationships.dialogueTexts.Length; i++)
        {
            string str = relationships.dialogueTexts[i];
            Emotion emotionType = SetEmotion(str);
            Image currentImage = emoticonImages[(int)emotionType];
            currentEmoticonImage = currentImage;
        }
    }

    private Emotion SetEmotion(string text)
    {
        string[] words = text.Split("");
        string emotionWord = words[0];
        Emotion emotion = (Emotion)Enum.Parse(typeof(Emotion), emotionWord);

        return emotion;
    }

    // Update is called once per frame
    public void SetEmotion(Emotion _emotionType)
    {
        currentEmotion = _emotionType;
        currentDialogueText = relationships.dialogueTexts[(int)_emotionType];
    }
}
