using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Activate_Deactivate_GameObjects : MonoBehaviour
{
    public GameObject GameObjectToDeactivate;
    public MouseControl _mouseControl;

    // Start is called before the first frame update
    void Start()
    {
        //if (_mouseControl._leftMouseClick)
        //{
        //    Debug.Log("Left Mouse Cliked");
        //    GameObjectToDeactivate.SetActive(true);
        //}
        //if (!_mouseControl._leftMouseClick)
        //{
        //    GameObjectToDeactivate.SetActive(false);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (_mouseControl._leftMouseClick)
        {
            Debug.Log("(Activate_Deactivate_GameObjects.cs) Left Mouse Cliked");
            GameObjectToDeactivate.SetActive(true);
        }
        if (!_mouseControl._leftMouseClick)
        {
            GameObjectToDeactivate.SetActive(false);
        }

    }
}
