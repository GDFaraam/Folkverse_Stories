using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class KickMuteBehavior : MonoBehaviour
{
    public int playerID;
    private KickMute kickMute;

    public Sprite[] images;

    public Image muteButton;
    public Image muteAllButton;

    private bool muted = false;
    private bool allMuted = false;

    void Start()
    {
        GameObject kickMuteObject = GameObject.FindWithTag("KickMuteScript");

        if (kickMuteObject != null)
        {
            kickMute = kickMuteObject.GetComponent<KickMute>();
        }
        else
        {
            Debug.LogError("KickMute script not found.");
        }
    }

    public void KickPlayerButton()
    {
        kickMute.Kick(playerID);
    }

    public void MutePlayerButton()
    {
        kickMute.Mute(playerID);
        if (muted){
        muteButton.sprite = images[0];
        muted = false;
        }
        else if (!muted){
        muteButton.sprite = images[1];
        muted = true;
        }
    }

    public void MuteAll()
    {
        kickMute.MuteStudents();
        if (allMuted){
        muteAllButton.sprite = images[2];
        allMuted = false;
        }
        else if (!allMuted){
        muteAllButton.sprite = images[3];
        allMuted = true;
        }
    }
}
