using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CVSLogger : MonoBehaviour
{
    public static void WriteCSV()
    {
        DateTime date = DateTime.Now;
        string folderPath = Application.persistentDataPath;

        string formattedDate = date.ToString("yyyy-MM-dd_HH:mm");
        string filePath = Path.Combine(folderPath, "TyingResult_"+formattedDate+".csv");

        using (StreamWriter writer = new StreamWriter(filePath, false))
        {
            writer.WriteLine("Hi");
            writer.WriteLine("How");
            writer.WriteLine("Are");
            writer.WriteLine("You");
        }

        Debug.Log("CSV file written to: " + filePath);
    }
}
