using StarterAssets;
using UnityEngine;

public abstract class GardeningTool : ScriptableObject
{
    protected ThirdPersonController owner;
    public abstract void MousePressed();
    public abstract void MouseReleased();

    public void SetOwner(ThirdPersonController owner)
    {
        this.owner = owner;
    }
}