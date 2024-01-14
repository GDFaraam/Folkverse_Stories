using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update

    public InputField name;
    public InputField section;
    public string StoryName;
    public int score;
    public string StringScore;
    public Text typeExamString;

    private DatabaseReference reference;

    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference; 
    }

    // Update is called once per frame
    void Update()
    {
        StringScore = score.ToString();
    }

    public void startTest()
    {
        if (string.IsNullOrEmpty(name.text) || string.IsNullOrEmpty(section.text))
        {
            Debug.Log("Please fill in all fields");
            return;
        }


        StartCoroutine(GetUsername((string uN) => 
        {
            if(uN != name.text)
            {
                name.text = "";
                section.text = "";
                Debug.Log("Already taken the exam");
            }
        })); 
    }

    public IEnumerator GetUsername(System.Action<string> onCallback)
    { 
        var userName = reference.Child("Exam").Child(name.text).
        GetValueAsync();
        yield return new WaitUntil(predicate: () => userName.IsCompleted);
        if(userName != null)
        {
            DataSnapshot ss = userName.Result;
        
        try
        {
            onCallback.Invoke(ss.Value.ToString());
            Debug.Log("name sent");
        }
        catch (System.Exception)
        {
                Exam newExam = new Exam(this.StringScore);
                string json = JsonUtility.ToJson(newExam);
                reference.Child("exam").Child(StoryName).Child(section.text).Child(name.text).Child(typeExamString.text).SetRawJsonValueAsync(json);
                name.text = "";
                Debug.Log("score sent");            
        }
        }
    
    }
}
