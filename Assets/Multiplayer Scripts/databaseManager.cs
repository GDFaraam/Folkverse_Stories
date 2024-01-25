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
    public InputField passwordClue;
    public TextMeshProUGUI passwordClueIndicator;
    public TextMeshProUGUI errorIndicator;
    private string userID;
    private DatabaseReference reference;

    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference; 
    }

    // ... (previous code)

    public void signUp()
    {
        UISound.Instance.UIOpen();
        if (string.IsNullOrEmpty(username.text) || string.IsNullOrEmpty(password.text) || string.IsNullOrEmpty(confirmPass.text) || string.IsNullOrEmpty(passwordClue.text))
        {
            Debug.Log("Please fill in all fields");
            return;
        }

        if (password.text != confirmPass.text)
        {
            Debug.Log("Password and confirm password do not match");
            username.text = "";
            password.text = "";
            confirmPass.text = "";
            passwordClue.text = ""; // Clear password clue field
            return;
        }

        string nickname = username.text;
        PlayerPrefs.SetString("PlayerNickname", nickname);

        StartCoroutine(GetUsername((string uN) =>
        {
            if (uN != username.text)
            {
                username.text = "";
                password.text = "";
                confirmPass.text = "";
                passwordClue.text = ""; // Clear password clue field
                Debug.Log("User already registered");
            }
        }));
    }

    // ... (other methods remain unchanged)

    public IEnumerator GetUsername(System.Action<string> onCallback)
    {
        var userName = reference.Child("users").Child(username.text).GetValueAsync();
        yield return new WaitUntil(predicate: () => userName.IsCompleted);
        if (userName != null)
        {
            DataSnapshot ss = userName.Result;

            try
            {
                onCallback.Invoke(ss.Value.ToString());
                Debug.Log("name sent");
            }
            catch (System.Exception)
            {
                if (password.text == confirmPass.text)
                {
                    User newUser = new User(password.text, passwordClue.text);                    string json = JsonUtility.ToJson(newUser);
                    reference.Child("users").Child(username.text).SetRawJsonValueAsync(json);
                    username.text = "";
                    password.text = "";
                    confirmPass.text = "";
                    passwordClue.text = ""; // Clear password clue field
                    SceneManager.LoadScene("LOADING TO MAIN");
                    Debug.Log("registered");
                }
                else
                {
                    username.text = "";
                    password.text = "";
                    confirmPass.text = "";
                    passwordClue.text = ""; // Clear password clue field
                    Debug.Log("pass and confirm pass are not the same");
                }

            }
        }
    }

    [System.Serializable]
    public class User
    {
        public string password;
        public string passwordClue;

        // Default constructor for JSON deserialization
        public User()
        {
        }

        // Constructor with parameters
        public User(string password, string passwordClue)
        {
            this.password = password;
            this.passwordClue = passwordClue;
        }
    }


    // ... (other methods remain unchanged)


    // ... (previous code)

    public IEnumerator GetPassword(System.Action<string, string> onCallback)
    {
        var userData = reference.Child("users").Child(loginUsername.text).GetValueAsync();
        yield return new WaitUntil(predicate: () => userData.IsCompleted);

        if (userData != null)
        {
            DataSnapshot snapshot = userData.Result;

            if (snapshot.HasChild("password"))
            {
                string password = snapshot.Child("password").Value.ToString();
                string passwordClue = snapshot.HasChild("passwordClue") ? snapshot.Child("passwordClue").Value.ToString() : "";

                onCallback.Invoke(password, passwordClue);
            }
            else
            {
                Debug.Log("failed");

                errorIndicator.text = "Username doesn't exist!";
                passwordClueIndicator.text = "";
                loginUsername.text = "";
                loginPassword.text = "";
            }
        }
    }

    public void authenticatePassword()
    {
        UISound.Instance.UIOpen();
        string nickname = loginUsername.text;
        PlayerPrefs.SetString("PlayerNickname", nickname);
        StartCoroutine(GetPassword((string savedPassword, string passwordClue) =>
        {
            if (savedPassword == loginPassword.text)
            {
                PlayerPrefs.SetString("userID", loginUsername.text);
                Debug.Log("success");
                loginPassword.text = "";
                loginUsername.text = "";
                SceneManager.LoadScene("LOADING TO MAIN");
                Debug.Log("Your current userID is " + PlayerPrefs.GetString("userID"));
            }
            else
            {
                Debug.Log("failed");

                if (string.IsNullOrEmpty(savedPassword))
                {
                    Debug.Log("failed");
                }
                else
                {
                    errorIndicator.text = "Incorrect password!";
                    passwordClueIndicator.text = string.IsNullOrEmpty(passwordClue) ? "This account has no password clues" : "Password clue: " + passwordClue;
                    loginPassword.text = "";
                }
            }
        }));

        StartCoroutine(ResetIndicator());
    }

    IEnumerator ResetIndicator(){
        yield return new WaitForSeconds(3f);
        errorIndicator.text = "";
    }
}
