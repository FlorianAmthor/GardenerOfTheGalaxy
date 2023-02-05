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
    
    [Space(10)]
    [Header("Tool1 Images")]
    [SerializeField, Tooltip("Tool1 inactive.")] private Sprite _tool1InactiveSprite;
    [SerializeField,Tooltip("Tool1 active.")] private Sprite _tool1ActiveSprite;
    [Header("Tool2 Images")]
    [SerializeField, Tooltip("Tool2 inactive.")] private Sprite _tool2InactiveSprite;
    [SerializeField,Tooltip("Tool2 active.")] private Sprite _tool2ActiveSprite;
    [Header("Tool3 Images")]
    [SerializeField, Tooltip("Tool3 inactive.")] private Sprite _tool3InactiveSprite;
    [SerializeField, Tooltip("Tool3 active.")] private Sprite _tool3ActiveSprite;
    
    private GardeningTool _currentGardeningTool;
    private ThirdPersonController _owner;

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
        _owner = GetComponent<ThirdPersonController>();
        _currentGardeningTool.SetOwner(_owner);
    }

    private void UpdateToolUIImages()
    {
        _tool1Image.sprite = currentTool.Equals(Tool.Level1) ? _tool1ActiveSprite : _tool1InactiveSprite;
        _tool2Image.sprite = currentTool.Equals(Tool.Level2) ? _tool2ActiveSprite : _tool2InactiveSprite;
        _tool3Image.sprite = currentTool.Equals(Tool.Level3) ? _tool3ActiveSprite : _tool3InactiveSprite;
        
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
        UpdateToolUIImages();
        _currentGardeningTool.SetOwner(_owner);
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