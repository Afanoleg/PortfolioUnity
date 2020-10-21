using UnityEngine;
using UnityEngine.AI;

public class PoliceMove : MonoBehaviour /*Самостоятельная попытка придумать что-о пхожее на патрулирование*/
{
    [SerializeField]
    Transform _destination;

    NavMeshAgent _navMeshAgent;

    private void Start()
    {
        _navMeshAgent = this.GetComponent<NavMeshAgent>();

        if(_navMeshAgent == null)
        {
            Debug.Log("The nav is not attached" + gameObject.name);
        }
        else
        {
            SetDestination();
        }
    }

    private void SetDestination()
    {
        if(_destination != null)
        {
            Vector3 targetVector = _destination.transform.position;
            _navMeshAgent.SetDestination(targetVector);
        }
    }
}
