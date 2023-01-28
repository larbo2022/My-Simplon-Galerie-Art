using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DetailPeinture : MonoBehaviour
{
    public Texture2D normalCursor;
    public Vector2 normalCursorHotSpot;

    public Texture2D onHooverCursor;
    public Vector2 onLegendCursorHotSpot;

    Ray ray;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void ChekForCollidors()
    {
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
            if (hitInfo.collider.CompareTag("Légende"))
            {
            Debug.Log(hitInfo.collider.gameObject.name + " was hit !");
            Cursor.SetCursor(onHooverCursor, onLegendCursorHotSpot, CursorMode.Auto);
            }
        else
        {

        }
    }

    private void onButtonCursorEnter()
    {
        Cursor.SetCursor(onHooverCursor, onLegendCursorHotSpot, CursorMode.Auto);
    }

    private void onButtonCursorExit()
    {
        Cursor.SetCursor(normalCursor, normalCursorHotSpot, CursorMode.Auto);
    }

    // Update is called once per frame
    private void Update()
    {
        ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        // ray = new Ray(transform.position, transform.forward);
        ChekForCollidors();
    }
}
