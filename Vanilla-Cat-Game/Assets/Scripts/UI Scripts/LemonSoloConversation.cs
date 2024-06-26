using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LemonSoloConversation : ScriptableObject
{
    public ConversationType[] conversationTypes;
    [TextArea(1,6)] public string[] dialogue;
    public string[] optionText;
    public List<Sprite> emotions;
    public LemonSoloConversation option1;
    public LemonSoloConversation option2;
    public LemonSoloConversation option3;
    public LemonSoloConversation option4;
}
