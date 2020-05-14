using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    private Reader reader = Reader.getInstace();

    private GameObject[,] grid;
    private int rows;
    private int columns;
    private float tileWidth;
    private float tileHeight;
    public float padding;
    public Sprite empty;
    public Sprite fill;
    public GameObject container;
    // Start is called before the first frame update
    void Start() {
        GenerateGrid();
    }

    private void GenerateGrid() {
        rows = reader.getRows();
        columns = reader.getColums();
        tileWidth = container.GetComponent<RectTransform>().rect.width/columns;
        tileHeight = container.GetComponent<RectTransform>().rect.height/rows;
        grid = new GameObject[rows,columns];
        for (int row = 0; row < rows; row++) {
            for (int column = 0; column < columns; column++){
                GameObject g = new GameObject("row: "+ row+"column: "+column);
                g.transform.parent = container.transform;
                g.AddComponent<RectTransform>().position = new Vector3(row,
                column, 0);
                g.GetComponent<RectTransform>().pivot = new Vector2(0,0);
                g.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                g.AddComponent<SpriteRenderer>().sprite = empty;
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
