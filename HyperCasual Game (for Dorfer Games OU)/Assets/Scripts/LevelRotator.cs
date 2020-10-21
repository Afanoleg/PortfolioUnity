using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

//Класс, отвечающий за поворот и вращение уровня вокруг пивота

public class LevelRotator : Singleton<LevelRotator>, IDragHandler
{
    [SerializeField] private GameObject level;
    [SerializeField] private GameObject pivot;
    [SerializeField] private Vector2 rotationSensitivity;
    [SerializeField] private Vector2 xRotationLimits;
    [SerializeField] private Vector2 zRotationLimits;

    public bool IsRotationEnabled { get; set; } = true;

    public void OnDrag(PointerEventData eventData)
    {
        if (!IsRotationEnabled) return;
        RotateLevel(eventData.delta);
    }

    //Вращение вокруг пивота
        private void RotateLevel(Vector2 delta)
    {
        level.transform.RotateAround(pivot.transform.position, Vector3.back,
            delta.x * rotationSensitivity.x / Screen.width * 320);
        level.transform.RotateAround(pivot.transform.position, Vector3.right,
            delta.y * rotationSensitivity.y / Screen.height * 526);
        ClampRotation(delta);
    }

    //Пределы вращения по осям X и Y
    private void ClampRotation(Vector2 delta)
    {
        ClampRotationOnAxis(delta.x, Vector3.back, zRotationLimits, rotationSensitivity.x);
        ClampRotationOnAxis(delta.y, Vector3.right, xRotationLimits, rotationSensitivity.y);
    }

    //Уменьшение сенсетивити при увелечении угла вращения по пивоту
    private void ClampRotationOnAxis(float angleDelta, Vector3 axis, Vector2 limits, float sensitivity)
    {
        Vector3 levelUpProjection = level.transform.up;
        levelUpProjection.x *= 1 - Mathf.Abs(axis.x);
        levelUpProjection.y *= 1 - Mathf.Abs(axis.y);
        levelUpProjection.z *= 1 - Mathf.Abs(axis.z);
        float angle = Vector3.Angle(levelUpProjection, Vector3.up);
        if (angle <= limits.x || angle >= limits.y)
        {
            level.transform.RotateAround(pivot.transform.position, axis, -angleDelta * sensitivity);
        }
    }
    
    //Перезапуск уровня
    public void SetNewLevel(GameObject newLevel)
    {
        level = newLevel;
    }
}