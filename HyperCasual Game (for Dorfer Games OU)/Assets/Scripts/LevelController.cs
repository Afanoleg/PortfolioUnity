using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vector3 = UnityEngine.Vector3;

//Класс, управляющий перемещением и перезапуском уровня
public class LevelController : Singleton<LevelController>
{
    [SerializeField] private GameObject ball;
    [SerializeField] private List<Level> levels;
    [SerializeField] private float totalLevelTransitionTime;

    private int currentLevelId;
    private Vector3 ballStartPosition;
    private float currentLevelTransitionTime;
    private bool isTransitioning;
    private Level prevLevel;

    private void Update()
    {
        CheckBallDistance();
    }

    private void FixedUpdate()
    {
        if (isTransitioning)
        {
            currentLevelTransitionTime += Time.fixedDeltaTime;
            UpdateLevelTransition();
            if (currentLevelTransitionTime >= totalLevelTransitionTime)
            {
                FinishLevelTransition();
            }
        }
    }

   //Проверка состояния мяча и перезапуск сцены в случае несовпадения
    private void CheckBallDistance()
    {
        if (isTransitioning) return;
        float distance = Vector3.Distance(ball.transform.position, levels[currentLevelId].transform.position);
        if (distance >= levels[currentLevelId].MaxBallDistance)
        {
            RestartScene();
        }
    }

    //Перезапуск запущенной сцены
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

   //Активация сцены 
    private Level ActivateNextLevel(Vector3 nextLevelPosition)
    {
        prevLevel = levels[currentLevelId];
        currentLevelId = (currentLevelId + 1) % levels.Count;
        levels[currentLevelId].Activate(nextLevelPosition);
        return levels[currentLevelId];
    }

    //Активация следующего уровня. Ротатор позиции и запуск мяча
    public void BeginLevelTransition(Vector3 nextLevelPosition)
    {
        Level nextLevel = ActivateNextLevel(nextLevelPosition);
        LevelRotator.GetInstance().SetNewLevel(nextLevel.gameObject);
        LevelRotator.GetInstance().IsRotationEnabled = false;

        ballStartPosition = ball.transform.position;
        currentLevelTransitionTime = 0;
        isTransitioning = true;
    }

  //Установка позиции мяча
    private void UpdateLevelTransition()
    {
        ball.transform.position = Vector3.Lerp(ballStartPosition,
            levels[currentLevelId].SphereLandingPoint.transform.position,
            currentLevelTransitionTime / totalLevelTransitionTime);
    }

    //Отключение предыдущего уровня
    private void FinishLevelTransition()
    {
        isTransitioning = false;
        prevLevel.Deactivate();
        LevelRotator.GetInstance().IsRotationEnabled = true;
    }
}