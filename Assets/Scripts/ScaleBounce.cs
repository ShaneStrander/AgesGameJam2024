using UnityEngine;

public class ScaleBounce : MonoBehaviour
{
    public float scaleFactor = 0.15f; // Scale factor (15% in this case)
    public float speed = 1.0f; // Speed of scaling

    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        // Calculate the new scale
        float scaleChange = Mathf.Sin(Time.time * speed) * scaleFactor;
        Vector3 newScale = originalScale + originalScale * scaleChange;

        // Apply the new scale
        transform.localScale = newScale;
    }
}
