
using UnityEngine;
public class TriggerQuestion : LemonDialogueChoices
{
    [SerializeField] private LemonDialogueChoices dialogueChoices;
    public void Start()
    {
        dialogueChoices.LemonHasToChoose += dialogueChoices.Initialize;
    }

    public void OnDestroy()
    {
        dialogueChoices.LemonHasToChoose -= dialogueChoices.Initialize;
    }
}
