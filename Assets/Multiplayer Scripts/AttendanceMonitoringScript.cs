using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using TMPro;

public class AttendanceMonitoringScript : MonoBehaviour
{
    private DatabaseReference reference;

    public GameObject roomButtonIndicatorPrefab;
    public GameObject namesList;
    public GameObject content;
    public GameObject namesListContent;

    public GameObject ChooseButton;
    public GameObject StudentList;
    public GameObject ChooseRoom;

    void Start()
    {
        ChooseButton.SetActive(false);
        StudentList.SetActive(false);

        string userID = PlayerPrefs.GetString("userID");

        reference = FirebaseDatabase.DefaultInstance.RootReference;

        DatabaseReference userReference = reference.Child("users").Child(userID);

        DatabaseReference roomsReference = userReference.Child("roomsCreated");

        roomsReference.ValueChanged += HandleRoomsValueChanged;
    }

    void HandleRoomsValueChanged(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }

        if (args.Snapshot != null && args.Snapshot.HasChildren)
        {
            ClearContent();

            foreach (var roomSnapshot in args.Snapshot.Children)
            {
                string roomName = roomSnapshot.Key;

                GameObject roomButtonIndicator = Instantiate(roomButtonIndicatorPrefab, content.transform);

                TextMeshProUGUI textMeshPro = roomButtonIndicator.GetComponentInChildren<TextMeshProUGUI>();
                if (textMeshPro != null)
                {
                    textMeshPro.text = roomName;
                }
                else
                {
                    Debug.LogError("TextMeshProUGUI component not found in the roomButtonIndicatorPrefab.");
                }
            }
        }
    }

    void ClearContent()
    {
        foreach (Transform child in content.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void PlayersJoined(){
        
        string roomName = PlayerPrefs.GetString("ChosenRoom");

        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;

        string userID = PlayerPrefs.GetString("userID");

        DatabaseReference userReference = reference.Child("users").Child(userID);

        DatabaseReference roomsReference = userReference.Child("roomsCreated");

        DatabaseReference roomNodeReference = roomsReference.Child(roomName);

        DatabaseReference playersReference = roomNodeReference.Child("Players Joined");

        playersReference.ValueChanged += NameListHandleRoomsValueChanged;
    }

    public void RecordAttendance(){
        string roomName = PlayerPrefs.GetString("ChosenRoom");

        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;

        string userID = PlayerPrefs.GetString("userID");

        DatabaseReference userReference = reference.Child("users").Child(userID);

        DatabaseReference roomsReference = userReference.Child("roomsCreated");

        DatabaseReference roomNodeReference = roomsReference.Child(roomName);

        DatabaseReference playersReference = roomNodeReference.Child("Recorded Attendance");

        playersReference.ValueChanged += NameListHandleRoomsValueChanged;
    }

    void NameListHandleRoomsValueChanged(object sender, ValueChangedEventArgs args)
    {
        ChooseButton.SetActive(false);

        StudentList.SetActive(true);

        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }

        if (args.Snapshot != null && args.Snapshot.HasChildren)
        {
            NamesListClearContent();

            foreach (var playerSnapshot in args.Snapshot.Children)
            {
                string playerName = playerSnapshot.Key;

                GameObject roomNameListIndicator = Instantiate(namesListContent, namesList.transform);

                TextMeshProUGUI textMeshPro = roomNameListIndicator.GetComponent<TextMeshProUGUI>();
                if (textMeshPro != null)
                {
                    textMeshPro.text = playerName;
                }
                else
                {
                    Debug.LogError("TextMeshProUGUI component not found in the roomButtonIndicatorPrefab.");
                }
            }
        }
    }

    void NamesListClearContent()
    {
        foreach (Transform child in namesList.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void GoToChooseButton(){
        ChooseButton.SetActive(true);
        ChooseRoom.SetActive(false);
    }
    public void BackToChooseButton(){
        StudentList.SetActive(false);
        ChooseButton.SetActive(true);
    }
    public void BackToChooseRoom(){
        ChooseButton.SetActive(false);
        ChooseRoom.SetActive(true);
    }
    
}
