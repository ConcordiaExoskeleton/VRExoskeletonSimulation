using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ShowTimerOnGrab : MonoBehaviour
{
    public GameObject radialTimerUI;
    public float fillDuration = 10f;
    public Slider radialSlider;

    public GameObject tyingObject;

    private XRGrabInteractable grabInteractable;
    private bool isGrabbed = false;
    private float timer = 0f;
    private bool hasCompleted = false;

    // Grid movement variables
    private Vector3 startPosition = new Vector3(-3f, 0.2f, 0f);
    private float spacing = 0.25f;
    private int cols = 25; // 6m / 0.25 = 24 steps + start
    private int rows = 25;

    private int currentCol = 0;
    private int currentRow = 0;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(OnGrabbed);
            grabInteractable.selectExited.AddListener(OnReleased);
        }

        if (radialTimerUI != null)
        {
            radialTimerUI.SetActive(false);
        }

        if (radialSlider != null)
        {
            radialSlider.value = 0f;
        }

        // Start at the first point
        if (tyingObject != null)
        {
            tyingObject.transform.position = startPosition;
        }
    }

    void Update()
    {
        if (isGrabbed && radialSlider != null)
        {
            timer += Time.deltaTime;
            radialSlider.value = Mathf.Clamp01(timer / fillDuration);

            if (radialSlider.value >= 1f)
            {
                MoveToNextPoint();
                ResetTimer();
            }
        }
    }

    void OnGrabbed(SelectEnterEventArgs args)
    {
        if (!hasCompleted)
        {
            isGrabbed = true;
            radialTimerUI?.SetActive(true);
        }
    }

    void OnReleased(SelectExitEventArgs args)
    {
        isGrabbed = false;
        radialTimerUI?.SetActive(false);
    }

    void MoveToNextPoint()
    {
        currentCol++;
        if (currentCol >= cols)
        {
            currentCol = 0;
            currentRow++;
        }

        if (currentRow >= rows)
        {
            Debug.Log("All ties completed.");
            return;
        }

        Vector3 nextPosition = new Vector3(
            startPosition.x + currentCol * spacing,
            startPosition.y,
            startPosition.z + currentRow * spacing
        );

        if (tyingObject != null)
        {
            transform.position = nextPosition;
            tyingObject.transform.position = nextPosition; 
        }
    }

    void ResetTimer()
    {
        timer = 0f;
        if (radialSlider != null)
        {
            radialSlider.value = 0f;
        }

        radialTimerUI?.SetActive(false);
    }
}
