using UnityEngine.UI;


using UnityEngine;

public class EmotionEmoticonImageSystem : MonoBehaviour
{
    public enum EmotionType {Neutral, Happy, Sassy, Flirty, Soft, Angry, Confused, Sad, Surprised, Scared, InLove};
    [SerializeField] private Image[] emotionImages;

    public Image defaultEmotionImage;



    // Start is called before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnDialogueLineSpoken(string dialogueLine)
    {
        EmotionType emotionType = AnalyzeSentiment(dialogueLine);
        
        defaultEmotionImage = emotionImages[(int)emotionType];
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
