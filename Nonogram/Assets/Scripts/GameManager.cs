using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameManager : MonoBehaviour
{

    public GameObject loadWarning;
    private string pathFile;
    private Reader reader = Reader.getInstace();
    
    public void PlayGame() {
        if (pathFile != "") {
            SceneManager.LoadScene(1);
        } else {
            ShowLoadWarning();
        }
    }

    public void QuitGame() {
        Debug.Log("Quit");
        Application.Quit();
    }

    private void ShowLoadWarning(){ 
        loadWarning.SetActive(true);
    }

    public void QuitLoadWarning() {
        loadWarning.SetActive(false);
    }

    public void LoadGame() {
        pathFile = EditorUtility.OpenFilePanel("Game File","Assets/Resources/pruebas","txt");
        if (!reader.ReadFile(pathFile)) {
            // make a alert dialog
        }
    }
    
    public void Back() {
        SceneManager.LoadScene(0);
    }
}
