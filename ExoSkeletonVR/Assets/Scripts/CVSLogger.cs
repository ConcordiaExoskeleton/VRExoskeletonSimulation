using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CVSLogger : MonoBehaviour
{
    public static void WriteCSV(List<TimingEntry> entries)
    {
        // Date
        DateTime date = DateTime.Now;
        string formattedDate = date.ToString("yyyy-MM-dd_HH:mm");
        // Path
        string folderPath = Application.persistentDataPath;
        string filePath = Path.Combine(folderPath, "TyingResult_"+formattedDate+".txt");

        using (StreamWriter writer = new StreamWriter(filePath, false))
        {
            writer.WriteLine("index,total time, lap time");
            foreach (var entry in entries)
            {
                string totalFormatted = FormatTime(entry.totalTime);
                string lapFormatted = FormatTime(entry.lapTime);
                writer.WriteLine($"{entry.index},{totalFormatted},{lapFormatted}");
            }
        }
    }

    private static string FormatTime(float timeInSeconds)
    {
        TimeSpan time = TimeSpan.FromSeconds(timeInSeconds);
        return time.ToString(@"hh\:mm\:ss\.fff");
    }
}

[Serializable]
public class TimingEntry
{
    public int index;
    public float totalTime;
    public float lapTime;

    public TimingEntry(int i, float total, float lap)
    {
        index = i;
        totalTime = total;
        lapTime = lap;
    }
}
