using UnityEngine;

public class DetailPeinture : MonoBehaviour
{
    //[SerializeField] private Texture2D normalCursor;
    //public Vector2 normalCursorHotSpot = Vector2.zero;

    //[SerializeField] private Texture2D onHooverCursor;
    //public Vector2 onLegendCursorHotSpot = Vector2.zero;

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
            Debug.Log("(DetailPeinture.cs) " + hitInfo.collider.gameObject.name + " was hit !");
            //Cursor.SetCursor(onHooverCursor, onLegendCursorHotSpot, CursorMode.Auto);
            }
        else
        {

        }
    }

    private void onButtonCursorEnter()
    {
        Debug.Log("(DetailPeinture.cs) onButtonCursorEntered OK !");
        //Cursor.SetCursor(onHooverCursor, onLegendCursorHotSpot, CursorMode.Auto);
    }

    private void onButtonCursorExit()
    {
        Debug.Log("(DetailPeinture.cs) onButtonCursorExited OK !");
        //Cursor.SetCursor(normalCursor, normalCursorHotSpot, CursorMode.Auto);
    }

    // Update is called once per frame
    private void Update()
    {
        ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        Cursor.visible = true;
        ChekForCollidors();
    }
}
