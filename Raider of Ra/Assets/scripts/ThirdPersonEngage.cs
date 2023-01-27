using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class ThirdPersonEngage : MonoBehaviour
{
    StarterAssetsInputs staInputs;
    Collider otherCollider = null;

    private void Awake()
    {
        staInputs = GetComponent<StarterAssetsInputs>();
    }
    // Update is called once per frame
    void Update()
    {
       if (staInputs.engage)
       {
            if (otherCollider)
            {
                Movable m = otherCollider.gameObject.GetComponent<Movable>();
                if (m)
                    m.SetEngage(true);
                else
                {
                    Movable mchild = otherCollider.gameObject.GetComponentInChildren<Movable>();
                    if (mchild != null)
                        mchild.SetEngage(true);
                    else
                        Debug.LogError("no script movable");
                }
            }
       }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("I " + gameObject.name + " him " + other.name);
        otherCollider = other;
    }

    private void OnTriggerExit(Collider other)
    {
        otherCollider = null;
    }
}
