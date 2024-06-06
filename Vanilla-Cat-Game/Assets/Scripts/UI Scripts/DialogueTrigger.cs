using UnityEngine;

public class DialogueTrigger : UIDialoguePrefab
{
    [SerializeField] private UIDialoguePrefab dialogueManager;
    // Start is called before the first frame update
    public void OnEnter()
    {
        dialogueManager.DialoguePlayed += dialogueManager.PlayerInput;
    }

    // Update is called once per frame
    public void OnDestroy()
    {
        dialogueManager.DialoguePlayed -= dialogueManager.PlayerInput;

    }
}