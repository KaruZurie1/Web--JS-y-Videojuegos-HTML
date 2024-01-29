using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{

    public static Player Instance;


    [SerializeField] private float speed;
    [SerializeField] private GameObject bulletPrefab;


    private PlayerInputActions playerInputAction;
    private Rigidbody2D rb;
    private float fireRate;
    private bool canShoot;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        playerInputAction = new PlayerInputActions();
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        playerInputAction.Enable();
        playerInputAction.Standard.Shooting.performed += Shoot;

        canShoot = true;
    }

    private void FixedUpdate()
    {
        Move();
    }

    // Update is called once per frame
    private void Move()
    {
        Debug.Log(playerInputAction.Standard.Movement.ReadValue<Vector2>());

        Vector3 direction = new Vector3(playerInputAction.Standard.Movement.ReadValue<Vector2>().x, playerInputAction.Standard.Movement.ReadValue<Vector2>().y, 0).normalized;
        rb.AddForce(direction * speed);
    }

    private void Shoot(InputAction.CallbackContext context)
    {
        if (canShoot)
        {
            string buttonName = context.control.name;

            switch (buttonName)
            {
                case "upArrow":
                    Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, 90));
                    break;

                case "downArrow":
                    Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, 90));
                    break;

                case "leftArrow":
                    Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, 90));
                    break;

                case "rightArrow":
                    Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, 90));
                    break;
            }
        }
    }
