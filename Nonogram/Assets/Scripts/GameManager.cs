using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameManager : MonoBehaviour
{

    public GameObject loadWarning;
    private string pathFile;
    private Reader reader = Reader.getInstace();
    private NonogramSolver solver = new NonogramSolver();
    private bool fileLoad = false;
    
    public void PlayGame() {
        if (fileLoad) {
            SceneManager.LoadScene(1);
        } else {
            ShowLoadWarning();
        }
    }

    public void QuitGame() {
        print("¡QUIT!");
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
        if (!(fileLoad = reader.ReadFile(pathFile))) {
            ShowLoadWarning();
        }
    }
    
    public void Back() {
        SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        if (solver.startSolver())
        {

        } else
        {

        }
    }
}
