using UnityEngine;
using UnityEngine.AI;

public class RandomRoam : MonoBehaviour
{
    private NavMeshAgent _navmeshAgent;

    private void Awake()
    {
        _navmeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (_navmeshAgent.enabled == false)
            return;
        
        if (_navmeshAgent.hasPath == false || _navmeshAgent.remainingDistance < 1f)
            ChooseNewPosition();
    }

    private void ChooseNewPosition()
    {
        Vector3 randomOffset = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
        var destination = transform.position + randomOffset;
        _navmeshAgent.SetDestination(destination);
    }
}