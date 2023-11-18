using System;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Element",menuName = "Elements")]
public class Database : ScriptableObject
{
    
    public TextAsset csvFile;
    public List<Element> elements=new List<Element>();
    public string[,] reactions;

    public string[,] ParseDataString(string data)
    {
        // Разделение строки данных на строки
        string[] rows = data.Split('\n', StringSplitOptions.RemoveEmptyEntries);

        // Определение размера массива на основе числа строк и столбцов
        int numRows = rows.Length;
        int numColumns = rows[0].Split(',').Length;

        // Создание двумерного массива
        string[,] dataArray = new string[numRows, numColumns];

        for (int i = 0; i < numRows; i++)
        {
            // Разделение каждой строки на столбцы
            string[] columns = rows[i].Split(',');

            for (int j = 0; j < numColumns; j++)
            {
                dataArray[i, j] = columns[j].Trim('"'); // Убираем кавычки вокруг данных
            }
        }

        return dataArray;
    }
}

[Serializable]
public class Element
{
    public string name;
    public int ID;
    public Color color;
}
