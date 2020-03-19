using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonogramSolver : MonoBehaviour {

    private Reader reader;
    private int[][] nonogram;
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
        nonogram = new int[rows][];
        for (int row = 0; row < rows; row++) {
            nonogram[row] = new int[columns];
            for (int column = 0; column < columns; column++) {
                nonogram[row][column] = 0;
            }
        }
    }

    public void startSolver() {
        int hintIndex = 0;
        for (int row = 0; row < rows; row++) {
            int[] hints = rowsHints[row];
            for (int column = 0; column < columns; column++) {
                nonogram[row][column] = 1;
            }
        }
    }

    private bool verify(int hintsIndex, int column, int length) {
        return verifyColumn(columnsHints[hintsIndex], nonogram[column], length);
    }

    private bool verifyColumn(int[] hints, int [] row, int length) {
        bool valid = true;
        int index = 0;
        int rowFilled = 0;
        for (int count = 0; count <= length; count++){
            if (row[count] == 1) {
                rowFilled++;
                if (rowFilled > hints[index]) {
                    valid = false;
                    break; // break the loop to return valid value(false)
                }
            }
            else if(rowFilled > 0 && row[count] == 0) {
                rowFilled = 0; // set cero to start again
                index++;
            }
        }
        // validate the row/column is done
        return valid;   
        }

}
