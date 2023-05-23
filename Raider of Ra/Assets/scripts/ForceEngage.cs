using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceEngage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Movable>().engage = true;
        
    }
}
