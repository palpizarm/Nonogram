using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    private Reader reader = Reader.getInstace();
    [SerializeField]private int rows;
    [SerializeField]private int columns;
    [SerializeField]private float tileSize = 1;
    // Start is called before the first frame update
    void Start() {
        GenerateGrid();
    }

    private void GenerateGrid() {
        /*rows = reader.getRows();
        columns = reader.getColums();*/
        rows = 5;
        columns = 5;
        float gridWidth = columns*tileSize;
        float gridHeight = rows*tileSize;

        GameObject referenceTile = (GameObject)Instantiate(Resources.Load("GrassTile"));
        for (int row = 0; row < rows; row++) {
            for (int column = 0; column < columns; column++){
                GameObject tile = (GameObject)Instantiate(referenceTile,transform);
                float posX = column * tileSize;
                float posY = row * -tileSize;
                tile.transform.position = new Vector2(posX,posY);
            }
        }
        Destroy(referenceTile);
        transform.position = new Vector2(-gridWidth/2+tileSize/2, gridHeight/2+tileSize/2);
    }


    private void updateGrid(int[,] grid) {

    }
    // Update is called once per frame
    void Update() {

    }
}
