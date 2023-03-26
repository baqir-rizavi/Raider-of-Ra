using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationTriggerHelper : MonoBehaviour
{
    public void OnEnemyAttack(AnimationEvent animationEvent)
    {
        GetComponentInParent<Enemy>().OnEnemyAttack(animationEvent);
    }
}
