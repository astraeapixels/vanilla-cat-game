
using UnityEngine;
public class TriggerQuestion : LemonDialogueChoices
{
   [SerializeField] private LemonDialogueChoices dialogueChoices;
    public void OnEnter()
    {
        dialogueChoices.LemonHasToChoose += dialogueChoices.Initialize;
    }

    // Update is called once per frame
    public void OnDestroy()
    {
        dialogueChoices.LemonHasToChoose -= dialogueChoices.Initialize;
    }
}
