using StarterAssets;
using UnityEngine;

public abstract class GardeningTool : ScriptableObject
{
    protected ThirdPersonController owner;
    public abstract void OnMouseDown();
    public abstract void OnMouseUp();

    public void SetOwner(ThirdPersonController owner)
    {
        this.owner = owner;
    }
}