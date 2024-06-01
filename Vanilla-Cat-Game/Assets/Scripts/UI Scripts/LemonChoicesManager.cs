using UnityEngine;
using UnityEngine.UI;

//[System.Serializable]
//public class ConversationChangeEvent : UnityEvent<Conversation> {}

public class LemonChoicesManager : MonoBehaviour
{
    public LemonChoicesManager lemonChoicesManager;
    public LemonsChoice choice;
    //public ConversationChangeEvent conversationChangeEvent;
    [SerializeField] private Button choiceOne, choiceTwo, choiceThree, choiceFour;

    public static LemonChoicesManager AddChoiceButton(Button choiceButton, LemonsChoice choice, int index)
    {

        // button.transform.SetParent(choiceButtonTemplate.transform.parent);
        // button.transform.localScale = Vector3.one;
        // button.transform.localPosition = new Vector3(0, index * buttonSpacing, 0);
        choiceButton.name = "Choice " + (index + 1);
        choiceButton.gameObject.SetActive(true);

        LemonChoicesManager lemonChoicesManager = choiceButton.GetComponent<LemonChoicesManager>();
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
