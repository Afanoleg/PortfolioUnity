using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuController : MonoBehaviour /*Череда вызовов разных сцен и главного меню через OnClick*/
{
    public void PlayPressed()
    {
        SceneManager.LoadScene("Level1");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Menu Scene");
    }

    public void PlayLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void PlayLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void PlayLevel3()
    {
        SceneManager.LoadScene("Level3");
    }

    
    public void ExitPressed()
    {
        Application.Quit();
        Debug.Log("Exit pressed!");
    }
}
