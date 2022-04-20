using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveBox : MonoBehaviour
{
    [SerializeField]
    private InteractiveBox next;


    void Update()
    {
        if (next == null)
            return;

        RaycastHit hit;

        Vector3 direction = next.transform.position - transform.position;

        if (Physics.Raycast(transform.position, direction, out hit))
        {
            hit.transform.GetComponent<ObstacleItem>()?.GetDamage(Time.deltaTime);
        }

        Debug.DrawRay(transform.position, direction, Color.red);
    }

    public void AddNext(InteractiveBox nextBox)
    {
        if (nextBox != null)
            next = nextBox;
    }
}
