using UnityEngine;

//Скрипт, отвечающий за окончание уровня
public class EndLevelTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        EndLevel();    
    }
    
    //Последующий уровень появляется на 50 единиц ниже предыдущего Объекта
    private void EndLevel()
    {
        Vector3 nextLevelPosition = transform.position + Vector3.down * 50;
        LevelController.GetInstance().BeginLevelTransition(nextLevelPosition);
    }
}