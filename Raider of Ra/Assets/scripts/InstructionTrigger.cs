using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InstructionTrigger : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI subts;
    [SerializeField] string insText = "";
    [SerializeField] float holdFor = 5f;
    [SerializeField] bool onstart = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            subts.text = insText;
            StartCoroutine(stop());            
        }

    }
    IEnumerator stop() { 
        yield return new WaitForSeconds(holdFor);
        subts.text = "";
    
    }

    private void Start()
    {
        if (onstart)
        {
            subts.text = insText;
            StartCoroutine(stop());
        }
    }
}
