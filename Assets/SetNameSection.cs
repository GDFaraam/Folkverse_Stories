using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetNameSection : MonoBehaviour
{
    public InputField name;
    public InputField section;

    void Start(){
        name.text = PlayerPrefs.GetString("PlayerNickname");
        section.text = PlayerPrefs.GetString("Section");
    }
}
