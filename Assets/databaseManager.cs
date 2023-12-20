using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Firebase.Database;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class databaseManager : MonoBehaviour
{

    public InputField username;
    public InputField password;
    public InputField confirmPass;
    public InputField loginUsername;
    public InputField loginPassword;
    private string userID;
    private DatabaseReference reference;
    // Start is called before the first frame update
    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void signUp()
    {
        string nickname = username.text;
        PlayerPrefs.SetString("PlayerNickname", nickname);
        StartCoroutine(GetUsername((string uN) => 
        {
            if(uN != username.text)
            {
                username.text = "";
                password.text = "";
                confirmPass.text = "";
                Debug.Log("user already registered");
            }
        })); 
        
        
    }

    public IEnumerator GetUsername(System.Action<string> onCallback)
    {
        var userName = reference.Child("users").Child(username.text).
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
            if(password.text == confirmPass.text)
            {
                User newUser = new User(this.password.text);
                string json = JsonUtility.ToJson(newUser);
                reference.Child("users").Child(username.text).SetRawJsonValueAsync(json);
                username.text = "";
                password.text = "";
                confirmPass.text = "";
                SceneManager.LoadScene("LOADING TO MAIN");
                Debug.Log("registered");  
            }
            else
            {
                username.text = "";
                password.text = "";
                confirmPass.text = "";
                Debug.Log("pass and confirm pass is not the same");
            }
            
        }
        }
    
    }

    public IEnumerator GetPassword(System.Action<string> onCallback)
    {
        var password = reference.Child("users").Child(loginUsername.text).Child("password").GetValueAsync();
        yield return new WaitUntil(predicate: () => password.IsCompleted);
        if(password != null)
        {
            DataSnapshot ss = password.Result;
        
        try
        {   
            onCallback.Invoke(ss.Value.ToString());
        }
        catch (System.Exception)
        {
            Debug.Log("failed");
            loginPassword.text = "";
            loginUsername.text = "";    
        }
        }
    
    }

    

    public void authenticatePassword()
    {
        string nickname = loginUsername.text;
        PlayerPrefs.SetString("PlayerNickname", nickname);
        StartCoroutine(GetPassword((string name) => 
        {
            if(name == loginPassword.text)
            {
                Debug.Log("success");
                loginPassword.text = "";
                loginUsername.text = "";
                SceneManager.LoadScene("LOADING TO MAIN");
            }
            else
            {
                Debug.Log("failed");
                loginPassword.text = "";
                loginUsername.text = "";
            }
        })); 
    }

}
