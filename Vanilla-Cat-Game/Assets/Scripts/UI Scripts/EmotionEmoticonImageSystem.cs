using UnityEngine.UI;
using UnityEngine;
using TMPro;


public class EmotionEmoticonImageSystem : MonoBehaviour
{
    

     public enum EmotionType {Neutral, Happy, Sassy, Flirty, Soft, Angry, Confused, Sad, Surprised, Scared, InLove};
    [SerializeField] private Image[] emotionImages;

    public Image defaultEmotionImage;

    [SerializeField] private TMP_Text textComponent;

    
    public void Start()
    {

    }
    

    // Start is called before the first frame update
     public void ProcessText()
    {
        string[] strings = textComponent.text.Split('\n');
        for (int i = 0; i < strings.Length; i++)
        {
            string str = strings[i];
            EmotionType emotionType = AnalyzeSentiment(str);
            Image currentImage = emotionImages[(int)emotionType];
            defaultEmotionImage = currentImage;
        }
    }

    EmotionType AnalyzeSentiment(string dialogueLine)
    {
        if(dialogueLine.Contains("Lemon"))
        {
            return EmotionType.Happy; 
        }
        else if(dialogueLine.Contains("mom"))
        {
            return EmotionType.Neutral;
        }else 
        {
            return EmotionType.Neutral;
        }
    }
}
