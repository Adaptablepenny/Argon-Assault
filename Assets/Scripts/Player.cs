using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour

{
    [SerializeField] float xSpeed = 60f;
    [SerializeField] float ySpeed = 60f;

    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -5f;

    [SerializeField] float yRange;
    [SerializeField] float xRange;
    float xThrow = 0f;
    float yThrow = 0f;
    [SerializeField] float positionYawFactor;
    [SerializeField] float controlRollFactor;

    void Start()
    {
        
    }
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        

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

        float xOffset = xThrow * xSpeed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffset;

        xRange = 35f;

        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        return clampedXPos;
    }

    float ProcessedYInput()
    {
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float yOffset = yThrow * ySpeed * Time.deltaTime;

        float rawYPos = transform.localPosition.y + yOffset;

        yRange = 22f;

        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);
        return clampedYPos;
    }

  

    /*void OnCollisionEnter(Collision col)
    {
        switch (col.gameObject.tag)
        {
            case "Terrain":
                Reload();
                break;
            default:
                break;
        }
        
    }*/



    void Reload()
    {
        SceneManager.LoadScene(1);
    }
}
