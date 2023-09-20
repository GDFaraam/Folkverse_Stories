using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LineRender : MonoBehaviour
{
    public Transform player;
    public LineRenderer lineRenderer;
    private Transform currentTarget;

    public float maxDistance;
    public float nearDistance;
    public float minDistance;

    public bool isAttached = false;
    private bool CPolePassed = false;
    public bool checkPointReached = false;

    public EnemyScript enemyScript;
    public Health Health;
    private GameManager gm;

    public int checkPointIndex;
    private int predictedCPIndex;
    private int quizIndex;


    private void Start()
    {
        lineRenderer.enabled = false;
        checkPointIndex = 0;
        predictedCPIndex = 1;
        quizIndex = 0;
        gm = GameManager.instance;
    }

    private void Update()
    {
        if (isAttached)
        {
            if (currentTarget != null)
            {
                lineRenderer.SetPosition(0, player.position);

                if (CPolePassed){
                    lineRenderer.SetPosition(lineRenderer.positionCount - 2, currentTarget.position);
                    CPolePassed = false;
                }
                else{
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, currentTarget.position);
                }

                float distance = Vector3.Distance(player.position, currentTarget.position);

                if (distance > maxDistance)
                {
                    DetachFromTarget();
                }
                //else if (distance <= nearDistance)
                //{
                    //lineRenderer.material.color = Color.green;
                //}
                //else if (distance <= minDistance)
                //{
                    //lineRenderer.material.color = Color.yellow;
                //}
                //else
                //{
                    //lineRenderer.material.color = Color.red;
                //}
            //}
            //else
            //{
                
                //DetachFromTarget();
            }
        }

        if (gm.DetachPressed){
            DetachFromTarget();
            gm.DetachPressed = false;
        }

        if (quizIndex == 3) {
            quizIndex++;
            GameObject newQuiz = Instantiate(gm.quizList[0], gm.spawnArea[1].transform.position, Quaternion.identity);
        }

    }

    public void AttachToTarget(Transform newTarget)
    {
        currentTarget = newTarget;
        isAttached = true;
        lineRenderer.enabled = true;
    }

    public void DetachFromTarget()
    {
        currentTarget = null;
        isAttached = false;
        lineRenderer.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D coll){
    if (coll.gameObject.tag == "Pole")
    {
        maxDistance = 13.5f;
        minDistance = 11;
        AttachToTarget(coll.transform); 
        DetachFromNewObject(coll.transform);
    }

    else if (coll.gameObject.tag == "Longer Pole")
    {
        maxDistance = 20;
        minDistance = 18;
        AttachToTarget(coll.transform);
        DetachFromNewObject(coll.transform);
    }

    else if (coll.gameObject.tag == "Checkpoint")
    {
        coll.gameObject.tag = "Pole";
        checkPointIndex++;
        quizIndex++;
        maxDistance = 13.5f;
        minDistance = 11;
        AttachToTarget(coll.transform);
        DetachFromNewObject(coll.transform);

        if (enemyScript.index == checkPointIndex - 1){
        enemyScript.index = checkPointIndex;
        }

        if (checkPointIndex == predictedCPIndex){
            checkPointReached = false;
            predictedCPIndex++;
        }

        if (!checkPointReached){
        Health.currentHealthIndex = 0;
        Health.ResetHealth();
        checkPointReached = true;
        }
    }

    else if (coll.gameObject.tag == "C Pole")
    {
        CPolePassed = true;
        maxDistance = 13.5f;
        minDistance = 11;
        AttachToTarget(coll.transform);
        ConnectToNewObject(coll.transform);
        coll.gameObject.tag = "Pole";
    }

    else if (coll.gameObject.tag == "Fake")
    {
        DetachFromTarget();
        Destroy(gm.quizList[0].gameObject);
        quizIndex = 2;
    }   

    }

    void ConnectToNewObject(Transform newObject)
    {
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, newObject.position);
    }


    void DetachFromNewObject(Transform newObject)
    {
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(1, newObject.position);
    }



}
