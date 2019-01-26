using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClicker : MonoBehaviour
{
    // Finds object clicked on
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform != null)
                {
                    if (hit.transform.tag == "AddItem")
                    {
                        Canvas.
                    }
                }
            }
        }
    }

    // Prints name of object clicked
    private void PrintName(GameObject go)
    {
        print(go.name);
    }

}
