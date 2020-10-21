using UnityEngine;
using System.Collections;


public class Waypoint : MonoBehaviour /*контрольные точки для патрулирования с цветовыделением*/
{
    [SerializeField]
    protected float debugDrawRadius = 1.0f;

    public virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, debugDrawRadius);
    }
}
