using UnityEngine;

public class ButtonAnimation : MonoBehaviour
{
    public SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer component
    public Vector3 highlightedScale = new Vector3(1.2f, 1.2f, 1f); // Scale to apply when highlighted

    private Vector3 originalScale; // Original scale of the sprite

    private void Awake()
    {
        originalScale = transform.localScale; // Store the original scale
    }

    public void SetHighlighted(bool highlighted)
    {
        if (highlighted)
        {
            transform.localScale = highlightedScale; // Apply highlighted scale
        }
        else
        {
            transform.localScale = originalScale; // Reset to original scale
        }
    }
}
