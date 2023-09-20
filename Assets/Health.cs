using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject[] health;
    public Transform player;
    public RectTransform canvas;

    public GameObject healthPrefab;
    public int currentHealthIndex = 0;
    public bool gameOver = false;
    public EnemyScript enemyScript;
    public LineRender lineRenderer;

    private GameManager gm;
    private Vector3[] originalHealthPositions;

    void Start(){
        gm = GameManager.instance;
        originalHealthPositions = new Vector3[health.Length];
        for (int i = 0; i < health.Length; i++)
        {
            originalHealthPositions[i] = health[i].transform.position;
        }
    }

    public void DamageTaken()
    {
        if (currentHealthIndex < health.Length)
        {
        Destroy(health[currentHealthIndex]);
        }

        currentHealthIndex++;

        if (currentHealthIndex >= health.Length)
        {
        GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            DamageTaken();
            if (health.Length == 0)
            {
                GameOver();
            }
        }
    }

    public void GameOver()
    {
        if (!gameOver)
        {
            currentHealthIndex = 0;
            gameOver = true;
            player.transform.position = gm.spawnArea[0].transform.position;
            enemyScript.index = 0;

            for (int i = 0; i < health.Length; i++)
            {
                Destroy(health[i]);
                health[i] = Instantiate(healthPrefab, originalHealthPositions[i], Quaternion.identity);
                health[i].transform.SetParent(canvas, true); 
                gameOver = false;
                lineRenderer.checkPointReached = false;
                lineRenderer.checkPointIndex = 0;
                gm.resetCheckPoints();
            }
        }
    }

    public void ResetHealth()
    {
        if (!gameOver)
        {
            gameOver = true;
            for (int i = 0; i < health.Length; i++)
            {
                Destroy(health[i]);
                health[i] = Instantiate(healthPrefab, originalHealthPositions[i], Quaternion.identity);
                health[i].transform.SetParent(canvas, true); 
                gameOver = false;
            }
        }
    }

}
