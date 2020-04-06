using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunMovement : MonoBehaviour
{
    public Camera mainCamera;
    public Texture2D crosshair;
    void Start()
    {
        Cursor.SetCursor(crosshair, new Vector2(crosshair.width/2,crosshair.height/2), CursorMode.ForceSoftware);
    }
    void Update()
    {

        Move();

    }
    void Move()
    {
        float offsetX = 90f, offsetZ = 90f;
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mainCamera.transform.position.z * -1));
        
        float Z = mousePosition.z - transform.position.z;
        transform.rotation = Quaternion.Euler(Mathf.Abs(offsetX - Mathf.Atan2(mousePosition.y - transform.position.y, Z) * Mathf.Rad2Deg), 0f, Mathf.Abs(offsetZ - Mathf.Atan2(mousePosition.x - transform.position.x, Z) * Mathf.Rad2Deg));
    }
}
