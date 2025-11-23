using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject projectile;
    public float projectileSpeed = 40f;
    public float spawnOffset = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Determine direction based on character’s facing
            float direction = transform.localScale.x > 0 ? 1f : -1f;

            // Spawn point in front of player
            Vector3 spawnPos = transform.position + new Vector3(spawnOffset * direction, 0, 0);
            GameObject proj = Instantiate(projectile, spawnPos, Quaternion.identity);
            proj.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(direction * projectileSpeed, 0f);
        }
    }
}
