using UnityEngine;

public class PlayerChoicesLemonDialogue : MonoBehaviour
{   
    public LemonSoloConversation lemonSoloConversation;
    public int optionIndex;
    public string choiceText;
    void Update()
    {
        if (lemonSoloConversation.conversationTypes[optionIndex] == ConversationType.Branch)
        {
            if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return))
            {
                choiceText = lemonSoloConversation.optionText[optionIndex];
            }
        }

    }

}
