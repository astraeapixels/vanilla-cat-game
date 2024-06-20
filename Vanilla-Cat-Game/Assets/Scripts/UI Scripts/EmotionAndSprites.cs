using UnityEngine;

[CreateAssetMenu(fileName = "Relationships", menuName = "EmotionRelationships")]
public class EmotionsAndSprites : ScriptableObject
{ 
    public Sprite defaultMood;
    public Sprite happy;
    public Sprite sassy;
    public Sprite flirty;
    public Sprite soft;
    public Sprite angry;
    public Sprite confused;
    public Sprite sad;
    public Sprite surprised;
    public Sprite scared;
    public Sprite inLove;

}


public enum Emotion {Default, Happy, Sassy, Flirty, Soft, Angry, Confused, Sad, Surprised, Scared, InLove};
