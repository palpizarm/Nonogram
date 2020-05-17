using UnityEngine;

public class NonogramSolver {

    private static NonogramSolver nonogramSolver;

    private Reader reader = Reader.getInstace(); // get data
    private bool[][] nonogram; // matrix with a solution
    private int[][] rowsHints; 
    private int[][] columnsHints;
    private int rows; // count of row
    private int columns; // count of column
    private string time;
    private bool isSolution = false;

    private NonogramSolver() {
        rowsHints = reader.getRowsHints();
        columnsHints = reader.getColumnsHints();
        rows = reader.getRows();
        columns = reader.getColums();
        createdMatrix();
    }

    public static NonogramSolver getInstance()
    {
        if (nonogramSolver == null || nonogramSolver.getNonogram().Length == 0)
        {
            nonogramSolver = new NonogramSolver();
        }
        return nonogramSolver;
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

    public bool startSolver() {
        var watch = new System.Diagnostics.Stopwatch();
        watch.Start();
        isSolution = solver(0, 0);
        watch.Stop();
        TimeFormat(watch.ElapsedMilliseconds);
        Debug.Log(isSolution);
        Debug.Log(watch.ElapsedMilliseconds);
        printSolution();

        return isSolution;
    }


    public bool getIsSolution()
    {
        return isSolution;
    }


    // return false if there isn't any solution
    // return true if there is a solution
    public bool solver(int rowIndex = 0, int columnIndex = 0) {
        if (rowIndex == rows) return true;
        // put a mark in a cell and check if is correct
        nonogram[rowIndex][columnIndex] = true;
        if (verify(rowIndex,columnIndex) &&
        solver(rowIndex = (columnIndex == columns - 1) ? rowIndex + 1 : rowIndex, (columnIndex+1)%columns)) {
            return true;
        };
        // clean the cell and check
        nonogram[rowIndex][columnIndex] = false;
        if (verify(rowIndex,columnIndex) &&
        solver(rowIndex = (columnIndex == columns - 1) ?  rowIndex + 1 : rowIndex, (columnIndex+1)%columns)) {
            return true;
        };
        // is no find a solution return false
        return false;
    }

    private bool verify(int row, int column) {
        return (
            // check vertical line
          verifyRowColumn(rowsHints[row], nonogram[row], column) &&
          // check horizontal line
          verifyRowColumn(columnsHints[column], getColum(column), row)
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
        if (length == columns - 1)
        {
            if (lastMark)
            {
                return hintCount == hints.Length - 1 &&
                marks == hints[hintCount];
            }
            else
            {
                return hintCount == hints.Length;
            }
        }
        else if (lastMark)
        {
            return marks <= hints[hintCount];
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

    public string getTime()
    {
        return time;
    }

    private void TimeFormat(long miliseconds)
    {
        int seconds = (int)miliseconds / 1000;
        miliseconds %= 1000;
        int minutes  = seconds / 60;
        seconds %= 60;
        time = "00:" + minutes + ":" + seconds + ":" + miliseconds; 
    }

    public bool[][] getNonogram()
    {
        return nonogram;
    }

    public void printSolution()
    {
        string solution = "";
        for (int row = 0; row < rows; row++) {
            for (int column = 0; column < columns; column++) {
                if (nonogram[row][column])
                {
                    solution += "1 ";
                } else
                {
                    solution += "0 ";
                }
            }
            solution += "\n";
        }
        Debug.Log(solution);
    }

    public void clean()
    {
        nonogram = new bool[0][];
        rowsHints = new int[0][];
        columnsHints = new int[0][];
        rows = 0;
        columns = 0;
        time = "";
        isSolution = false;
    }

}
