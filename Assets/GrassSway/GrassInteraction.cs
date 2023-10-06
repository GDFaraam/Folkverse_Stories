using UnityEngine;
using System.Collections;

public class GrassInteraction : MonoBehaviour
{
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
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tree"))
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
        if (collision.gameObject.CompareTag("Boy"))
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
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
        if (tallGrass){
            propBlock.SetFloat("_WindStrength", 1f);
            propBlock.SetFloat("_WindInfluenceMask", 1f);
            propBlock.SetFloat("_WindScale", 2f);
        }
        else {
            propBlock.SetFloat("_WindStrength", 3f);
            propBlock.SetFloat("_WindInfluenceMask", 3.5f);
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
            UpdateWindDirectionExit(collision.gameObject);
            tallGrass = false;
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
        propBlock.SetFloat("_WindScale", 1f);
        grassRenderer.SetPropertyBlock(propBlock);
    }
}
