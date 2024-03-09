using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public float totalTime = 10f; // Total time for the countdown
    private float currentTime; // Current time left
    public GameObject shooterRef;
    public Shooting shooting;
    private Image timerImage; // Reference to the Image component

    public GameObject scatter;
    public GameObject triple;
    public GameObject cone;

    private void Start()
    {
        timerImage = GetComponent<Image>(); // Get the Image component
        currentTime = totalTime; // Initialize current time
    }

    private void Update()
    {        
        shooterRef = GameObject.FindWithTag("Shooter");
        shooting = shooterRef.GetComponent<Shooting>();

        switch (shooting.ShootStyle)
        {
            case 1:
                scatter.SetActive(false);
                triple.SetActive(false);
                cone.SetActive(false);
                break;
            case 2:
                scatter.SetActive(false);
                triple.SetActive(false);
                cone.SetActive(true);
                break;
            case 3:
                scatter.SetActive(false);
                triple.SetActive(true);
                cone.SetActive(false);
                break;
            case 4:
                scatter.SetActive(true);
                triple.SetActive(false);
                cone.SetActive(false);
                break;
           
        }
        currentTime = shooting.PowerTimer;
        // Update the timer
        if (currentTime < 10 ) 
        {
            if (shooting.ShootStyle != 1) {
                currentTime += Time.deltaTime; // Decrement time
                float fillAmount = currentTime / totalTime; // Calculate fill amount
                timerImage.fillAmount = fillAmount; // Update fill amount of the image
            }
            else {
                timerImage.fillAmount = 0f; // Update fill amount of the image
            }
        }
    }
}
