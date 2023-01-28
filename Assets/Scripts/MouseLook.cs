using UnityEngine;
using UnityEngine.InputSystem; 

public class MouseLook : MonoBehaviour
{
    [SerializeField] float _zoomCameraModifier = 32.0f;
    public float zoomCameraInput { get; private set; } = 0.0f;
    public bool invertScroll { get; private set; } = true;

    private float mouseSensitivity = 20.0f;
    private float mouseZoomSensitivity = 10f;
    private Vector2 mouseLook, mouseZoomLook;
    private Transform playerBody;
    private My_First_Person_Player_Controls controls; /* The use of this My_First_Person_Player_Controls() 
                                                         allows to access the Player_Controller only by using script
                                                         there is no need to set the Player Input component */
    private float xRotation = 0.0f;

    private float _minCameraZoomDistance = 0.0f;
    private float _maxCameraZoomDistance = 12.0f;
    private float _minOrbitCameraZoomDistance = 1.0f;
    private float _maxOrbitCameraZoomDistance = 36.0f;


    private void Awake()
    {
        playerBody = transform.parent;
        controls = new My_First_Person_Player_Controls();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnEnable()
    {
        controls.Enable();
        controls.Player.MouseZoomScrollY.started += SetCameraZoom;
        controls.Player.MouseZoomScrollY.canceled += SetCameraZoom;

    }

    public void SetCameraZoom(InputAction.CallbackContext obj)
    {
        zoomCameraInput = obj.ReadValue<float>();
    }

    private void OnDisable()
    {
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

    private void Zoom() // WIP
    {
        mouseZoomLook = controls.Player.Camera_Look.ReadValue<Vector2>();
        float zoomFactor = mouseZoomLook.sqrMagnitude * mouseZoomSensitivity * Time.deltaTime;
        //transform.localPosition = Vector2.zero;
        
        // Debug.Log("mouseZoomLook = " + mouseZoomLook);
        // Debug.Log("zoomFactor = " + zoomFactor);
    }

    private void SetZoomCamera(InputAction.CallbackContext context)
    {
        zoomCameraInput = context.ReadValue<float>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Vector2 mouseCursorPosition= Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // transform.position = mouseCursorPosition;
        Look();
        Zoom();
    }
}
