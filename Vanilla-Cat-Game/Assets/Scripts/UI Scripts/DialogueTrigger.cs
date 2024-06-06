using UnityEngine;

public class DialogueTrigger : UIDialoguePrefab
{
    [SerializeField] private UIDialoguePrefab dialogueManager;
    public void Start()
    {
        dialogueManager.DialoguePlayed += dialogueManager.PlayerInput;
    }

    public void OnDestroy()
    {
        dialogueManager.DialoguePlayed -= dialogueManager.PlayerInput;
    }
}