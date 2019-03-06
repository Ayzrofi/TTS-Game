using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public void NextLvl()
    {
        LevelSelector.instance.LoadNewLevel();
    }

    public void Play()
    {
        if(LevelSelector.instance.LevelName.Count <= 0)
        {
            LevelSelector.instance.ReloadLevel();
        }
        LevelSelector.instance.LoadNewLevel();
    }
    public void RestartLvl()
    {
        SceneManager.LoadScene(Application.loadedLevel);
    }


    public void ToMenu()
    {
        Debug.Log("to Menu");
        SceneManager.LoadScene("Main Menu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ToAnimalCollections()
    {
        SceneManager.LoadScene("Animal Collections");
    }

    public void RisetData()
    {
        PlayerPrefs.DeleteAll();
    }
}
