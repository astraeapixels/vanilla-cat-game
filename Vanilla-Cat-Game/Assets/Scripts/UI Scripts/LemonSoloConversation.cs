using UnityEngine;

[CreateAssetMenu]
public class LemonSoloConversation : ScriptableObject
{
    public LemonConversationType convoType;
    [TextArea] public string[] dialogue;
    public string[] optionText;
    public LemonSoloConversation option1;
    public LemonSoloConversation option2;
    public LemonSoloConversation option3;
    public LemonSoloConversation option4;
}
