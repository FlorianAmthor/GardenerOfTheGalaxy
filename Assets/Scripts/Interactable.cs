using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    public UnityEvent OnInteractStarted;
    public UnityEvent OnInteractFinished;
    public UnityEvent OnInteractCancelled;

    public float timeToFinishInteraction;
    private float _interactionStarted = float.MinValue;
    private Coroutine _interactionCoroutine;
    [SerializeField] private Image _interactionImage;

    private void Awake()
    {
        print(_interactionImage);
    }

    public void StartInteracting()
    {
        Debug.Log($"Started Interaction with {name}");
        _interactionStarted = Time.time;
        OnInteractStarted.Invoke();
        _interactionCoroutine = StartCoroutine(CheckInteractionTime());
    }

    private IEnumerator CheckInteractionTime()
    {
        float timeDifferenceSinceStart = Time.time - _interactionStarted;
        while (timeDifferenceSinceStart < timeToFinishInteraction)
        {
            Debug.Log(Time.time - _interactionStarted);
            if (_interactionImage)
                _interactionImage.fillAmount = timeDifferenceSinceStart / timeToFinishInteraction;
            yield return new WaitForEndOfFrame();
            timeDifferenceSinceStart = Time.time - _interactionStarted;
        }

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
        if (_interactionCoroutine != null)
            StopCoroutine(_interactionCoroutine);
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