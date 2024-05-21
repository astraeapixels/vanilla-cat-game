using UnityEngine;

public class NewDialogueScript : MonoBehaviour
{
    [SerializeField,TextArea(1,6)] string[] newLines;
    public UIDialoguePrefab dialogueManager;


    void Start()
    {
        dialogueManager.SetDialogueLines(newLines);
    }

    // Update is called once per frame
    public void NewScript(string lineOne, string lineTwo, string lineThree)
    {
        newLines = new string[] { lineOne, lineTwo, lineThree };
    }

}
