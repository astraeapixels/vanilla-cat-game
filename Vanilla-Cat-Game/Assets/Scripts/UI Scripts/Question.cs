using UnityEngine;

[CreateAssetMenu(fileName = "Questions", menuName = "QuestionsToAsk")]
public class Question : ScriptableObject
{
    [TextArea(1, 6)]
    public string questionAsked;
    public LemonsChoice[] choices;
}

[System.Serializable]
public struct LemonsChoice
{
    [TextArea(1, 6)]
    public string choiceLines;
    public string text;
    //public Conversation conversation;
}