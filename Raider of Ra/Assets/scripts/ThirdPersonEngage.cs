using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class ThirdPersonEngage : MonoBehaviour
{
    [SerializeField] float radius; 
    [SerializeField] float distance;
    [SerializeField] LayerMask layerMask;

    StarterAssetsInputs staInputs;

    private void Awake()
    {
        staInputs = GetComponent<StarterAssetsInputs>();
    }
    // Update is called once per frame
    void Update()
    {
       if (staInputs.engage)
       {
            RaycastHit hit;
            if (Physics.SphereCast(transform.position, radius, transform.forward, out hit, distance, layerMask))
            {
                // If the sphere cast hits an object, log the object's name
                //Debug.Log("Hit object: " + hit.collider.gameObject.name);
                Movable m = hit.collider.gameObject.GetComponent<Movable>();
                if (m != null)
                    m.SetEngage(true);
                else
                {
                    Movable mchild = hit.collider.gameObject.GetComponentInChildren<Movable>();
                    if (mchild != null)
                        mchild.SetEngage(true);
                    else
                        Debug.LogError("no script movable");
                }
            }
       }
    }
}
