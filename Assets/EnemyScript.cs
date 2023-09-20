using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public LineRender lineRender;
    public Transform target;        
    public Transform[] resetPosition;
    public float baseMoveSpeed = 5.0f;   
    public Health health;
    public int index;

    void Start(){
        index = 0;
    }

    private void Update()
    {
        if (lineRender.isAttached == false)
        {
            Vector3 directionToTarget = (target.position - transform.position).normalized;
            float distanceToTarget = Vector3.Distance(transform.position, target.position);
            float moveSpeed = Mathf.Lerp(baseMoveSpeed, baseMoveSpeed * 2, Mathf.Clamp01(distanceToTarget / 10.0f));
            transform.position += directionToTarget * moveSpeed * Time.deltaTime;
        }
    }
    
    void OnTriggerEnter2D (Collider2D coll){
        if (coll.gameObject.tag == "Player"){
            if (!health.gameOver){
            coll.gameObject.transform.position = resetPosition[index].position;
            }
        }
    }


}
