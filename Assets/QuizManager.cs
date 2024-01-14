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
        generateQuestion();
    }

    void Update()
    {

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

            if(QnA[currentQuestion].correctAnswer == i+1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
                Debug.Log("koriq");
            }

        }
    }
}
