using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public UnityEvent OnInteractStarted;
    public UnityEvent OnInteractFinished;
    public UnityEvent OnInteractCancelled;

    
    public float timeToFinishInteraction;
    private float _interactionStarted = float.MinValue;
    private Coroutine _interactionCoroutine;
    
    public void StartInteracting()
    {
        Debug.Log($"Started Interaction with {name}");
        _interactionStarted = Time.time;
        OnInteractStarted.Invoke();
        _interactionCoroutine = StartCoroutine(CheckInteractionTime());
    }

    private IEnumerator CheckInteractionTime()
    {
        while (Time.time - _interactionStarted < timeToFinishInteraction)
        {
            Debug.Log(Time.time - _interactionStarted);
            yield return new WaitForEndOfFrame();
        }
        FinishInteraction();
    }

    private void FinishInteraction()
    {
        Debug.Log($"Interaction successful with {name}");
        ResetInteractionTime();
        OnInteractFinished.Invoke();
    }
    
    public void CancelInteracting()
    {
        Debug.Log($"Cancelled interaction with {name}");
        StopCoroutine(_interactionCoroutine);
        ResetInteractionTime();
        OnInteractCancelled.Invoke();
    }

    private void ResetInteractionTime()
    {
        _interactionStarted = float.MinValue;
    }
}
