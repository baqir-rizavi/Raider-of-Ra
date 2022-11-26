using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] Vector3 axis = Vector3.up;
    [SerializeField] Space space = Space.Self;
    private void Start()
    {
        axis = axis.normalized;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(axis * speed * Time.deltaTime, space);
    }

    public float GetSpeed()
    {
        return speed;
    }

    public void SetSpeed(float s)
    {
        speed = s;
    }
}
