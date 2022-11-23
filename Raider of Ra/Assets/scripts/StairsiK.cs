using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsiK : MonoBehaviour
{
    [SerializeField] Transform tooHigh;
    [SerializeField] Transform climbableLow;
    [SerializeField] LayerMask lm;
    [SerializeField] float stepSize = 0.6f;
    ThirdPersonController controller;


    private void Awake()
    {
        controller = GetComponent<ThirdPersonController>();
    }

    void Update()
    {
        
    }
}
