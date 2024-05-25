using UnityEngine;

public class NewDialogueScript : MonoBehaviour
{
    [SerializeField,TextArea(1,6)] string[] newLines;
    [SerializeField] UIDialoguePrefab dialogueManager;


    void Start()
    {
        dialogueManager.SetDialogueLines(newLines);
    }

    // Update is called once per frame
    public void NewScript(string lineOne, string lineTwo, string lineThree, string lineFour, string lineFive, string lineSix)
    {
        newLines = new string[] { lineOne, lineTwo, lineThree, lineFour, lineFive, lineSix };
    }

}
