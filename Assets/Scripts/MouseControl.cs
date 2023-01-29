using UnityEngine;
using UnityEngine.InputSystem;

public class MouseControl : MonoBehaviour
{
    public bool _leftMouseClick = false;
    public bool _rightMouseClick = false;

    private void Awake()
    {
        //_mouseControls = new Mouse();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {
    }

    public void LeftMouseAction() 
    {
        Debug.Log("(MouseControl.cs) Left Mouse Button Clicked !");
        _leftMouseClick = false;
    }

    // Update is called once per frame
    public void LeftMouseClik(InputAction.CallbackContext callbackContext)
    {
       _leftMouseClick = true;
       LeftMouseAction();
    }

    private void OnEnable()
    {
        Debug.Log("(MouseLook.cs) OnEnable ON");
        //_mouseControls.Enable();
    }

    private void OnDisable()
    {
        Debug.Log("(MouseLook.cs) OnDisable ON");
        //_mouseControls.Disable();
    }

}
