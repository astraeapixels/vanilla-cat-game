using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Relationships", menuName = "EmotionRelationships")]
public class EmotionsAndSprites : ScriptableObject
{
    public Moods moods;
    public Sprite[] currentEmotion;
    public Emotion emotion;
    [SerializeField] private Image defaultEmotion;
    public SpriteRenderer spriteRenderer;
    public List<GameObject> emoticonSprites;
    public Sprite currentSprite;
    public Sprite Emoticon(Moods _moods, Emotion _emotion)
    {
        currentSprite = _moods.defaultMood;
        
        if(_emotion == Emotion.Default)
        {
            currentSprite = _moods.defaultMood;
        }
        if(_emotion == Emotion.Happy)
        {
            currentSprite = _moods.happy;
        }
        if(_emotion == Emotion.Sassy)
        {
            currentSprite = _moods.sassy;
        }
         if(_emotion == Emotion.Flirty)
        {
            currentSprite = _moods.flirty;
        }
        if(_emotion == Emotion.Soft)
        {
            currentSprite = _moods.soft;
        }
           if(_emotion == Emotion.Angry)
        {
            currentSprite = _moods.angry;
        }
        if(_emotion == Emotion.Confused)
        {
            currentSprite = _moods.confused;
        }
         if(_emotion == Emotion.Sad)
        {
            currentSprite = _moods.sad;
        }
        if(_emotion == Emotion.Surprised)
        {
            currentSprite = _moods.surprised;
        }
        if(_emotion == Emotion.Scared)
        {
            currentSprite = _moods.scared;
        }
        if(_emotion == Emotion.InLove)
        {
            currentSprite = _moods.inLove;
        }
        return default;
    }

     public void Start()
    {
        spriteRenderer.sprite = currentSprite;
        emoticonSprites = new List<GameObject>(currentEmotion.Length);
    }
}

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
