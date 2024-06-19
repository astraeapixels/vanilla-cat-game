using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
public class EmotionAndDialogueRelationships : MonoBehaviour
{
    
    public Sprite[] currentEmotion;
    public Emotion[] emotion;
    [SerializeField] private Image defaultEmotion;
    public SpriteRenderer spriteRenderer;
    public List<GameObject> emoticonSprites;
    public GameObject[] currentMood;
    public void Start()
    {   
     emoticonSprites = new List<GameObject>(currentEmotion.Length);
     ChangeMood();
    }
    public GameObject ChangeMood()
    { 
        for (int i = 0; i < emoticonSprites.Count; i++)
        {
            emoticonSprites[i].gameObject.GetComponent<SpriteRenderer>().sprite = currentEmotion[i];
            currentMood[i] = emoticonSprites[i];
        switch(i)
            {
                case 0:
                    emoticonSprites[0].gameObject.GetComponent<SpriteRenderer>().sprite = currentEmotion[0];
                break;
                case 1:
                    emoticonSprites[1].gameObject.GetComponent<SpriteRenderer>().sprite = currentEmotion[1];
                break;
                case 2:
                    emoticonSprites[2].gameObject.GetComponent<SpriteRenderer>().sprite = currentEmotion[3];
                break;
                case 3:
                    emoticonSprites[3].gameObject.GetComponent<SpriteRenderer>().sprite = currentEmotion[4];
                break;
                case 4:
                    emoticonSprites[3].gameObject.GetComponent<SpriteRenderer>().sprite = currentEmotion[5];
                break;
                case 5:
                    emoticonSprites[3].gameObject.GetComponent<SpriteRenderer>().sprite = currentEmotion[6];
                break;
                case 6:
                    emoticonSprites[3].gameObject.GetComponent<SpriteRenderer>().sprite = currentEmotion[7];
                break;
                case 7:
                    emoticonSprites[3].gameObject.GetComponent<SpriteRenderer>().sprite = currentEmotion[8];
                break;
                case 8:
                    emoticonSprites[3].gameObject.GetComponent<SpriteRenderer>().sprite = currentEmotion[9];
                break;
                case 9:
                    emoticonSprites[3].gameObject.GetComponent<SpriteRenderer>().sprite = currentEmotion[9];
                break;
                case 10:
                emoticonSprites[10].gameObject.GetComponent<SpriteRenderer>().sprite = currentEmotion[10];
                break;
                default:
                defaultEmotion.sprite = currentEmotion[0];
                break;
            }
        }
        return default;
    }
    public void Destroy(GameObject sprites)
    {
        emoticonSprites.Remove(sprites);
    }
}
public enum Emotion {Default, Happy, Sassy, Flirty, Soft, Angry, Confused, Sad, Surprised, Scared, InLove, length };
