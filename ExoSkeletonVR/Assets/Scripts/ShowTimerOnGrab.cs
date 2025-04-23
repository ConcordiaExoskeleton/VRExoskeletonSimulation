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

    private XRGrabInteractable grabInteractable;
    private bool isGrabbed = false;
    private float timer = 0f;

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
            if (radialSlider != null)
                radialSlider.value = 0f;
            else
                Debug.LogWarning("No Slider component found on radialTimerUI!");
        }
    }

    void Update()
    {
        if (isGrabbed && radialSlider != null)
        {
            timer += Time.deltaTime;
            radialSlider.value = Mathf.Clamp01(timer / fillDuration);
        }
    }

    void OnGrabbed(SelectEnterEventArgs args)
    {
        isGrabbed = true;
        radialTimerUI?.SetActive(true);
    }

    void OnReleased(SelectExitEventArgs args)
    {
        isGrabbed = false;
        radialTimerUI?.SetActive(false);

    }
}