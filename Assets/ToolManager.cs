using System;
using StarterAssets;
using UnityEngine;
using UnityEngine.UI;

public class ToolManager : MonoBehaviour
{
    public Tool currentTool;
    public bool tool1Unlocked;
    public bool tool2Unlocked;
    public bool tool3Unlocked;

    [SerializeField] private GardeningTool _gardeningToolNone;
    [SerializeField] private GardeningTool _gardeningTool1;
    [SerializeField] private GardeningTool _gardeningTool2;
    [SerializeField] private GardeningTool _gardeningTool3;

    [SerializeField] private Image _tool1Image;
    [SerializeField] private Image _tool2Image;
    [SerializeField] private Image _tool3Image;
    
    private GardeningTool _currentGardeningTool;

    public enum Tool
    {
        None,
        Level1,
        Level2,
        Level3
    }

    private void Awake()
    {
        SwitchTool(Tool.None);
        UpdateToolUIImages();
        _currentGardeningTool.SetOwner(GetComponent<ThirdPersonController>());
    }

    private void UpdateToolUIImages()
    {
        _tool1Image.color = new Color(1, 1, 1, tool1Unlocked ? 1 : 0.33f);
        _tool2Image.color = new Color(1, 1, 1, tool2Unlocked ? 1 : 0.33f);
        _tool3Image.color = new Color(1, 1, 1, tool3Unlocked ? 1 : 0.33f);
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
        if (tool.Equals(Tool.None))
        {
            currentTool = tool;
            _currentGardeningTool = _gardeningToolNone;
            return;
        }
        
        if (currentTool.Equals(tool))
            return;

        if (tool.Equals(Tool.Level1) && !tool1Unlocked)
        {
            Debug.Log("Tool1 is not yet unlocked");
            return;
        }
        
        if (tool.Equals(Tool.Level2) && !tool2Unlocked)
        {
            Debug.Log("Tool2 is not yet unlocked");
            return;
        }
        
        if (tool.Equals(Tool.Level3) && !tool3Unlocked)
        {
            Debug.Log("Tool3 is not yet unlocked");
            return;
        }

        Debug.Log($"Switched tool to {tool}");
        currentTool = tool;
        _currentGardeningTool = tool switch
        {
            Tool.Level1 => _gardeningTool1,
            Tool.Level2 => _gardeningTool2,
            Tool.Level3 => _gardeningTool3,
            _ => _currentGardeningTool
        };
    }

    public void UnlockTool1(bool value)
    {
        tool1Unlocked = value;
        UpdateToolUIImages();
    }

    public void UnlockTool2(bool value)
    {
        tool2Unlocked = value;
        UpdateToolUIImages();
    }

    public void UnlockTool3(bool value)
    {
        tool3Unlocked = value;
        UpdateToolUIImages();
    }
}