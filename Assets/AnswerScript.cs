using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript : MonoBehaviour
{

    public bool isCorrect = false;
    public QuizManager QM;
    


    public void Answer()
    {
        if(isCorrect)
        {
            QM.correct();
            Debug.Log("correct");
        }
        else
        {
            QM.wrong();
            Debug.Log("wrong");
        }
    }
}
