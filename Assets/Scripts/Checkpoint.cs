using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    [SerializeField]
    private float inactiveRotationSpeed = 100f, activateRotationSpeed = 300f;

    [SerializeField]
    private float inactiveScale = 1f, activeScale = 1.5f;

    [SerializeField]
    private Color inactiveColor, activeColor;

    private bool isActivated = false;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateColor();
    }

    private void Update()
    {
        UpdateRotation();
    }

    private void UpdateColor()
    {
        Color color = inactiveColor;

        if (isActivated)
        {
            color = activeColor;
        }

        spriteRenderer.color = color;
    }

    private void UpdateScale()
    {
        float scale = inactiveScale;
        if (isActivated)
        {
            scale = activeScale;
        }
        transform.localScale = Vector3.one * scale;
    }

    private void UpdateRotation()
    {
        float rotationSpeed = inactiveRotationSpeed;
        if (isActivated)
        {
            rotationSpeed = activateRotationSpeed;
        }
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
    
    public void SetIsActivated(bool value)
    {
        isActivated = value;
        UpdateScale();
        UpdateColor();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player entered checkpoint");
            PlayerController player = collision.GetComponent<PlayerController>();
            player.SetCurrentCheckpoint(this);
        }
    }
}
