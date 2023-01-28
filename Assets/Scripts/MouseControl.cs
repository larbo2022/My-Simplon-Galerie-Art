using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class MouseControl : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    public bool _leftMouseClick;
    public bool _rightMouseClick;

    [SerializeField] private UnityEvent _myTrigger;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LeftMouseAction() 
    {
        _leftMouseClick = true;
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void LeftMouseClik(InputAction.CallbackContext callbackContext)
    {
        LeftMouseAction();
    }


    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        //object value = _targetScript.MouseInterScript();
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        // throw new System.NotImplementedException();
        //print($"New InputSystem on mouse down called on {this.name}!");
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
        // print($"New InputSystem on mouse Exit called on {this.name}!");
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
        // print($"New InputSystem on mouse Enter called on {this.name}!");
    }

}
