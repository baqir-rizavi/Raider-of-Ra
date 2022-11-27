using Cinemachine;
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
    [SerializeField] CinemachineVirtualCamera heliCam;
    Spinner spinner;
    Spinner spinner2;
    ThirdPersonController pp;
    Animator animator;
    CharacterController characterController;
    ThirdPersonShooter thirdPersonShooter;


    bool rightPlayer = false;

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

        heliCam.gameObject.SetActive(true);
        spinner = upperRotor.GetComponent<Spinner>();
        spinner2 = backRotor.GetComponent<Spinner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (p.IsCompleted())
        {
            if (!rightPlayer)
            {
                player.position += player.right * 2f;
                rightPlayer = true;
            }
            if (heliCam)
                heliCam.gameObject.SetActive(false);

            animator.enabled = true;
            characterController.enabled = true;
            pp.SetRotation(true);
            pp.SetMovement(true);
            thirdPersonShooter.enabled = true; 
            player.parent = null;
            SpeedController(spinner);
            SpeedController(spinner2);
            heliCam.gameObject.SetActive(false);
            if (spinner.GetSpeed() < 0.2f && spinner2.GetSpeed() < 0.2f)
            {
                Destroy(this);
            }
        }
        if (Time.time > 63f)
            p.DecreaseSpeed();
    }

    void SpeedController(Spinner s)
    {
        s.SetSpeed(Mathf.Lerp(s.GetSpeed(), 0f, Time.deltaTime * 0.5f));
    }
}
