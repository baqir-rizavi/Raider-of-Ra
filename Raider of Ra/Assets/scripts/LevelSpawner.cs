using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelSpawner : MonoBehaviour
{
    [SerializeField] int nextLevelBuildIndex = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            SceneManager.LoadScene(nextLevelBuildIndex);
        }
    }
}
