using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskGroupManager : MonoBehaviour
{
    public GameObject objectToReveal;
    private int completedTasks = 0;
    public int totalTasks = 4;

    private void Start()
    {
        if (objectToReveal != null)
            objectToReveal.SetActive(false);
    }

    public void NotifyTaskCompleted(OnProximity task)
    {
        completedTasks++;
        Debug.Log($"Task completed. Total: {completedTasks}/{totalTasks}");

        if (completedTasks >= totalTasks)
        {
            RevealObject();
        }
    }

    private void RevealObject()
    {
        Debug.Log("All tasks complete — revealing object!");
        if (objectToReveal != null)
            objectToReveal.SetActive(true);
    }
}
