using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance {  get { return instance; } }
    private void Awake()
    {
        instance = this;
    }

    public Vector3 mousePos;
    public bool isTouch;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetIsTouch();
        SetMousePos();  
    }

    void SetMousePos()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void SetIsTouch()
    {
        if(Input.GetMouseButtonDown(0))
        {
            isTouch = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isTouch = false;
        }
    }

    public Vector3 GetMousePos()
    {
        return mousePos;
    }
    public bool GetIsTouch()
    {
        return isTouch;
    }


}
