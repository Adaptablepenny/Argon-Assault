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
    [SerializeField] GameObject[] guns;


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
        if (isControlEnabled)//Checks to see if the ship has collided with anything (AKA Died)
        {
            ProcessTranslation();//allows the ship to fly up down left and right
            ProcessRotation();//rotates the ship as necessary
            ProcessFiring();//Shoot guns
        }
    }



    void ProcessRotation()//This whole function calculates the rotation required depending on the position of ship on screen
    {

        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yaw = transform.localPosition.x * positionYawFactor;

        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);

    }


    void ProcessTranslation()//This function just moves the ship based on the calculations of the other functions
    {
        transform.localPosition = new Vector3(ProcessedXInput(), ProcessedYInput(), transform.localPosition.z);
    }


    float ProcessedXInput()//Process how fast and how far the ship will go on the X Axis
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");

        float xOffset = xThrow * ControlSpeed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffset;

        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);//Keeps the ship from going off screen

        return clampedXPos;
    }

    float ProcessedYInput()//Process how fast and how far the ship will go on the Y Axis
    {
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float yOffset = yThrow * ySpeed * Time.deltaTime;

        float rawYPos = transform.localPosition.y + yOffset;

        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);//Keeps the ship from going off screen

        return clampedYPos;
    }

    void ProcessFiring()//Turns the guns on and off by activating and deactiving the gameobject
    {
        if (CrossPlatformInputManager.GetButton("Fire"))
        {
            ActivateGuns();
        }
        else
        {
            DeactivateGuns();
        }
    }

    private void ActivateGuns()// Turn on the gun object
        {
            foreach (GameObject gun in guns)
            {
                gun.SetActive(true);
            }
        }

    private void DeactivateGuns()// Turn off the gun object
    {
        foreach (GameObject gun in guns)
        {
            gun.SetActive(false);
        }
    }    

    void OnPlayerDeath()//Small function for the collider script to call, when the ship collides it disables the controls
    {
        isControlEnabled = false;
    }

    void OnCollisionEnter(Collision col) //This does nothing but debug for collisions
    {
        print("Player Collided With Something");

    }

    void Reload()//Reloads the scene AKA Level
    {
        SceneManager.LoadScene(1);
    }
}
