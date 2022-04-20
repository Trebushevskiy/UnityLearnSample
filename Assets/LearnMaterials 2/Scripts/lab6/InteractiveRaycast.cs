using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveRaycast : MonoBehaviour
{
    public GameObject wall;
    private InteractiveBox box;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("InteractivePlane"))
                {
                    Instantiate(wall, hit.point + hit.normal * 0.5f, Quaternion.identity);
                }
                if (hit.collider.CompareTag("InteractiveBox"))
                {
                    InteractiveBox tempBox = hit.collider.GetComponent<InteractiveBox>();

                    if (tempBox == null)
                        return;

                    if (box == null)
                    {
                        box = tempBox;
                    }
                    else
                    {
                        box.AddNext(tempBox);
                        box = tempBox;
                    }
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("InteractiveBox"))
                {
                    Destroy(hit.transform.parent.gameObject);
                }
            }
        }
    }
}

