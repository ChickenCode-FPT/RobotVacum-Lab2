using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementController : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    private Vector2 movementInput; 
    public TMP_Text coinsText;
    public GameObject winText;
    private int coinsCollected = 0;
    
    void Awake()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
        UpdateCoinText();
    }
    void FixedUpdate()
    {
        rb.velocity = movementInput * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Debug.Log("Thu thập Coin!");
            coinsCollected++;
            if (coinsCollected == 11)
            {
                winText.SetActive(true);
                Time.timeScale = 0f;
            }
            UpdateCoinText();
            Destroy(other.gameObject);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }
    
    void UpdateCoinText()
    {
        if (coinsText != null) 
        {
            coinsText.text = "Coins: " + coinsCollected.ToString()+ "/ 11";
        }
        else
        {
            Debug.LogWarning("Coin Text (TMP_Text) chưa được gán trong Inspector!");
        }
    }
}
