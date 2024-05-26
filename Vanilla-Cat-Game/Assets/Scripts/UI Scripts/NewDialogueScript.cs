using UnityEngine;

public class NewDialogueScript : MonoBehaviour
{
    [SerializeField,TextArea(1,6)] string[] newLines;
    [SerializeField] private UIDialoguePrefab dialogueManager;


    void Start()
    {
        dialogueManager.SetDialogueLines(newLines);
    }

    public void NewScript(string lineOne, string lineTwo, string lineThree, string lineFour, string lineFive, string lineSix)
    {
        newLines = new string[] { lineOne, lineTwo, lineThree, lineFour, lineFive, lineSix };
    }

}
