using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : LivingEntity
{
    public enum State
    {
        Idle,
        Chasing,
        Attacking
    }

    private float attackDistanceThreshold = .5f;
    private State currentState;
    public float damage = 1;

    public ParticleSystem deathEffect;
    public Gold gold;
    public int goldNumber;

    private bool hasTarget;
    public int moodDamageMax = 1;
    public int moodDamageMin = 1;

    private float nextAttackTime;

    private NavMeshAgent pathfinder;
    private Material skinMaterial;
    private Transform target;
    private LivingEntity targetEntity;
    private float timeBetweenAttacks = 1;
    public static event Action OnDeathStatic;

    private void Awake()
    {
        pathfinder = GetComponent<NavMeshAgent>();
        //与玩家交互
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            hasTarget = true;
            target = GameObject.FindGameObjectWithTag("Player").transform;
            targetEntity = target.GetComponent<LivingEntity>();
        }
    }

    // Use this for initialization
    protected override void Start()
    {
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

    public void SetCharacteristics(float moveSpeed, int enemyDamage, float enemyHealth, Color skinColour)
    {
        pathfinder.speed = moveSpeed;
        if (hasTarget) damage = enemyDamage; //向上取整
        startingHealth = enemyHealth;

        var main = deathEffect.main;
        skinMaterial = GetComponent<MeshRenderer>().material;
        skinMaterial.color = skinColour;
    }

    public override void TakeHit(float damage, Vector3 hitPoint, Vector3 hitDirection)
    {
        // AudioManager.instance.PlaySound("Impact",transform.position);
        if (damage >= health && !dead)
        {
            if (OnDeathStatic != null)
                OnDeathStatic();
            Instantiate(gold, transform.position,Quaternion.Euler(new Vector3(90,0,0)));
        }
            
        // AudioManager.instance.PlaySound("Enemy Death",transform.position); 
        // Destroy(Instantiate(deathEffect.gameObject,hitPoint,Quaternion.FromToRotation(Vector3.forward, hitDirection))as GameObject,deathEffect.main.startLifetime.constant);
        base.TakeHit(damage, hitPoint, hitDirection);
    }

    private void OnTargetDeath()
    {
        hasTarget = false;
        currentState = State.Idle;
    }

    private IEnumerator UndatePath()
    {
        var refreshRate = .2f;

        while (hasTarget)
        {
            if (currentState == State.Chasing)
            {
                var targetPosition = target.position;
                if (!dead && GetComponent<NavMeshAgent>().isActiveAndEnabled)
                    if (pathfinder.enabled)
                        pathfinder.SetDestination(targetPosition);
            }

            yield return new WaitForSeconds(refreshRate);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Player"))
        {
            targetEntity.TakeDamage(damage);
            ContextHelper.playerMood -= Random.Range(moodDamageMin, moodDamageMax);
            Destroy(gameObject);
        }
    }
}