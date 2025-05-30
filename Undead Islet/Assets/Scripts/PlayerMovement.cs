using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    bool isGrounded;

    Vector2 turn;
    public GameObject sword;
    Animator anim;
    public ParticleSystem slashEffect;

    public AudioSource sfx;
    public AudioClip slashSound;

    public LayerMask enemyLayer;
    public Transform damagePoint;
    public float attackRadius;
    private void Start()
    {
        anim = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void Update()
    {
        Movement();
        Rotate();
        if(Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("attack");
        }

        bool enemyHit = Physics.CheckSphere(transform.position, 1f, enemyLayer);

        if(enemyHit)
        {
            SceneManager.LoadScene("Lose");
        }
        
    }

    public void PlaySlashEffect()
    {
        slashEffect.Play();
        sfx.PlayOneShot(slashSound);
    }

    void Movement()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(-2f * jumpHeight * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void Rotate()
    {
        turn.x += Input.GetAxis("Mouse X");
        turn.y += Input.GetAxis("Mouse Y");
        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
    }

    public void Damage()
    {
        Collider[] hit = Physics.OverlapSphere(damagePoint.position, attackRadius, enemyLayer);
        if (hit.Length > 0)
        {
            foreach (Collider col in hit)
            {
                Destroy(col.gameObject);
            }
        }
    }
}