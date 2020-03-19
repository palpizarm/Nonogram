using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UIElements;

public class MenuManager : MonoBehaviour
{
    private string pathFile;
    private Reader reader = Reader.getInstace();
    
    public void PlayGame() {
        SceneManager.LoadScene(1);
    }

    public void QuitGame() {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void LoadGame() {
        pathFile = EditorUtility.OpenFilePanel("Game File", "","");
        if (reader.ReadFile(pathFile)) {
            
        }
    }

}
