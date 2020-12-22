using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LevelManager
{
    static int currentLevel;
    static int totalLevels = SceneManager.sceneCountInBuildSettings;

    public static int CurrentLevel
    {
        get
        {
            return currentLevel;
        }
        set
        {
            currentLevel = value;
        }
    }

    private static int UpdateCurrentLevel()
    {
       return SceneManager.GetActiveScene().buildIndex;
    }
    public static IEnumerator NextLevel()
    {
        CurrentLevel = UpdateCurrentLevel();
        yield return new WaitForSecondsRealtime(2.5f);
        SceneManager.LoadScene((CurrentLevel+1)%totalLevels);
    }

    public static IEnumerator PreviousLevel()
    {
        CurrentLevel = UpdateCurrentLevel();
        yield return new WaitForSecondsRealtime(1.5f);
        SceneManager.LoadScene(CurrentLevel-1);
    }

    public static void QuitApplication()
    {
        Application.Quit();
    }
}
