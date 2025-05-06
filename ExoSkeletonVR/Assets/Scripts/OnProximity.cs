using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class OnProximity : MonoBehaviour
{
    public string requiredTag;
    public GameObject radialTimerUI;
    public Slider radialSlider;
    public float fillDuration = 10f;

    public TaskGroupManager taskManager;

    private bool isInProximity = false;
    private float timer = 0f;
    private Coroutine fadeCoroutine;
    private bool hasCompleted = false;

    private void Start()
    {
        if (radialTimerUI != null)
        {
            radialTimerUI.SetActive(false);
        }

        if (radialSlider != null) {
            radialSlider.value = 0f;
        }
    }

    private void Update()
    {
        if (isInProximity && radialSlider != null)
        {
            timer += Time.deltaTime;
            radialSlider.value = Mathf.Clamp01(timer / fillDuration);
            
            if (radialSlider.value >= 1f)
            {
                Debug.Log("Timer completed.");
                hasCompleted = true;
                taskManager?.NotifyTaskCompleted(this);
                gameObject.SetActive(false);
                radialTimerUI.SetActive(false);

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(requiredTag))
        {
            if (!isInProximity)
            {
                isInProximity = true;
                if (radialTimerUI != null)
                {
                    radialTimerUI.SetActive(true);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(requiredTag))
        {
            isInProximity = false;
            radialTimerUI.SetActive(false);
        }
    }
}
