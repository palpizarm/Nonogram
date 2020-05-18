using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class GridManager : MonoBehaviour
{

    private Reader reader = Reader.getInstace();
    private NonogramSolver solver = NonogramSolver.getInstance();
    private GameObject[,] grid;
    private int rows;
    private int columns;
    private float tileSize;
    private float padding;
    public Sprite empty;
    public Sprite fill;
    public GameObject container;
    public GameObject template;


    // Start is called before the first frame update
    void Start() {
        GenerateGrid();
    }

    public void GenerateGrid() {
        rows = reader.getRows();
        columns = reader.getColums();
        tileSize = container.GetComponent<RectTransform>().sizeDelta[0] / rows;
        padding = 10;
        template.GetComponent<RectTransform>().sizeDelta = new Vector2((tileSize - padding), (tileSize - padding));
        template.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0, -tileSize, 0);
        grid = new GameObject[rows, columns];
        for (int row = 0; row < rows; row++) {
            for (int column = 0; column < columns; column++) {
                GameObject g = new GameObject("row: " + row + "column: " + column);
                g.transform.SetParent(container.GetComponent<RectTransform>());
                RectTransform transform = g.AddComponent<RectTransform>();
                Vector3 position = template.GetComponent<RectTransform>().anchoredPosition3D;
                position[0] += column * tileSize;
                position[1] -= row * tileSize;
                transform.localScale = new Vector3(1, 1, 1);
                transform.anchoredPosition3D = position;
                transform.sizeDelta = new Vector2(tileSize - padding, tileSize - padding);
                transform.anchorMin = new Vector2(0, 1);
                transform.anchorMax = new Vector2(0, 1);
                transform.pivot = new Vector2(0, 0);
                Image image = g.AddComponent<Image>();
                image.sprite = empty;
                grid[row, column] = g;
            }
        }
    }

    void Update() {
        bool[][] game = solver.getNonogram();
        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                if (game[row][column])
                {
                    grid[row, column].GetComponent<Image>().sprite = fill;
                }
                else
                {
                    grid[row, column].GetComponent<Image>().sprite = empty;
                }
            }
        }
    }
}
