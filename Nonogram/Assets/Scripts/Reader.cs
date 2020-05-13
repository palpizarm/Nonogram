using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;


/*
Singleton Class
*/
public class Reader {
    private static Reader reader = null;
    private int rows;
    private int columns;
    private int[][] rowsHints;
    private int[][] columnsHints;

    private Reader() {
        rows = 0;
        columns = 0;
    }

    public static Reader getInstace() {
        if (reader == null) {
            reader = new Reader();
        }
        return reader;
    }

    public bool ReadFile(string pFile = "") {
        bool readed = false;
        if (pFile != "") {
            StreamReader fileData = new StreamReader(pFile); 
            readed = ReadData(fileData);
            fileData.Close();
        }
        return readed;
    }

    private bool ReadData(StreamReader file) {
        string line;
        using (file){
            try {
                line = file.ReadLine();
                String[] entries = line.Split(',');
                rows = int.Parse(entries[0]);
                columns = int.Parse(entries[1]);
                rowsHints = new int[rows][];
                columnsHints = new int[columns][];
                print("FILAS");
                line = file.ReadLine();
                int rowNumber = 0;
                for (rowNumber = 0; rowNumber < rows; rowNumber++) {
                    line = file.ReadLine();
                    entries = line.Split(',');
                    int[] hints = new int[entries.Length];
                    for(int count = 0; count < entries.Length; count++){
                        hints[count] = int.Parse(entries[count]);
                        print(hints[count]);
                    }
                    rowsHints[rowNumber] = hints;
                }
                print("COLUMNAS");
                line = file.ReadLine();
                for (rowNumber = 0; rowNumber < rows; rowNumber++) {
                    line = file.ReadLine();
                    entries = line.Split(',');
                    int[] hints = new int[entries.Length];
                    for(int count = 0; count < entries.Length; count++){
                        hints[count] = int.Parse(entries[count]);
                        print(hints[count]);
                    }
                    columnsHints[rowNumber] = hints;
                }
            
            } catch(Exception e) {
                Debug.Log(e.Message);
                return false;
            }
        }
        return true;
   }

    public int getRows() {
        return rows;
    }

    public int getColums() {
        return columns;
    }

    public int[][] getRowsHints() {
        return rowsHints;
    }

    public int[][] getColumnsHints() {
        return columnsHints;
    }
}
