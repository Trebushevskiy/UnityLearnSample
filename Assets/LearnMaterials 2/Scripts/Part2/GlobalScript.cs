using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalScript : MonoBehaviour
{
    [ContextMenu("Start")]
    void Use()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Object");

        foreach (GameObject obj in objects)
        {
            var script = obj.GetComponent<BaseScript>();
            if (script != null)
                script.Use();
        }
    }
}
