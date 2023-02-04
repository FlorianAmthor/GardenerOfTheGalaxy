using StarterAssets;
using UnityEngine;

public class ToolManager : MonoBehaviour
{
    public Tool currentTool;
    [SerializeField] private GardeningTool _gardeningTool1;
    [SerializeField] private GardeningTool _gardeningTool2;
    [SerializeField] private GardeningTool _gardeningTool3;
    
    private GardeningTool _currentGardeningTool;
    public enum Tool
    {
        Level1    
    }

    private void Awake()
    {
        SwitchTool(Tool.Level1);
        _currentGardeningTool.SetOwner(GetComponent<ThirdPersonController>());
    }

    public void OnMousePressed()
    {
        _currentGardeningTool.MousePressed();
    }

    public void OnMouseReleased()
    {
        _currentGardeningTool.MouseReleased();
    }

    public void SwitchTool(Tool tool)
    {
        currentTool = tool;
        _currentGardeningTool = currentTool switch
        {
            Tool.Level1 => _gardeningTool1,
            _ => _currentGardeningTool
        };
        //disable all tools except the current one
    }
}
