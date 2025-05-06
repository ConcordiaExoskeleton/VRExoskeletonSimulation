using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskGroupManager : MonoBehaviour
{
    public GameObject[] tasks;
    public TaskGroupManager nextGroup;

    private int currentTaskIndex = 0;

    private void Start()
    {
        
        for (int i = 0; i < tasks.Length; i++)
        {
            tasks[i].SetActive(i == 0);
        }
    }

    public void NotifyTaskCompleted(OnProximity task)
    {
        
        if (currentTaskIndex < tasks.Length)
        {
            tasks[currentTaskIndex].SetActive(false);
        }

        currentTaskIndex++;

        
        if (currentTaskIndex < tasks.Length)
        {
            tasks[currentTaskIndex].SetActive(true);
        }
        else
        {
            Debug.Log("Task group completed!");
            if (nextGroup != null)
            {
                nextGroup.gameObject.SetActive(true);
                nextGroup.ActivateGroup();
            }
        }
    }

    public void ActivateGroup()
    {
        currentTaskIndex = 0;

        for (int i = 0; i < tasks.Length; i++)
        {
            tasks[i].SetActive(i == 0);
        }
    }
}
