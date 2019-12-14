using UnityEngine;

public class Projectile : MonoBehaviour
{
    public LayerMask collisionMask;
    public float damageMax = 1;
    public float damageMin = 1;

    public float lifetime = 3;
    public int needMood;
    private readonly float skinWidth = .1f;
    public float speed = 10f;

    private void Start()
    {
        Destroy(gameObject, lifetime);

        var initialCollistions =
            Physics.OverlapSphere(transform.position, GetComponent<SphereCollider>().radius, collisionMask);
        if (initialCollistions.Length > 0) OnHitObject(initialCollistions[0], transform.position);
    }

    public void setSpeed(float _speed)
    {
        speed = _speed;
    }

    // Update is called once per frame
    private void Update()
    {
        var moveDistace = Time.deltaTime * speed;
        CheckCollisions(moveDistace);
        transform.Translate(Vector3.forward * moveDistace);
    }

    private void CheckCollisions(float moveDistance)
    {
        var ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, moveDistance + skinWidth))
            if (hit.collider.name == "Obstacle" || hit.collider.name == "Obstacle(Clone)")
                Destroy(gameObject);
        if (Physics.Raycast(ray, out hit, moveDistance + skinWidth, collisionMask, QueryTriggerInteraction.Collide))
            OnHitObject(hit.collider, hit.point);
    }

    private void OnHitObject(Collider colliders, Vector3 hitPoint)
    {
        var damageableObject = colliders.GetComponent<IDamageable>();
        if (damageableObject != null)
            damageableObject.TakeHit(Random.Range(damageMin, damageMax), hitPoint, transform.forward);
        Destroy(gameObject);
    }
}