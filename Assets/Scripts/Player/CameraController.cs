using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] float yPositionBuffer;

    void Update()
    {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y + yPositionBuffer, -10);
    }
}
