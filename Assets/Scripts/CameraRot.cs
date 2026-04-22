using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CameraRot : MonoBehaviour
{
    [SerializeField] private float rotateTime;
    private Quaternion fromRotate;
    private Quaternion toRotate;
    private float timePassed = 5f; // initialized high so rotation is immediately available

    // snapping rotation
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && timePassed >= rotateTime)
        {
            fromRotate = transform.rotation;
            toRotate = fromRotate * quaternion.RotateY(45f * Mathf.Deg2Rad);
            timePassed = 0f;
        }
        if (Input.GetKeyDown(KeyCode.Q) && timePassed >= rotateTime)
        {
            fromRotate = transform.rotation;
            toRotate = fromRotate * quaternion.RotateY(-45f * Mathf.Deg2Rad);
            timePassed = 0f;
        }

        if (!quaternion.Equals(fromRotate, toRotate))
        {
            transform.rotation = Quaternion.Lerp(fromRotate, toRotate, timePassed/rotateTime);
            timePassed += Time.deltaTime;
        }
    }
}
