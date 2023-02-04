using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    public ToolManager.Tool requiredToolType;
    
    public UnityEvent OnInteractStarted;
    public UnityEvent OnInteractFinished;
    public UnityEvent OnInteractCancelled;

    public float timeToFinishInteraction;
    private float _interactionStarted = float.MinValue;
    [SerializeField] private Image _interactionImage;

    private bool wasCancelled;

    private void Awake()
    {
        print(_interactionImage);
    }

    public void StartInteracting(ToolManager.Tool toolType)
    {
        if (!requiredToolType.Equals(toolType))
            return;
        Debug.Log($"Started Interaction with {name}");
        _interactionStarted = Time.time;
        wasCancelled = false;
        OnInteractStarted.Invoke();
        StartCoroutine(CheckInteractionTime());
    }

    private IEnumerator CheckInteractionTime()
    {
        while (Time.time - _interactionStarted < timeToFinishInteraction)
        {
            if (_interactionImage)
                _interactionImage.fillAmount = (Time.time - _interactionStarted) / timeToFinishInteraction;
            yield return new WaitForEndOfFrame();
        }

        if (!wasCancelled)
            FinishInteraction();
    }

    private void FinishInteraction()
    {
        Debug.Log($"Interaction successful with {name}");
        ResetInteractionTime();

        if (_interactionImage)
            _interactionImage.fillAmount = 0;
        OnInteractFinished.Invoke();
    }

    public void CancelInteracting()
    {
        Debug.Log($"Cancelled interaction with {name}");
        wasCancelled = true;
        StopCoroutine(CheckInteractionTime());
        if (_interactionImage)
            _interactionImage.fillAmount = 0;
        ResetInteractionTime();
        OnInteractCancelled.Invoke();
    }

    private void ResetInteractionTime()
    {
        _interactionStarted = float.MinValue;
    }
}