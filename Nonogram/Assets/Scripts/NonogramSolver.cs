using UnityEngine;

public class NonogramSolver : MonoBehaviour {

    private Reader reader; // get data
    private bool[][] nonogram; // matrix with a solution
    private int[][] rowsHints; 
    private int[][] columnsHints;
    private int rows; // count of row
    private int columns; // count of column

    public NonogramSolver() {
        reader = Reader.getInstace();
        rowsHints = reader.getRowsHints();
        columnsHints = reader.getColumnsHints();
        rows = reader.getRows();
        columns = reader.getColums();
        createdMatrix();
    }


    // create a matrix with false value (empty)
    private void createdMatrix() {
        nonogram = new bool[rows][];
        for (int row = 0; row < rows; row++) {
            nonogram[row] = new bool[columns];
            for (int column = 0; column < columns; column++) {
                nonogram[row][column] = false;
            }
        }
    }

    public void startSolver() {

    }


    // return false if there isn't any solution
    // return true if there is a solution
    public bool solver(int rowIndex = 0, int columnIndex = 0) {
        if (rowIndex == rows && columnIndex == columns) return true;
        // put a mark in a cell and check if is correct
        nonogram[rowIndex][columnIndex] = true;
        if (verify(rowIndex,columnIndex) &&
        solver(rowIndex = (columnIndex == columns - 1) ?  0 : rowIndex + 1, (columnIndex+1)%columns)) {
            return true;
        };
        // clean the cell and check
        nonogram[columnIndex][rowIndex] = false;
        if (verify(rowIndex,columnIndex) &&
        solver(rowIndex = (columnIndex == columns - 1) ?  rowIndex + 1 : 0, (columnIndex+1)%columns)) {
            return true;
        };
        // is no find a solution return false
        return false;
    }

    private bool verify(int row, int column) {
        return (
            // check vertical line
          verifyRowColumn(rowsHints[row], nonogram[row], row) &&
          // check horizontal line
          verifyRowColumn(columnsHints[column], getColum(column), column)
        );
    }


    // check if the filling of the row is valid 
    private bool verifyRowColumn(int[] hints, bool [] row, int length) {
        int hintCount = 0;
        int marks = 0;
        bool lastMark = false;
        // Check cell to cell if the entry  is correct
        for (int index = 0; index <= length; index++) {
            if (row[index]) {
                marks++;
                if (!lastMark) {
                    if (hints.Length <= hintCount) {
                        return false;
                    }
                    lastMark = true;
                }
            } else {
                if (lastMark) {
                    if(hints[hintCount] != marks) {
                        return false;
                    }
                    marks = 0;
                    hintCount++;
                    lastMark = false;
                }
            }
        }
        // verify if the row is done
        if (length == columns - 1) {
            return hintCount == hints.Length - 1 &&
            marks == hints[hintCount];
        }
        return true;
    }

    // get the value of a k column and return a array with this values
    bool[] getColum(int column) {
        bool []array = new bool[columns];
        for(int index = 0; index < rows; index++) {
            array[index] = nonogram[index][column];
        }
        return array;
    }

}
