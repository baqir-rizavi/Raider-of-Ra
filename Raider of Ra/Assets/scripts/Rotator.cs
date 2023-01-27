using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Rotator : Movable
{
    [SerializeField] bool isLeaver = true;
    [SerializeField] Movable nextTargetMovable;
    [SerializeField] Vector3 targetLocalEulerAngle;
    protected override void Engage()
    {
        //Debug.Log(transform.localEulerAngles);
        // Start the rotation coroutine
        StartCoroutine(RotateCoroutine(speed));
        

    }

    IEnumerator RotateCoroutine(float speed)
    {
        // Calculate the desired rotation using Quaternion.Euler
        Quaternion endRotation = Quaternion.Euler(targetLocalEulerAngle);

        // Keep rotating until the game object's local rotation reaches the desired rotation
        while (transform.localRotation != endRotation)
        {
            // Calculate the current rotation by rotating towards the end rotation
            Quaternion rotation = Quaternion.RotateTowards(transform.localRotation, endRotation, speed * Time.deltaTime);

            transform.localRotation = rotation;

            // Wait until the next frame
            yield return null;
        }
        engage = false;
        if (isLeaver)
            if (nextTargetMovable != null && transform.localRotation == endRotation)
                nextTargetMovable.SetEngage(true);
    }
}
