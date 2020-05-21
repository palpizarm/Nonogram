using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private string pathFile;
    private Reader reader = Reader.getInstace();
    private NonogramSolver solver = NonogramSolver.getInstance();
    private bool fileLoad = false;
    public GameObject loadWarning;
    public GameObject timeText;
    public GameObject BackButton;
    public GameObject StartButton;
    public GameObject noSolution;
    public GameObject Animate;

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

    public void QuitMessage()
    {
        noSolution.SetActive(false);
    }

    public void LoadGame() {
        pathFile = EditorUtility.OpenFilePanel("Game File","Assets/Resources/pruebas","txt");
        if (!(fileLoad = reader.ReadFile(pathFile))) {
            ShowLoadWarning();
        }
    }
    
    public void Back() {
        reader.clean();
        solver.clean();
        SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        if (reader.fileReaded())
        {
            StartButton.GetComponent<Button>().interactable = false;
            BackButton.GetComponent<Button>().interactable = false;
            Animate.GetComponent<Toggle>().interactable = false;

            if (!solver.startSolver(Animate.GetComponent<Toggle>().isOn))
            {
                noSolution.SetActive(true);
            }

            timeText.GetComponent<Text>().text = solver.getTime();
            Animate.GetComponent<Toggle>().interactable = true;
            StartButton.GetComponent<Button>().interactable = true;
            BackButton.GetComponent<Button>().interactable = true;
        }
    }
}