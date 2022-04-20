using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObstacleItem : MonoBehaviour
{
    [Range(0, 1f)]
    private float currentValue = 1;
    public UnityEvent onDestroyObstacle;

    public void GetDamage(float value)
    {
        currentValue -= value;
        if (currentValue <= 0)
        {
            onDestroyObstacle.Invoke();
            Destroy(gameObject);
        }

        gameObject.GetComponent<Renderer>().material.color = new Color(1, currentValue, currentValue);
    }
}

