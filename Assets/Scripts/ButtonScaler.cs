using UnityEngine;

public class ButtonScaler : MonoBehaviour
{
    public float scaleFactor = 1.2f; // Change the scale factor as desired
    public float scaleSpeed = 5f; // Change the speed of scaling as desired

    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void OnMouseEnter()
    {
        Vector3 targetScale = originalScale * scaleFactor;
        StartCoroutine(ScaleOverTime(targetScale));
    }

    void OnMouseExit()
    {
        StartCoroutine(ScaleOverTime(originalScale));
    }

    System.Collections.IEnumerator ScaleOverTime(Vector3 targetScale)
    {
        while (transform.localScale != targetScale)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * scaleSpeed);
            yield return null;
        }
    }
}
