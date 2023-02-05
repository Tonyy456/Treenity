using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform target;
    [Range(0f, 1f)]
    [SerializeField] private float smoothPercent;

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = target.position;
        Vector3 current = transform.position;
        targetPosition.z = current.z;
        Vector3 newPosition = Vector3.Lerp(current, targetPosition, smoothPercent);
        this.transform.position = newPosition;
    }
}
