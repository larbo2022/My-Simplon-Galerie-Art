using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using static UnityEngine.GraphicsBuffer;

public class MouseLook : MonoBehaviour
{
    public float zoomCameraInput { get; private set; } = 0.0f;
    public float newZoomLevel = 0.0f;
    public float sensitivity = 1;

    private float mouseSensitivity = 20.0f;
    private float mouseScrollSensitivity = 5.0f;
    private Vector2 mouseLook;
    private Transform playerBody;
    private My_First_Person_Player_Controls controls; /* The use of this 'My_First_Person_Player_Controls()' 
                                                         allows to access the Player_Controller only by using script
                                                         there is no need to set the Player Input component */
    private float xRotation = 0.0f;

    private float _minCameraFieldOfView = 60.0f;    // (Facteur de zomm min)
    private float _maxCameraFieldOfView = 10.0f;    // (Facteur de zomm max)
    private float scrollingValue;

    private float new_FieldOfView;
    private float read_FieldOfView = 0.0f;

    private void Awake()
    {
        playerBody = transform.parent;
        controls = new My_First_Person_Player_Controls();
        Cursor.lockState = CursorLockMode.Locked;
        controls.Player.MouseZoomScrollY.performed += _x => scrollingValue = _x.action.ReadValue<float>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Look();
        ZoomCamera();
    }

    public void SetCameraZoom(InputAction.CallbackContext context)
    {
        zoomCameraInput = context.ReadValue<float>();
        Debug.Log("(MouseLook.cs) zoomCameraInput = " + zoomCameraInput);
    }

    private void OnEnable()
    {
        //Debug.Log("(MouseLook.cs) OnEnable ON");

        controls.Enable();
        controls.Player.MouseZoomScrollY.started += SetCameraZoom;
        controls.Player.MouseZoomScrollY.canceled += SetCameraZoom;
    }

    private void OnDisable()
    {
        //Debug.Log("(MouseLook.cs) OnDisable ON");

        controls.Disable();
        controls.Player.MouseZoomScrollY.started -= SetCameraZoom;
        controls.Player.MouseZoomScrollY.canceled -= SetCameraZoom;
    }

    private void Look()
    {
        mouseLook = this.controls.Player.Camera_Look.ReadValue<Vector2>();

        float mouseX = mouseLook.x * mouseSensitivity * Time.deltaTime;
        float mouseY = mouseLook.y * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector2.up * mouseX);
    }

    private void ZoomCamera()
    {
        read_FieldOfView = this.GetComponent<Camera>().fieldOfView;
        Debug.Log("(MouseLook.cs) Facteur de zoom lu " + read_FieldOfView);

        if (scrollingValue > 0.0f)
        {
            // Debug.Log("(MouseLook.cs) scrolling-UP");
            new_FieldOfView = Mathf.Clamp((read_FieldOfView + mouseScrollSensitivity), _maxCameraFieldOfView, _minCameraFieldOfView);
            this.GetComponent<Camera>().fieldOfView = new_FieldOfView;
            //this.GetComponent<Camera>().fieldOfView += 1 * mouseScrollSensitivity;
        }
        if (scrollingValue < 0.0f)
        {
            // Debug.Log("(MouseLook.cs) scrolling-DOWN");
            new_FieldOfView = Mathf.Clamp((read_FieldOfView - mouseScrollSensitivity), _maxCameraFieldOfView, _minCameraFieldOfView);
            this.GetComponent<Camera>().fieldOfView = new_FieldOfView;
            //this.GetComponent<Camera>().fieldOfView -= 1 * mouseScrollSensitivity;
        }
    }
}
