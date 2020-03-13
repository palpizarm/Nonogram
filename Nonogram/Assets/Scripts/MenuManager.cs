using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MenuManager : MonoBehaviour
{
    private string pathFile;

    public void PlayGame() {
        SceneManager.LoadScene(1);
    }

    public void QuitGame() {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void LoadGame() {
        pathFile = EditorUtility.OpenFilePanel("Game File", "","");
        Debug.Log(pathFile);
    }

}
