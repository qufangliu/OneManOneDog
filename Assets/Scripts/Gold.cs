using UnityEngine;

public class Gold : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag.Contains("Player"))
        {
            ContextHelper.gold++;
            Destroy(gameObject);
        }
    }
}