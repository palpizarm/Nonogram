using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonogramSolver : MonoBehaviour {

    private Reader reader;
    private bool[][] nonogram;
    private int[][] rowsHints;
    private int[][] columnsHints;
    private int rows;
    private int columns;

    public NonogramSolver() {
        reader = Reader.getInstace();
        rowsHints = reader.getRowsHints();
        columnsHints = reader.getColumnsHints();
        rows = reader.getRows();
        columns = reader.getColums();
        createdMatrix();
    }

    private void createdMatrix() {
        nonogram = new bool[rows][];
        for (int row = 0; row < rows; row++) {
            nonogram[row] = new bool[columns];
            for (int column = 0; column < columns; column++) {
                nonogram[row][column] = false;
            }
        }
    }

    public void startSolver() {}

    public void findSolution() {}

    private bool verify(int hintsIndex, int row, int length) {
        return true;
    }


    // check if the filling of the row is valid 
    private bool verifyRow(int[] hints, bool [] row, int length) {
        int hintCount = 0;
        int marks = 0;
        bool lastMark = false;
        // Check cell to cell if the row is correct
        for (int index = 0; index <= length; index++) {
            if (row[index]) {
                marks++;
                if (!lastMark) {
                    if (hints.Length <= hintCount) {
                        return false;
                    }
                }
                lastMark = true;
            } else {
                if (lastMark) {
                    if(hints[hintCount] != marks) {
                        return false;
                    }
                    marks = 0;
                    hintCount++;
                }
                lastMark = false;
            }
        }
        // verify if the row is done
        if (length == columns - 1) {
            return hintCount == hints.Length - 1 &&
            marks == hints[hintCount];
        }
        return true;
    }

}
