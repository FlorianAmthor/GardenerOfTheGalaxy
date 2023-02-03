using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHandler : MonoBehaviour
{
    //Local variables
    float rotation = 0;
    float rotationUpDown = 0;

    //Other components
    CharacterController characterController;
    Camera cameraCharacter;
    private bool _jumpInput;

    public Transform followTarget;

    public float minXRotation;
    public float maxXRotation;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();

        cameraCharacter = Camera.main; //GetComponentInChildren<Camera>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (!_jumpInput && Input.GetKey(KeyCode.Space))
        {
            _jumpInput = true;
        }
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        //Get input
        float forwardInput = Input.GetAxis("Vertical");
        float sideInput = Input.GetAxis("Horizontal");
        float turnInput = Input.GetAxisRaw("Mouse X");
        float lookUpInput = Input.GetAxisRaw("Mouse Y");

        //Turn the character with the mouse
        rotation += turnInput * 5;
        transform.localRotation = Quaternion.Euler(0, rotation, 0);

        //Rotate the camera up and down
        rotationUpDown -= lookUpInput * 2;
        rotationUpDown = Mathf.Clamp(rotationUpDown, minXRotation, maxXRotation);
        followTarget.localRotation = Quaternion.Euler(rotationUpDown, 0 , 0);

        //Move the character forward
        characterController.SimpleMove(transform.right * sideInput + transform.forward * (forwardInput * 2));

    }
}
