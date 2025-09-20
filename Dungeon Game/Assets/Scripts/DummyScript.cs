using UnityEngine;
using UnityEngine.AI;

public class DummyScript : MonoBehaviour, IEnemy
{
    public NavMeshAgent agent;
    public Transform target;

    private void Start()
    {
        agent.updateUpAxis = false;
        agent.updateRotation = false;
    }

    private void Update()
    {
        agent.SetDestination(target.position);
    }
}
