using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Text;
using UnityEngine;
using UnityEngine.UIElements;

public class ClueLabels : MonoBehaviour
{
    private Reader reader = Reader.getInstace();

    private int rows,columns;
    private int [][] verticalClue, horizontalClue;

    public GameObject verticalContainer, horizontalContainer;

    void Start() {
        rows = reader.getRows();
        columns = reader.getColums();
        verticalClue = reader.getColumnsHints();
        horizontalClue = reader.getRowsHints();
        for (int row = 0; row < rows; row++) {
            GameObject g = new GameObject();
            g.transform.parent = horizontalContainer.transform;
            g.name = "row: "+row;
            g.AddComponent<TextMesh>().text = horizontalClue[row].ToString();
        }
        for (int column = 0; column < columns; column++){
            GameObject g = new GameObject();
            g.transform.parent = verticalContainer.transform;
            g.name = "row: "+column;
            g.AddComponent<TextMesh>().text = verticalClue[column].ToString();
        }
    }
}
