using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    int score = 0;
    int total_collectibles;
    float horizontal;
    float vertical;
    float speed = 5f;

    Rigidbody rb;
    Vector3 movement;
    public TMP_Text scoreText;
    AudioSource nam;
    public AudioClip collectSound;
    public Transform cameraTransform;

    public Transform visual;
    public float turn_speed = 10f;

    public GameObject winPanel;
    bool game_won = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        total_collectibles = GameObject.FindGameObjectsWithTag("Collectible").Length;
        nam = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (game_won)
        {
            return;
        }

        horizontal = 0f;
        vertical = 0f;

        if (Keyboard.current.aKey.isPressed)
            horizontal = -1f;

        if (Keyboard.current.dKey.isPressed)
            horizontal = 1f;

        if (Keyboard.current.sKey.isPressed)
            vertical = -1f;

        if (Keyboard.current.wKey.isPressed)
            vertical = 1f;

        Vector3 cameraForward = cameraTransform.forward;
        Vector3 cameraRight = cameraTransform.right;

        cameraForward.y = 0f;
        cameraRight.y = 0f;

        cameraForward.Normalize();
        cameraRight.Normalize();

        movement = cameraForward * vertical + cameraRight * horizontal;
        movement = movement.normalized;

        if(movement != Vector3.zero)
        {

            Quaternion targetRotation = Quaternion.LookRotation(movement);

            visual.rotation = Quaternion.Slerp(visual.rotation, targetRotation, turn_speed * Time.deltaTime);

        }
    }

    void FixedUpdate()
    {

        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            score++;
            scoreText.text="Score: " + score;

            nam.PlayOneShot(collectSound);

            Destroy(other.gameObject);

            if (score == total_collectibles)
            {

                game_won = true;
                movement = Vector3.zero;

                winPanel.SetActive(true);

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

            }

        }

    }

}
