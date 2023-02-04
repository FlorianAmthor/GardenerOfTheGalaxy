using StarterAssets;
using UnityEngine;

[CreateAssetMenu(fileName = "GardeningTool", menuName = "GardeningTools")]
public class GardeningTool : ScriptableObject
{
    private ThirdPersonController _owner;
    public ToolManager.Tool toolType;
    private Interactable _currentInteractable;
    public float toolRange = 2;

    public void MousePressed()
    {
        var layerMask = LayerMask.GetMask("Interactable");
        if (Physics.Raycast(_owner.CinemachineCameraTarget.transform.position, _owner.transform.forward, out var hitInfo, toolRange, layerMask))
        {
            _currentInteractable = hitInfo.collider.GetComponent<Interactable>();
            _currentInteractable.StartInteracting(toolType);
        }
    }

    public void MouseReleased()
    {
        if (_currentInteractable)
            _currentInteractable.CancelInteracting();
    }

    public void SetOwner(ThirdPersonController owner)
    {
        _owner = owner;
    }
}