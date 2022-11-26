using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using Unity.VisualScripting;
using Unity.PlasticSCM.Editor.WebApi;

public class pathFollower : MonoBehaviour
{
    [SerializeField] PathCreator pathCreator;
    [SerializeField] float speed;
    [SerializeField] bool rotation = false;
    float dstTravelled;
    Vector3 pos = Vector3.zero;
    bool completed = false;

    private void Start()
    {
        transform.rotation = pathCreator.path.GetRotationAtDistance(5f);
    }
    // Update is called once per frame
    void Update()
    {
        dstTravelled += speed * Time.deltaTime;
        
        transform.position = pathCreator.path.GetPointAtDistance(dstTravelled, EndOfPathInstruction.Stop);
        if (rotation)
            transform.rotation = pathCreator.path.GetRotationAtDistance(dstTravelled);

        if (transform.position == pathCreator.path.GetPoint(pathCreator.path.localPoints.Length - 1))
        {
            //Debug.Log("c");
            completed = true;
            //Destroy(pathCreator);
        }
    }

    public bool IsCompleted()
    {
        return completed;
    }
}
