using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endGameScript : MonoBehaviour
{
    public void restartGame() {
        SceneManager.LoadScene(1);
        #if !UNITY_WEBGL
        Application.targetFrameRate = Screen.currentResolution.refreshRate;
        #endif
        Time.timeScale = 1;
    }

    public void quitGame() {
        Time.timeScale = 1;
        Application.Quit();
    }
}
