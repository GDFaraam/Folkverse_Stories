using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class KickMuteBehavior : MonoBehaviour
{
    public string playerID;
    private KickMute kickMute;

    public Sprite[] images;

    public Image muteButton;
    public Image muteAllButton;

    private bool muted = false;
    private bool allMuted = false;

    public void KickPlayerButton()
    {
        KickMute.instance.Kick(playerID);
    }

    public void MutePlayerButton()
    {
        KickMute.instance.Mute(playerID);
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
        KickMute.instance.MuteStudents();
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
