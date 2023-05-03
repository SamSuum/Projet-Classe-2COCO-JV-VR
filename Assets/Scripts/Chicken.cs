using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chicken : MonoBehaviour
{
    
    public float moveSpeed = 3f;
    public float rotSpeed = 100f;
    float initHP;

    private bool isWandering = false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private bool isWalking = false;
   
    public Damage dmg;
    Transform startTransform;
    NavMeshAgent agent;
    public GameObject target;

    
    

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        initHP = dmg.HP;
    }
    private void Update()
    {
        if (isWandering == false)
        {
            StartCoroutine(Wander());
        }
        if (isRotatingRight == true)
        {
            
            transform.Rotate(transform.up * Time.deltaTime * rotSpeed);
        }
        if (isRotatingLeft == true)
        {
            
            transform.Rotate(transform.up * Time.deltaTime * -rotSpeed);
        }
        if (isWalking == true)
        {
           
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }

        if (dmg.HP < initHP / 2)
        {
            Flee();
        }
        
    }
    
    IEnumerator Wander()
    {      
        
    
        int rotTime = Random.Range(1, 3);
        int rotateWait = Random.Range(1, 4);
        int rotateLorR = Random.Range(1, 2);
        int walkWait = Random.Range(1, 5);
        int walkTime = Random.Range(1, 6);

        isWandering = true;

        yield return new WaitForSeconds(walkWait);
        isWalking = true;
        yield return new WaitForSeconds(walkTime);
        isWalking = false;
        yield return new WaitForSeconds(rotateWait);
        if (rotateLorR == 1)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingRight = false;
        }
        if (rotateLorR == 2)
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingLeft = false;
        }
        isWandering = false;
    
    }

    void Flee()
    {
        startTransform = transform;
        NavMeshHit hit;
        transform.rotation = Quaternion.LookRotation(transform.position - target.transform.position);
        NavMesh.SamplePosition(transform.position + transform.forward * 2, out hit, 5, 1 << NavMesh.GetAreaFromName("Walkable"));
        transform.position = startTransform.position;
        transform.rotation = startTransform.rotation;
        agent.SetDestination(hit.position);
    }

}
