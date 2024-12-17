using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    public Light flickeringLight;    // Reference to the light component
    public float minIntensity = 0.5f; // Minimum light intensity
    public float maxIntensity = 1.5f; // Maximum light intensity
    public float flickerSpeed = 0.1f; // Speed of the flickering effect
    public bool isFlickering = true;  // Control flickering on/off

    private float targetIntensity;    // Target intensity for the light

    private void Start()
    {
        // Initialize the light component if not already set
        if (flickeringLight == null)
        {
            flickeringLight = GetComponent<Light>();
        }

        // Set the initial target intensity
        targetIntensity = flickeringLight.intensity;
    }

    private void Update()
    {
        // If flickering is enabled, modify the light's intensity
        if (isFlickering)
        {
            FlickerEffect();
        }
    }

    private void FlickerEffect()
    {
        // Gradually change the light intensity within the min and max range
        targetIntensity = Random.Range(minIntensity, maxIntensity);
        flickeringLight.intensity = Mathf.Lerp(flickeringLight.intensity, targetIntensity, flickerSpeed * Time.deltaTime);
    }
}
