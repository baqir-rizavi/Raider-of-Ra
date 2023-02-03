using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEngageWater : MonoBehaviour
{
    [SerializeField] GameObject disableColliderObject; 
    
    // Update is called once per frame
    void Update()
    {
        if (GetComponent<PathSumoner>().engage)
        {
            Destroy(disableColliderObject.transform.GetComponent<BoxCollider>());
        }
    }
}
