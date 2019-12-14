using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : LivingEntity{

    public enum State {Idle,Chasing,Attacking};
    State currentState;

    public ParticleSystem deathEffect;
    public static event System.Action OnDeathStatic;

    NavMeshAgent pathfinder;
    Transform target;
    Material skinMaterial;
    LivingEntity targetEntity;

    Color originalColour;

    float attackDistanceThreshold = .5f;
    float timeBetweenAttacks = 1;
    float damage = 1;

    float nextAttackTime;
    float myCollisionRadius;
    float targetCollisionRadius;

    bool hasTarget;

    private void Awake()
    {
        pathfinder = GetComponent<NavMeshAgent>();
        //与玩家交互
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            hasTarget = true;
            target = GameObject.FindGameObjectWithTag("Player").transform;
            targetEntity = target.GetComponent<LivingEntity>();
            myCollisionRadius = GetComponent<SphereCollider>().radius;
            targetCollisionRadius = target.GetComponent<BoxCollider>().size.x;
        }
    }

    // Use this for initialization
    protected override void Start () {
        //给emeny自身属性赋值
        base.Start();

        //与玩家交互
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            currentState = State.Chasing;
            targetEntity.OnDeath += OnTargetDeath;

            StartCoroutine(UndatePath());
        }

    }
    
    public void SetCharacteristics(float moveSpeed, int enemyDamage,float enemyHealth,Color skinColour)
    {
        pathfinder.speed = moveSpeed;
        if (hasTarget)
        {
            damage = enemyDamage;//向上取整
        }
        startingHealth = enemyHealth;

        var main = deathEffect.main;
        skinMaterial = GetComponent<MeshRenderer>().material;
        skinMaterial.color = skinColour;
        originalColour = skinMaterial.color;
    }

    public override void TakeHit(float damage, Vector3 hitPoint, Vector3 hitDirection)
    {
        // AudioManager.instance.PlaySound("Impact",transform.position);
        if (damage >= health && !dead)
        {
            if(OnDeathStatic != null)
            {
                OnDeathStatic();
            }
            // AudioManager.instance.PlaySound("Enemy Death",transform.position); 
            // Destroy(Instantiate(deathEffect.gameObject,hitPoint,Quaternion.FromToRotation(Vector3.forward, hitDirection))as GameObject,deathEffect.main.startLifetime.constant);
        }
        base.TakeHit(damage, hitPoint, hitDirection);
    }

    void OnTargetDeath()
    {
        hasTarget = false;
        currentState = State.Idle;
    }

    IEnumerator UndatePath()
    {
        float refreshRate = .2f;

        while (hasTarget)
        {
            if (currentState == State.Chasing)
            {
                Vector3 dirToTarget = (target.position - transform.position).normalized;
                Vector3 targetPosition = target.position;
                if (!dead&&GetComponent<NavMeshAgent>().isActiveAndEnabled)
                {
                    if (pathfinder.enabled == true)
                        pathfinder.SetDestination(targetPosition);
                }
            }
            yield return new WaitForSeconds(refreshRate);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Player"))
        {
            targetEntity.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}