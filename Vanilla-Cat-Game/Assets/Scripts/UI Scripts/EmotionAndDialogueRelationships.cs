using UnityEngine;


[CreateAssetMenu(fileName = "EmotionAndDialogueRelationships", menuName = "EmotionAndDialogueRelationships")]
public class EmotionAndDialogueRelationships : ScriptableObject
{
    public Emotion[] emotionType;
    [TextArea(1,6)] public string[] dialogueTexts;
    public Sprite[] emoticonsImages;
    public void InitializeDialogueTexts()
    {
        dialogueTexts = new string[emotionType.Length];
        for (int i = 0; i < emotionType.Length; i++)
        {
            dialogueTexts[i] = "Hi, my name is Lemon" + emotionType[i];
        }
    }

    public void InitializeEmoticonImages()
    {
        for(int i = 0; i < emotionType.Length; i++)
        {   
            emoticonsImages[i] = Resources.Load<Sprite>("Assets/Sprites/UI/Lemon Dialogue Portrait Sprite 1.png" + emotionType[i]);
        }
    }
}
public enum Emotion {Default, Happy, Sassy, Flirty, Soft, Angry, Confused, Sad, Surprised, Scared, InLove};
