using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachDrill : MonoBehaviour
{
    public Transform handTransform;

    void Start()
    {
        transform.SetParent(handTransform);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }
}
