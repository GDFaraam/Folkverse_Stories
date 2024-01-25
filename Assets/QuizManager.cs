using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public List<QuestionsAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public GameObject testObj;
    public GameObject scoreSender;

    public Text QuestionTxt; 
    public ScoreManager SM;

    void Start()
    {
        ShuffleQuestions();
        generateQuestion();
    }

    void Update()
    {

    }

    void ShuffleQuestions()
    {
        for (int i = QnA.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            QuestionsAndAnswers temp = QnA[i];
            QnA[i] = QnA[randomIndex];
            QnA[randomIndex] = temp;
        }
    }

    public void generateQuestion()
    {
        if(QnA.Count > 0)
        {
            QuestionTxt.text = QnA[currentQuestion].Questions;
            setAnswers();
        }
        else
        {
            scoreSender.SetActive(true);
            testObj.SetActive(false);
        }
    }

    public void correct()
    {
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
        SM.score ++;
    }

    public void wrong()
    {
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    public void setAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];

            if(QnA[currentQuestion].correctAnswer == i)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
                Debug.Log("koriq");
            }
        }
    }
}
