using System.Collections.Generic;
using PrimeTween;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LemonDialogueChoices : MonoBehaviour
{
    [SerializeField] private Question question;
    [SerializeField] private TMP_Text questionText;
    //[SerializeField] private GameObject lemonQuestionsManager;
    [SerializeField] private Button choiceButton;
    [SerializeField] private LemonsChoice choice;
    private int lineIndex;
    private bool didQuestionStart;
    private float typingTime = .20f;

    private List<LemonChoicesManager> choiceManager = new List<LemonChoicesManager>();

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
            Initialize();
    }

    private void Initialize()
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
            Tween.StopAll(questionText);
            RemoveChoices();
        }
    }
    private void ShowChoices()
    {
        lineIndex++;
        for(int lineIndex = 0; lineIndex < question.choices.Length; lineIndex++)
        {
            LemonChoicesManager c = LemonChoicesManager.AddChoiceButton(choiceButton, question.choices[lineIndex], lineIndex);
            choiceManager.Add(c);
            ShowLines(questionText, question.questionAsked, typingTime);
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
