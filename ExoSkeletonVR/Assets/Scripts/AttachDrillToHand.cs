using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachDrillToHand : MonoBehaviour
{
    public GameObject rightHand;       
    public GameObject drill;
    public bool attachOnStart = true;
    public Vector3 localPositionOffset;

    void Start()
    {
        if (attachOnStart)
            AttachDrill();
    }

    public void AttachDrill()
    {
        // Find the "Grip Pose" transform
        Transform gripPose = rightHand.transform.Find("Grip Pose");
        if (gripPose != null && drill != null)
        {
            drill.transform.SetParent(gripPose);
            drill.transform.localPosition = localPositionOffset;
            drill.transform.localRotation = Quaternion.Euler(7, 0, 90);
        }
        else
        {
            Debug.LogWarning("Grip Pose or Drill not found");
        }
    }
}
