using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Relationships", menuName = "EmotionRelationships")]
public class EmotionsAndSprites : ScriptableObject
{
    public SpriteRenderer spriteRenderer;
    public Sprite currentSprite;
    public List<Moods> Emoticon(Moods _moods, Emotion _emotion)
    {
        switch (_emotion)
        { 
            case Emotion.Default:
                currentSprite = _moods.defaultMood;
                break; 
            case Emotion.Happy:
                currentSprite = _moods.happy;
                break;
            case Emotion.Sassy:
                currentSprite = _moods.sassy;
                break;
            case Emotion.Flirty:
                currentSprite = _moods.flirty;
                break;
            case Emotion.Soft:
                currentSprite = _moods.soft;
                break;
            case Emotion.Angry:
                currentSprite = _moods.angry;
                break;
            case Emotion.Confused:
                currentSprite = _moods.confused;
                break;
            case Emotion.Sad:
                currentSprite = _moods.sad;
                break;
            case Emotion.Surprised:
                currentSprite = _moods.surprised;
                break;
            case Emotion.Scared:
                currentSprite = _moods.scared;
                break;
            case Emotion.InLove:
                currentSprite = _moods.inLove;
                break;
            default:
                currentSprite = _moods.defaultMood;
                break;
        }
        return default;
    }

     public void Start()
    {
        spriteRenderer.sprite = currentSprite;
    }
}
[System.Serializable]
public struct Moods
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
