using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Atlas : MonoBehaviour
{
    [SerializeField] private SpriteAtlas atlas;
    public string atlasName;
    
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = atlas.GetSprite(atlasName);
    }
}
