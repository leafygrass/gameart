using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject projectile;
    public float projectileSpeed = 40f;
    public float spawnOffset = 2f;
    
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogWarning("Shooter: No Animator found on " + gameObject.name);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Trigger wand hold animation
            if (animator != null)
            {
                animator.SetTrigger("Shoot");
            }
            
            // Determine direction based on character's facing
            float direction = transform.localScale.x > 0 ? 1f : -1f;

            // Spawn point in front of player
            Vector3 spawnPos = transform.position + new Vector3(spawnOffset * direction, 0, 0);
            GameObject proj = Instantiate(projectile, spawnPos, Quaternion.identity);
            proj.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(direction * projectileSpeed, 0f);
        }
    }
}
