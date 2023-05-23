using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyController : MonoBehaviour
{
    [SerializeField]
    [Range(1f, 20f)]
    float lookRadius = 1f;

    [SerializeField]
    NavMeshAgent agent;

    [SerializeField]
    Transform target;

    [SerializeField]
    AudioSource audio;

    Animator anim;
    static int animationBlendSpeed = Animator.StringToHash("speed");
    static int animationAttack = Animator.StringToHash("attack");

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        if (target == null)
            target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float speedanim = agent.velocity.magnitude / (float)agent.speed;
        anim.SetFloat(animationBlendSpeed, speedanim, 0.1f, Time.deltaTime);

        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius) // hamla!!!
        {
            if (!audio.isPlaying)
                audio.Play();
            agent.SetDestination(target.position);
            if (distance <= agent.stoppingDistance)
            {
                anim.SetInteger(animationAttack, 1);
            }
            else
            {
                anim.SetInteger(animationAttack, 0);
            }
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
