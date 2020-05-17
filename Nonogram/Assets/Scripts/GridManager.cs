using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    private Reader reader = Reader.getInstace();

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

    private void GenerateGrid() {
        rows = reader.getRows();
        columns = reader.getColums();
        tileSize = container.GetComponent<RectTransform>().sizeDelta[0] / rows;
        padding = 10;
        template.GetComponent<RectTransform>().sizeDelta = new Vector2((tileSize - padding), (tileSize - padding));
        template.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0, -tileSize, 0);
        grid = new GameObject[rows,columns];
        for (int row = 0; row < rows; row++) {
            for (int column = 0; column < columns; column++) {
                GameObject g = new GameObject("row: " + row + "column: " + column);
                g.transform.SetParent(container.GetComponent<RectTransform>());
                RectTransform transform = g.AddComponent<RectTransform>();
                Vector3 position = template.GetComponent<RectTransform>().anchoredPosition3D;
                position[0] += column * tileSize;
                position[1] -=  row * tileSize;
                transform.localScale = new Vector3(1, 1, 1);
                transform.anchoredPosition3D = position;
                transform.sizeDelta = new Vector2(tileSize - padding, tileSize - padding);
                transform.anchorMin = new Vector2(0, 1);
                transform.anchorMax = new Vector2(0, 1);
                transform.pivot = new Vector2(0, 0);
                SpriteRenderer sprite = g.AddComponent<SpriteRenderer>();
                sprite.sprite = empty;
                sprite.size = new Vector2(tileSize - padding, tileSize - padding);
                grid[row,column] = g;
            }
        }
    }


    private void updateGrid(bool[][] game) {
        for (int row = 0; row < rows; row++) {
            for (int column = 0; column < columns; column++){
                if (game[row][column]) {
                    grid[row,column].AddComponent<SpriteRenderer>().sprite = fill;
                }else {
                    grid[row,column].AddComponent<SpriteRenderer>().sprite = empty;
                }
            }
        }
    }

    // Update is called once per frame
    void Update() {

    }
}
