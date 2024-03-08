using UnityEngine;

public class backgroundScroller : MonoBehaviour
{
    public float scrollSpeed = 1.0f;
    public float backgroundSize = 10.0f; // Change this value to match your background size

    private Transform[] backgrounds;
    private int currentBackgroundIndex;

    void Start()
    {
        // Get references to all background objects
        backgrounds = new Transform[2];
        backgrounds[0] = transform.GetChild(0);
        backgrounds[1] = transform.GetChild(1);

        // Initialize the background positions
        backgrounds[0].position = new Vector3(0, 0, 0);
        backgrounds[1].position = new Vector3(0, backgroundSize, 0);
        currentBackgroundIndex = 0;
    }

    void Update()
    {
        // Move the backgrounds down
        backgrounds[0].position += Vector3.down * scrollSpeed * Time.deltaTime;
        backgrounds[1].position += Vector3.down * scrollSpeed * Time.deltaTime;

        // Check if any of the backgrounds have moved off-screen
        if (backgrounds[currentBackgroundIndex].position.y < -backgroundSize)
        {
            // Swap the background's position to simulate leapfrogging
            backgrounds[currentBackgroundIndex].position += Vector3.up * 2 * backgroundSize;
            currentBackgroundIndex = (currentBackgroundIndex + 1) % 2;
        }
    }
}
