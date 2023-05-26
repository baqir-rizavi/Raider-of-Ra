using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.Animations.Rigging;
using System.Linq;
using Unity.VisualScripting;
using FischlWorks;
using UnityEngine.UI;

public class ThirdPersonShooter : MonoBehaviour
{
    [Header("player")]
    [SerializeField] float health = 50f;
    float curHealth = 50f;
    [Header("UI")]
    [SerializeField] Image healthBar;
    [Header("Aim")]
    [SerializeField] CinemachineVirtualCamera aimCam;
    [SerializeField] float normalSensitivity;
    [SerializeField] float aimSensitivity;
    [SerializeField] GameObject crosshair;
    [SerializeField] LayerMask aimMask = new LayerMask();
    [Header("Gun Parameters")]
    [SerializeField] Transform gun;
    [SerializeField] Transform gunPoint;
    [SerializeField] Transform muzzleFlash;
    [SerializeField] float fireRate = 1.5f;
    [SerializeField] float attackPower = 5f;
    [SerializeField] AudioSource gunAudio;
    [Header("Animation Rigs")]
    [SerializeField] Transform targetObjhead;
    [SerializeField] Transform targetObjchest;
    [SerializeField] Rig headRig;
    [SerializeField] Rig chestRig;
    [Header("Hit Particle")]
    [SerializeField] Transform sandParticle;
    [SerializeField] Transform bullethole;
    [SerializeField] Transform wallParticle;

    StarterAssetsInputs staInputs;
    ThirdPersonController tpController;
    Animator animator;
    Ray ray;
    float nextFire = 0.0f;

    void Awake()
    {
        curHealth = health;
        healthBar.fillAmount = 1;
        staInputs = GetComponent<StarterAssetsInputs>();
        tpController = GetComponent<ThirdPersonController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 target = Vector3.zero;

        if (staInputs.aim) // if player aims
        {
            // setting Aim dependencies, unset in else part
            headRig.weight = 1;
            chestRig.weight = 0.6f;
            tpController.SetRotation(false);
            tpController.SetMovement(false);
            aimCam.gameObject.SetActive(true);
            crosshair.SetActive(true);
            gun.gameObject.SetActive(true);
            tpController.SetSensitivity(aimSensitivity);
            GetComponent<csHomebrewIK>().applyFullWeights = true;
            // activation of aim animation
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 1f, Time.deltaTime * 10f));

            // ray to find target
            ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2f, Screen.height / 2f));
            if (Physics.Raycast(ray, out RaycastHit hit, 500f, aimMask))
            {
                target = hit.point;
                if (staInputs.shoot && Time.time > nextFire) // handling if player shoots and cotrolling the rate
                {
                    nextFire = Time.time + fireRate;
                    HandleShoot(hit);
                }
            }
            target = Vector3.Lerp(targetObjhead.position, target, 60f * Time.deltaTime);
            targetObjhead.position = target;
            targetObjchest.position = target;

            // player rotation to aim
            Vector3 targetOnXZPlane = Vector3.ProjectOnPlane((target - transform.position).normalized, Vector3.up);
            transform.forward = Vector3.Lerp(transform.forward, targetOnXZPlane, Time.deltaTime * 15f);
        }
        else
        {
            tpController.SetRotation(true);
            tpController.SetMovement(true);
            aimCam.gameObject.SetActive(false);
            crosshair.SetActive(false);
            gun.gameObject.SetActive(false);
            tpController.SetSensitivity(normalSensitivity);
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 0f, Time.deltaTime * 10f));
            headRig.weight = 0;
            chestRig.weight = 0;
            GetComponent<csHomebrewIK>().applyFullWeights = false;
        }
    }

    void HandleShoot(RaycastHit hit)
    {
        gunAudio.Play();
        Destroy(Instantiate(muzzleFlash, gunPoint.position, Quaternion.LookRotation(gunPoint.forward)).gameObject, 1f); // gun flash 
  
        if (hit.transform.CompareTag("sand"))
        {
            Instantiate(sandParticle, hit.point, Quaternion.LookRotation(hit.normal));
            // auto destroyed
        }
        if (hit.transform.CompareTag("wall"))
        {
            //Debug.Log("wall");
            var bu = Instantiate(bullethole, hit.point + hit.normal * 0.01f, Quaternion.LookRotation(Vector3.Cross(hit.normal,ray.direction).normalized, hit.normal));
            var b = Instantiate(wallParticle, hit.point + hit.normal * 0.01f, Quaternion.LookRotation(hit.normal));
            Destroy(bu.gameObject, 8f);
            // b auto destroyed
        }
        if (hit.transform.CompareTag("enemy"))
        {
            attack(hit);
            Debug.Log("enemy hit");
        }
        // PUT OTHER TAGGED OBJECTS HERE

    }

    void attack(RaycastHit hit)
    {
        hit.transform.GetComponentInParent<Enemy>().damage(attackPower);
    }

    public static float NormalizeRange(float value, float min, float max)
    {
        return (value - min) / (max - min);
    }

    public void damage(float damage)
    {
        curHealth -= damage;
        healthBar.fillAmount = NormalizeRange(curHealth,0,health);
        if (curHealth <= 0)
            killPlayer();
    }
    void killPlayer() 
    {
        Debug.Log("player died");
        // reload scene
    }
}


