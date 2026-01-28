using UnityEngine;
using UnityEngine.AI;

public class ScoutMovement : MonoBehaviour
{
    public NavMeshAgent navAgent;
    public Vector3 targetPosition;

    void Start()
    {
        //navAgent.SetDestination(targetPosition);

        navAgent.SetDestination (transform.position + new Vector3 (Random.Range(-3f, 3f), 0, Random.Range(-3f, 3f)));  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
