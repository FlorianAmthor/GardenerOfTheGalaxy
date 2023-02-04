using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;

		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;
		public bool switchCamera;
		public bool fire;
		public bool switchTool;
		public ToolManager.Tool toolToSwitchTo;

#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}

		public void OnSwitchCamera(InputValue value)
		{
			SwitchCameraInput();
		}

		public void OnFire(InputValue value)
		{
			FireInput(value.isPressed);
		}
		
		public void OnEquipTool1(InputValue value)
		{
			EquipTool(ToolManager.Tool.Level1);
		}
		
		public void OnEquipTool2(InputValue value)
		{
			EquipTool(ToolManager.Tool.Level2);
		}
		
		public void OnEquipTool3(InputValue value)
		{
			EquipTool(ToolManager.Tool.Level3);
		}
#endif


		public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}

		public void SwitchCameraInput()
		{
			switchCamera = true;
		}

		public void FireInput(bool isPressed)
		{
			fire = isPressed;
		}

		private void EquipTool(ToolManager.Tool tool)
		{
			switchTool = true;
			toolToSwitchTo = tool;
		}
		
		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}
	}
	
}