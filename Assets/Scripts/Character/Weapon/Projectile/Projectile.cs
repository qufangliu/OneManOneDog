using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int needMood;
    public LayerMask collisionMask;
    public float speed = 10f;
    public float damage = 1;

    public float lifetime = 3;
    float skinWidth = .1f;

    private void Start()
    {
        Destroy(gameObject, lifetime);

        Collider[] initialCollistions = Physics.OverlapSphere(transform.position,GetComponent<SphereCollider>().radius,collisionMask);
        if (initialCollistions.Length > 0)
        {
            OnHitObject(initialCollistions[0],transform.position);
        }
    }

    public void setSpeed(float _speed)
    {
        speed = _speed;
    }
	
	// Update is called once per frame
	void Update () {
        float moveDistace = Time.deltaTime * speed;
        CheckCollisions(moveDistace);
        transform.Translate(Vector3.forward * moveDistace);
	}

    void CheckCollisions(float moveDistance)
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, moveDistance + skinWidth))
        {
           if(hit.collider.name == "Obstacle" || hit.collider.name == "Obstacle(Clone)") Destroy(gameObject);
        }
        if (Physics.Raycast(ray,out hit, moveDistance+skinWidth, collisionMask, QueryTriggerInteraction.Collide))
        {
            OnHitObject(hit.collider,hit.point);
        }
    }
    
    void OnHitObject(Collider colliders,Vector3 hitPoint)
    {
        IDamageable damageableObject = colliders.GetComponent<IDamageable>();
        if (damageableObject != null)
        {
            damageableObject.TakeHit(damage,hitPoint,transform.forward);
        }
        Destroy(gameObject);
    }
}
