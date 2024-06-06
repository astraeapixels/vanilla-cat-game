using UnityEngine;


public enum EmotionType {Default, Happy, Sassy, Flirty, Soft, Angry, Confused, Suspicious, Sad, Surprised, Scared, InLove};

[CreateAssetMenu(fileName = "New Lemon Conversation", menuName = "Conversation")]
public class LemonDialogueSequence : ScriptableObject
{
    public EmotionType emotionType;
    public string[] dialogueLines;
    public Question questionsAsked;
    public LemonDialogueSequence nextConversation;
}
