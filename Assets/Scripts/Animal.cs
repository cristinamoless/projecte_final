using UnityEngine;
using TMPro;

public class Animal : MonoBehaviour, IInteractable
{
    public TMP_Text Millor_text;
    public TMP_Text Pitjor_text;
    public int contadorAccio = 1;

    public float speed = 1f;
    private float baseSpeed = 1f;
    public float rotationSpeed = 6f;
    public float stopDistance = 2f;
    private Vector3 direction;
    private Vector3 velocity;
    private bool _isGrounded;

    private Transform player;
    private CharacterController controller;
    public Animator animator;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        controller = GetComponent<CharacterController>();
    }
    public void Interact()
    {
        buidaText();
        if (contadorAccio == 1)
        {
            Millor_text.text = "Prem 1 per fer-te amic dels animals";
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                WorldManager.Instance.BetterWorld();
                direction = player.position - transform.position;
                contadorAccio++;
            }
            Pitjor_text.text = "Prem 2 per espantar els animals";
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                WorldManager.Instance.WorseWorld();
                direction = transform.position - player.position;
                contadorAccio--;
            }
        }
        if (contadorAccio == 0)
        {
            Millor_text.text = "Prem 1 per fer-te amic dels animals";
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                WorldManager.Instance.BetterWorld();
                WorldManager.Instance.BetterWorld();
                contadorAccio = 2;
            }
            Pitjor_text.text = "Prem 2 per deixar tranquils als animals";
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                WorldManager.Instance.BetterWorld();
                animator.SetFloat("speed", 0f);
                contadorAccio++;
            }
        }
        if (contadorAccio == 2)
        {
            Millor_text.text = "Prem 2 per deixar tranquils als animals";
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                WorldManager.Instance.WorseWorld();
                animator.SetFloat("speed", 0f);
                contadorAccio--;
            }
            Pitjor_text.text = "Prem 3 per espantar els animals";
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                WorldManager.Instance.WorseWorld();
                WorldManager.Instance.WorseWorld();
                contadorAccio = 0;
            }
        }
    }
    public void fiInteract()
    {
        buidaText();
    }
    private void buidaText()
    {
        Millor_text.text = "";
        Pitjor_text.text = "";
    }

    private void OnEnable()
    {
        WorldManager.OnBetterWorld += OnBetterWorld;
        WorldManager.OnWorseWorld += OnWorseWorld;
    }

    private void OnDisable()
    {
        WorldManager.OnBetterWorld -= OnBetterWorld;
        WorldManager.OnWorseWorld -= OnWorseWorld;
    }

    private void Update()
    {
        if (player == null) return;

        _isGrounded = controller.isGrounded;

        if (contadorAccio == 2)
        {
            direction = player.position - transform.position;

            if (direction.magnitude < stopDistance)
            {
                animator.SetFloat("speed", 0f);
                velocity.y = 0f;
                return;
            }
        }
        else if (contadorAccio == 0)
        {
            direction = transform.position - player.position;
        }
        else
        {
            animator.SetFloat("speed", 0f);
            velocity.y = 0f;
            return;
        }

        direction.y = 0;
        direction.Normalize();

        Vector3 move = direction * speed;
        if (_isGrounded && velocity.y < 0f)
        {
            velocity.y = -2f;
        }
        velocity.y += -15f * Time.deltaTime; // gravetat
        move.y = velocity.y;

        controller.Move(move * Time.deltaTime);

        // Rotació suau
        if (direction != Vector3.zero)
        {
            Quaternion targetRot = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotationSpeed * Time.deltaTime);
        }

        animator.SetFloat("speed", speed);
    }


    private void OnBetterWorld(WorldManager wm)
    {
        speed = baseSpeed * wm.WorldState;
    }

    private void OnWorseWorld(WorldManager wm)
    {
        speed = baseSpeed * (2f - wm.WorldState);
    }
}
