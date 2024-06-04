using UnityEngine;


public enum EmotionType {Default, Happy, Sassy, Flirty, Soft, Angry, Confused, Suspicious, Sad, Surprised, Scared, InLove};

[CreateAssetMenu(fileName = "New Lemon Conversation", menuName = "Conversation")]
public class LemonDialogueSequence : ScriptableObject
{
    public EmotionType emotionType;
    public Line[] dialogueLines;
    public Question questionsAsked;
    public LemonDialogueSequence nextConversation;
}

[System.Serializable]
public struct Line
{
    public Character lemon;
    public string dialogueLines;
    public EmotionType emotionType;
}