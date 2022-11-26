using PathCreation.Examples;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningSequence : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] pathFollower p;
    [SerializeField] Transform upperRotor;
    [SerializeField] Transform backRotor;
    Spinner spinner;
    Spinner spinner2;
    ThirdPersonController pp;
    Animator animator;
    CharacterController characterController;
    ThirdPersonShooter thirdPersonShooter;


    // Start is called before the first frame update
    void Start()
    {
        animator = player.GetComponent<Animator>();
        animator.enabled = false;
        characterController = player.GetComponent<CharacterController>();
        characterController.enabled = false;
        thirdPersonShooter = player.GetComponent<ThirdPersonShooter>();
        thirdPersonShooter.enabled = false;

        pp = player.GetComponent<ThirdPersonController>();
        pp.SetRotation(false);
        pp.SetMovement(false);

        spinner = upperRotor.GetComponent<Spinner>();
        spinner2 = backRotor.GetComponent<Spinner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (p.IsCompleted())
        {
            animator.enabled = true;
            characterController.enabled = true;
            pp.SetRotation(true);
            pp.SetMovement(true);
            thirdPersonShooter.enabled = true; 
            player.parent = null;
            SpeedController(spinner);
            SpeedController(spinner2);
            if (spinner.GetSpeed() < 0.2f && spinner2.GetSpeed() < 0.2f)
            {
                Destroy(this);
            }
        }
    }

    void SpeedController(Spinner s)
    {
        s.SetSpeed(Mathf.Lerp(s.GetSpeed(), 0f, Time.deltaTime * 0.5f));
    }
}
