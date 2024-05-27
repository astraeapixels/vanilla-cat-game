using UnityEngine;

public class DialogueTrigger : UIDialoguePrefab
{
    [SerializeField] UIDialoguePrefab dialogueManager;
    // Start is called before the first frame update
    void Start()
    {
        dialogueManager.DialoguePlayed += dialogueManager.PlayerInput;
    }

    // Update is called once per frame
    void OnDestroy()
    {
        dialogueManager.DialoguePlayed -= dialogueManager.PlayerInput;

    }
}