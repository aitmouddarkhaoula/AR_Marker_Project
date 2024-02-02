using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    [SerializeField] Camera _camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 screenPosition = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
            Vector2 worldPosition =_camera.ScreenToWorldPoint(screenPosition);
            Debug.Log("Mouse Clicked" +screenPosition);
        }
    }
}
