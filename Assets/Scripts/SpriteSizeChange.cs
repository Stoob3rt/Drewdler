using UnityEngine;

public class SpriteSizeChange : MonoBehaviour
{
    public float scaleFactor = 1.2f;  // Factor by which to scale the sprite on hover
    private Vector3 originalScale;     // Original scale of the sprite

    private void Start()
    {
        originalScale = transform.localScale;
    }

    private void OnMouseEnter()
    {
        // Scale up the sprite on hover
        transform.localScale = originalScale * scaleFactor;
    }

    private void OnMouseExit()
    {
        // Reset the scale to its original size when mouse exits
        transform.localScale = originalScale;
    }
}