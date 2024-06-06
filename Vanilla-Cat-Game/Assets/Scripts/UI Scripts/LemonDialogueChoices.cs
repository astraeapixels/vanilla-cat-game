using System.Collections.Generic;
using PrimeTween;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LemonDialogueChoices : MonoBehaviour
{
    [SerializeField] private Question question;
    [SerializeField] private TMP_Text questionText;
    [SerializeField] private Button choiceButton;
    [SerializeField] private LemonsChoice[] choice;
    private int lineIndex;
    private bool didQuestionStart;
    private float typingTime = .20f;

    public delegate void LemonsChoiceDelegate();
    public event LemonsChoiceDelegate LemonHasToChoose;


    [SerializeField] private List<LemonChoicesManager> choiceManager = new List<LemonChoicesManager>();

    private void RemoveChoices()
    {
        foreach(LemonChoicesManager c in choiceManager)
        {
            Destroy(c.gameObject);

            choiceManager.Clear();
        }
    }

    private void Update()
    {
        LemonHasToChoose?.Invoke();
    }

    public void Initialize()
    {
        if(!didQuestionStart)
        {
            StartQuestions();
        }
        else if(lineIndex == question.choices.Length)
        {
            ShowChoices();
        }else
        {
            questionText.text = question.questionAsked;
        }
    }
    private void ShowChoices()
    {
        lineIndex++;
        for(int lineIndex = 0; lineIndex < question.choices.Length; lineIndex++)
        {
            LemonChoicesManager c = LemonChoicesManager.AddChoiceButton(choiceButton, choice[lineIndex], lineIndex);
            choiceManager.Add(c);
            ShowLines(questionText, question.questionAsked, typingTime);
        }
        if(question.choices != null)
        {
            LemonChoicesManager c = LemonChoicesManager.AddChoiceButton(choiceButton, choice[lineIndex], lineIndex);
            questionText.text = c.choice.choiceLines;
            ShowLines(questionText, choice[lineIndex].choiceLines, typingTime);

        }
        else if(lineIndex == question.choices.Length)
        {
            Tween.StopAll(questionText);
            RemoveChoices();
        }
    }
    private void StartQuestions()
    {
        didQuestionStart = true;
        lineIndex = 0;
        Time.timeScale = .5f;
        ShowLines(questionText, question.questionAsked, typingTime);
    }


    private static Tween ShowLines(TMP_Text _questionText, string _question, float _typingTime)
    {
        _questionText.SetText(_question);
        int lineCount = _question.Length;
        float duration = _typingTime;
        return Tween.TextMaxVisibleCharacters(_questionText, 0, lineCount, duration, Ease.Linear);
    }
}
