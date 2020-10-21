using UnityEngine;
using UnityEngine.EventSystems;

//—крипт по управлению м€чом
public class BallController : MonoBehaviour, IDragHandler
{
    [SerializeField] public Rigidbody ball;
    [SerializeField] public float forceFactor;

    public void OnDrag(PointerEventData eventData)
    {
        ball.AddForce(
            new Vector3(eventData.delta.x / Screen.width * 400, 0, eventData.delta.y / Screen.height * 600) *
            forceFactor, ForceMode.Impulse);
    }
}