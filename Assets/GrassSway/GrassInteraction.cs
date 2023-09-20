using UnityEngine;
using System.Collections;

public class GrassInteraction : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public SpriteRenderer[] spriteUpper;
    public SpriteRenderer[] spriteLower;
    private bool tallGrass = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Grass")){
            UpdateWindDirection(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Enemy")){
            UpdateWindDirection(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Tall Grass")){
            tallGrass = true;
            UpdateWindDirection(collision.gameObject);
            SpriteRenderer spriteRenderer = collision.gameObject.GetComponent<SpriteRenderer>();
            
            if (spriteRenderer != null)
            {
                Color currentColor = spriteRenderer.color;
                currentColor.a = 0.7f;

                spriteRenderer.color = currentColor;
            }
        }
    }


    private void UpdateWindDirection(GameObject grassObject)
    {
        Renderer grassRenderer = grassObject.GetComponent<Renderer>();
        if (grassRenderer == null)
        {
            Debug.LogWarning("Collided object doesn't have a Renderer component.");
            return;
        }

        MaterialPropertyBlock propBlock = new MaterialPropertyBlock();
        grassRenderer.GetPropertyBlock(propBlock);
        propBlock.SetFloat("_WindStrength", 3f);
        propBlock.SetFloat("_WindInfluenceMask", 3.5f);
        if (tallGrass){
            propBlock.SetFloat("_WindSpeed", 1.5f);
        }
        if (playerMovement.playerSpeed == 5f){
            propBlock.SetFloat("_WindStrength", 5f);
        }
        grassRenderer.SetPropertyBlock(propBlock);
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Grass")) 
        {
            UpdateWindDirectionExit(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Enemy")) 
        {
            UpdateWindDirectionExit(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Tall Grass")){
            tallGrass = false;
            UpdateWindDirectionExit(collision.gameObject);
            SpriteRenderer spriteRenderer = collision.gameObject.GetComponent<SpriteRenderer>();
            
            if (spriteRenderer != null)
            {
                Color currentColor = spriteRenderer.color;
                currentColor.a = 1f;

                spriteRenderer.color = currentColor;
            }
        }
    }

    private void UpdateWindDirectionExit(GameObject grassObject)
    {
        Renderer grassRenderer = grassObject.GetComponent<Renderer>();
        if (grassRenderer == null)
        {
            Debug.LogWarning("Collided object doesn't have a Renderer component.");
            return;
        }

        MaterialPropertyBlock propBlock = new MaterialPropertyBlock();
        grassRenderer.GetPropertyBlock(propBlock);
        propBlock.SetFloat("_WindStrength", 1f);
        propBlock.SetFloat("_WindInfluenceMask", 4f);
        grassRenderer.SetPropertyBlock(propBlock);
    }
}
