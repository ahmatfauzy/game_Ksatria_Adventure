using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class layer : MonoBehaviour
{
    [Header("Player Movement")]
    public float moveSpeed = 5f; // Kecepatan bergerak
    private Rigidbody2D rb;
    private float moveInput;

    [Header("Sprite Settings")]
    private SpriteRenderer spriteRenderer; // Komponen untuk mengatur flip sprite

    [Header("Camera Reference")]
    public Transform cameraTransform; // Referensi kamera yang akan mengikuti player

    void Start()
    {
        // Mendapatkan komponen Rigidbody2D dan SpriteRenderer
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Pastikan komponen SpriteRenderer ada
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer tidak ditemukan pada objek ini!");
        }
    }

    void Update()
    {
        // Mendapatkan input horizontal
        moveInput = Input.GetAxis("Horizontal");

        // Flip sprite berdasarkan arah gerakan
        if (moveInput > 0)
        {
            spriteRenderer.flipX = false; // Menghadap kanan
        }
        else if (moveInput < 0)
        {
            spriteRenderer.flipX = true; // Menghadap kiri
        }

        // Jika kamera ada, ikuti posisi player di sumbu X
        if (cameraTransform != null)
        {
            Vector3 newCameraPosition = cameraTransform.position;
            newCameraPosition.x = transform.position.x;
            cameraTransform.position = newCameraPosition;
        }
    }

    void FixedUpdate()
    {
        // Gerakkan player di sumbu X
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }
}
