using UnityEngine;

public class PlayerAudio : MonoBehaviour
{

    public AudioSource audioSource;

    [Header("Sound Effects")]
    public AudioClip jumpSFX;
    public AudioClip footstepSFX;
    public AudioClip attackSFX;

    public float stepInterval = 0.3f;

    private float stepTimer;
    private CharacterController2D controller;
    private PlayerMovement movement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController2D>();
        movement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        // FOOTSTEPS — play only when moving and grounded
        bool isMoving = Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.1f;
        bool isGrounded = controller.isGrounded; // We’ll expose this below

        if (isMoving && isGrounded)
        {
            stepTimer -= Time.deltaTime;
            if (stepTimer <= 0f)
            {
                audioSource.PlayOneShot(footstepSFX);
                stepTimer = stepInterval;
            }
        }
        else
        {
            stepTimer = 0f;
        }

        // ATTACK (Left Click)
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.PlayOneShot(attackSFX);
        }
    }

    // This will be called from controller when we jump
    public void PlayJump()
    {
        audioSource.PlayOneShot(jumpSFX);
    }
}
