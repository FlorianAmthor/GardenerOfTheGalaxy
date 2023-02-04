using UnityEngine;

[CreateAssetMenu(fileName = "Level1GardeningTool", menuName = "GardeningTools")]
public class Level1Tool : GardeningTool
{
    private Interactable _currentInteractable;
    public float toolRange = 2;

    public override void MousePressed()
    {
        var layerMask = LayerMask.GetMask("Interactable");
        if (Physics.Raycast(owner.CinemachineCameraTarget.transform.position, owner.transform.forward, out var hitInfo, toolRange, layerMask))
        {
            _currentInteractable = hitInfo.collider.GetComponent<Interactable>();
            _currentInteractable.StartInteracting();
        }
    }

    public override void MouseReleased()
    {
        if (_currentInteractable)
            _currentInteractable.CancelInteracting();
    }
}