using UnityEngine;

public class SavePlayerChoices : MonoBehaviour
{
    public GameObject player;
    public SerializedData serializedData;
    public LemonSoloConversation lemonSoloConversation;
    public string saveChoicesData;
    public string restoreChoices;
    private int optionIndex;

    void Start ()
    {
        serializedData = new SerializedData();
        RestoreChoices();
    }
    void Update()
    {
        if (lemonSoloConversation.conversationTypes[optionIndex] == ConversationType.Branch)
        {
            if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return))
            {
                SavePosition();
            }
        }
    }

    // Update is called once per frame
    void SavePosition()
    {
        serializedData.option1 = lemonSoloConversation.optionText[0];
        serializedData.option2 = lemonSoloConversation.optionText[1];
        serializedData.option3 = lemonSoloConversation.optionText[2];
        serializedData.option4 = lemonSoloConversation.optionText[3];
        saveChoicesData = JsonUtility.ToJson(serializedData);
        PlayerPrefs.SetString ("PlayerDialogueChoicesforLemon", saveChoicesData);
        Debug.Log(saveChoicesData);
    }

    void RestoreChoices()
    {
        restoreChoices = PlayerPrefs.GetString("PlayerDialogueChoicesforLemon");
        SerializedData	serializedData1 = JsonUtility.FromJson<SerializedData>(restoreChoices);
        if (serializedData1 != null)
        {   LemonSoloConversation newConversation = new LemonSoloConversation();
			newConversation.optionText[0] = serializedData1.option1;
            newConversation.optionText[1] = serializedData1.option2;
            newConversation.optionText[2] = serializedData1.option3;
            newConversation.optionText[3] = serializedData1.option4;
            lemonSoloConversation.optionText[optionIndex] = newConversation.optionText[optionIndex];
		}
    }
}

