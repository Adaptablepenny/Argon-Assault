using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour

{
    
    [Header("General")]
    [SerializeField] float ControlSpeed = 60f;
    [SerializeField] float ySpeed = 60f;
    [SerializeField] float yRange = 35f;
    [SerializeField] float xRange = 24f;


    [Header("Screen-position based")]
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -5f;


    float xThrow = 0f;
    float yThrow = 0f;
    [Header("Control-throw based")]
    [SerializeField] float positionYawFactor;
    [SerializeField] float controlRollFactor;
    [SerializeField] bool isControlEnabled = true;

   
    void Start()
    {

    }
    void Update()
    {
        if (isControlEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
        }
    }



    void ProcessRotation()
    {

        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yaw = transform.localPosition.x * positionYawFactor;

        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);

    }


    void ProcessTranslation()
    {
        transform.localPosition = new Vector3(ProcessedXInput(), ProcessedYInput(), transform.localPosition.z);
    }


    float ProcessedXInput()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");

        float xOffset = xThrow * ControlSpeed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffset;

        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        return clampedXPos;
    }

    float ProcessedYInput()
    {
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float yOffset = yThrow * ySpeed * Time.deltaTime;

        float rawYPos = transform.localPosition.y + yOffset;

        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        return clampedYPos;
    }

    void OnPlayerDeath()
    {
        isControlEnabled = false;
    }



    void OnCollisionEnter(Collision col)
    {
        print("Player Collided With Something");

    }





    void Reload()
    {
        SceneManager.LoadScene(1);
    }
}
