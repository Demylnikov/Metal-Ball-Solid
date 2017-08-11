using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

	public void StartButton(string newGameLevel)
    {
        SceneManager.LoadScene(newGameLevel);
    }

    public void InstructionsButton(string newGameLevel1)
    {
        SceneManager.LoadScene(newGameLevel1);
    }

    public void ExitGameButton()
    {
        Debug.Log("pressed exit game button");
        Application.Quit();
    }

    public void BackButton(string newGameLevel2)
    {
        SceneManager.LoadScene(newGameLevel2);
    } 

}
