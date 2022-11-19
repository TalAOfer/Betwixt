using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    private Vector2 mousePos;

    private void Awake()
    {
        Cursor.visible = false;    
    }

    // Update is called once per frame
    void Update()
    {
       transform.position = mousePos;
    }



    public void UpdateMousePos(Component sender, object data)
    {
        mousePos = (Vector2) data;
    }

}
