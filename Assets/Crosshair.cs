using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        print(mouseX);
        print(mouseY);
        if (Input.GetMouseButtonDown(0))
        {
            print("Fire!");
        }
    }

    void GetMousePos()
    {

    }
}
