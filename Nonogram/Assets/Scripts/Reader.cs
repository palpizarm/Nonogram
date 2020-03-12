using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class Reader: MonoBehaviour
{
   private int rows = 0;
   private int columns = 0;
   private int[][] rowsHints = null;
   private int[][] columnsHints = null;

   public Reader(string pFile = "") {
       if (pFile != "") {
            StreamReader fileData = new StreamReader(pFile); 
            ReadData(fileData);
            fileData.Close();
       }
   }

   public void setFile(string pFile) {
        StreamReader fileData = new StreamReader(pFile);
        ReadData(fileData);
        fileData.Close();
   }

    private void ReadData(StreamReader file) {
        string line;
        using (file){
            try {
                line = file.ReadLine();
                String[] entries = line.Split(',');
                rows = int.Parse(entries[0]);
                columns = int.Parse(entries[1]);
                rowsHints = new int[rows][];
                columnsHints = new int[columns][];
                line = file.ReadLine();
                int rowNumber = 0;
                while (line != "COLUMNAS") {
                   line = file.ReadLine();
                   entries = line.Split(',');
                   int[] hints = new int[entries.Length];
                   for(int count = 0; count < entries.Length; count++){
                       hints[count] = int.Parse(entries[count]);
                    }
                rowsHints[rowNumber] = hints;
                rowNumber++;
                }
                rowNumber = 0;
                while((line = file.ReadLine()) == null) {
                    line = file.ReadLine();
                    entries = line.Split(',');
                    int[] hints = new int[entries.Length];
                    for(int count = 0; count < entries.Length; count++){
                        hints[count] = int.Parse(entries[count]);
                    }
                columnsHints[rowNumber] = hints;
                rowNumber++;
                }
            
            } catch(Exception e) {
                Console.WriteLine(e.Message);
            }
        }
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
