using UnityEngine;
using UnityEngine.UI;

//[System.Serializable]
//public class ConversationChangeEvent : UnityEvent<Conversation> {}

public class LemonChoicesManager : MonoBehaviour
{
    public LemonChoicesManager lemonChoicesManager;
    public LemonsChoice choice;
    //public ConversationChangeEvent conversationChangeEvent;


    public static LemonChoicesManager AddChoiceButton(Button choiceButton, LemonsChoice choice, int index)
    {

        Button defaultButton = Instantiate(choiceButton);
        defaultButton.name = "Choice " + (index + 1);
        defaultButton.gameObject.SetActive(true);

        LemonChoicesManager lemonChoicesManager = defaultButton.GetComponent<LemonChoicesManager>();
        lemonChoicesManager.choice = choice;
        return lemonChoicesManager;
    }

    // private void Start() 
    // {
    //     if (conversationChangeEvent == null)
    //         conversationChangeEvent = new ConversationChangeEvent();

    //     GetComponent<Button>().GetComponentInChildren<Text>().text = choice.text;
    // }

    // public void MakeChoice()
    // {
    //     conversationChangeEvent.Invoke(choice.conversation);
    // }
}
