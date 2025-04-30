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
    public List<ParticleSystem> finishParticles;
    public GameObject tyingObject;

    private XRGrabInteractable grabInteractable;
    private bool isGrabbed = false;
    private float timer = 0f;
    private bool hasCompleted = false;

    private Vector3 startPosition = new Vector3(-3f, 0.05f, 0f);
    private float spacing = 0.25f;
    private int cols = 25; // 6m / 0.25 = 24 steps + start
    private int rows = 25;

    private int currentCol = 0;
    private int currentRow = 0;
    
    public float maxGrabDistance = 1.5f;
    private Transform interactorTransform;

    public GameObject spawnPrefab;

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
        if (isGrabbed && interactorTransform != null)
        {
            float distance = Vector3.Distance(transform.position, interactorTransform.position);
            if (distance > maxGrabDistance)
            {
                grabInteractable.interactionManager.SelectExit(interactorTransform.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactors.IXRSelectInteractor>(), grabInteractable);
                isGrabbed = false;
                radialTimerUI?.SetActive(false);
            }
        }

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
        interactorTransform = args.interactorObject.transform;
        if (!hasCompleted)
        {
            isGrabbed = true;
            radialTimerUI?.SetActive(true);
        }
    }

    void OnReleased(SelectExitEventArgs args)
    {
        interactorTransform = null;
        isGrabbed = false;
        radialTimerUI?.SetActive(false);
    }

    public void StartGrab()
    {
        if (!hasCompleted)
        {
            isGrabbed = true;
            radialTimerUI?.SetActive(true);
        }
    }

    public void EndGrab()
    {
        isGrabbed = false;
        radialTimerUI?.SetActive(false);
    }

    void MoveToNextPoint()
    {
        Quaternion spawnRotation = Quaternion.Euler(-90f, 0f, 0f);

        if ((currentCol == 0 && currentRow == 0) ||
        (currentCol == cols - 1 && currentRow == 0) ||
        (currentCol == 0 && currentRow == rows - 1) ||
        (currentCol == cols - 1 && currentRow == rows - 1))
        {
            spawnRotation = Quaternion.Euler(-90f, 0f, 50f);
        }

        if (spawnPrefab != null)
        {
            Vector3 spawnPosition = transform.position;

            if (currentRow % 5 == 0)
            {
                spawnPosition.y -= 0.02f;
            }

            Instantiate(spawnPrefab, spawnPosition, spawnRotation);
        }

        currentCol++;
        if (currentCol >= cols)
        {
            currentCol = 0;
            currentRow++;
        }

        if (currentRow >= rows)
        {
            Debug.Log("All ties completed.");
            foreach (var ps in finishParticles)
            {
                if (ps != null)
                    ps.Play();
            }
            Destroy(tyingObject.transform.root.gameObject);
            Destroy(transform.root.gameObject);
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
