using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskGroupChainManager : MonoBehaviour
{
    public GameObject[] milestoneObjects;
    private int completedGroups = 0;

    public void NotifyGroupCompleted()
    {
        completedGroups++;

        if (completedGroups % 2 == 0)
        {
            int milestoneIndex = (completedGroups / 2) - 1;
            if (milestoneIndex < milestoneObjects.Length && milestoneObjects[milestoneIndex] != null)
            {
                milestoneObjects[milestoneIndex].SetActive(true);
                Debug.Log($"Milestone {milestoneIndex + 1} revealed after {completedGroups} groups.");
            }
        }
    }
}
