using UnityEngine;

[CreateAssetMenu(fileName = "EmotionAndDialogueRelationships", menuName = "EmotionAndDialogueRelationships")]
public class EmotionAndDialogueRelationships : ScriptableObject
{
    public Emotion[] emotionType;
    public string[] dialogueTexts;// = new string [Enum.GetValues(typeof(Emotion)).Length];

    public void InitializeDialogueTexts()
    {
        dialogueTexts = new string[emotionType.Length];
        for (int i = 0; i < emotionType.Length; i++)
        {
            dialogueTexts[i] = "Hi, my name is Lemon" + emotionType[i];
        }
    }
}
public enum Emotion {Default, Happy, Sassy, Flirty, Soft, Angry, Confused, Sad, Surprised, Scared, InLove};
