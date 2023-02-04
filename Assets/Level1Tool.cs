using UnityEngine;

[CreateAssetMenu(fileName = "Level1GardeningTool", menuName = "GardeningTools")]
public class Level1Tool : GardeningTool
{
    private Interactable _currentInteractable;
    public float toolRange = 2;

    public override void OnMouseDown()
    {
        //started pressing fire button

        Debug.Log("Started pressing left mouse button");
        var layerMask = LayerMask.GetMask("Interactable");
        if (Physics.Raycast(owner.CinemachineCameraTarget.transform.position, owner.transform.forward, out var hitInfo, toolRange, layerMask))
        {
            _currentInteractable = hitInfo.collider.GetComponent<Interactable>();
            _currentInteractable.StartInteracting();
        }
    }

    public override void OnMouseUp()
    {
        if (_currentInteractable)
            _currentInteractable.CancelInteracting();
    }
}