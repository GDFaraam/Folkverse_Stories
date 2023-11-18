using UnityEngine;
using System.Collections;

public class GrassInteraction : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Grass")){
            UpdateWindDirection(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Tall Grass")){
            UpdateWindDirection(collision.gameObject);
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

        propBlock.SetFloat("_WindStrength", +6.5f);
        grassRenderer.SetPropertyBlock(propBlock);

        StartCoroutine(SmoothReturnToNormalWind(grassRenderer, propBlock, 0.5f));
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
        propBlock.SetFloat("_WindScale", 1f);
        propBlock.SetFloat("_WindSpeed", 1f);
        propBlock.SetFloat("_WindInfluenceMask", 1f);
        grassRenderer.SetPropertyBlock(propBlock);
    }

    private IEnumerator SmoothReturnToNormalWind(Renderer grassRenderer, MaterialPropertyBlock propBlock, float duration)
    {
        float targetWindStrength = 1f;
        float startTime = Time.time;

        while (Time.time - startTime < duration)
        {
            float t = (Time.time - startTime) / duration;
            propBlock.SetFloat("_WindStrength", Mathf.MoveTowards(propBlock.GetFloat("_WindStrength"), targetWindStrength, t));

            grassRenderer.SetPropertyBlock(propBlock);

            yield return null;
        }

        propBlock.SetFloat("_WindStrength", targetWindStrength);

        grassRenderer.SetPropertyBlock(propBlock);
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
}
