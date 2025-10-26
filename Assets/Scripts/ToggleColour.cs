using UnityEngine;

public class ToggleColour : MonoBehaviour
{
    public GameObject ColourObjectToEnable;
    public GameObject ColourObjectToEnable_1;
    public GameObject ColourObjectToEnable_2;
    public GameObject ColourObjectToEnable_3;
    public GameObject ColourObjectToEnable_4;
    public GameObject ColourObjectToEnable_5;

    public KeyCode activationKey1 = KeyCode.Keypad1;
    public KeyCode activationKey2 = KeyCode.Keypad2;
    public KeyCode activationKey3 = KeyCode.Keypad3;
    public KeyCode activationKey4 = KeyCode.Keypad4;
    public KeyCode activationKey5 = KeyCode.Keypad5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ColourObjectToEnable.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(activationKey1))
        {
            // Enable the target object
            if (ColourObjectToEnable != null)
            {
                ColourObjectToEnable_1.SetActive(false);
                ColourObjectToEnable_2.SetActive(false);
                ColourObjectToEnable_3.SetActive(false);
                ColourObjectToEnable_4.SetActive(false);
                ColourObjectToEnable_5.SetActive(false);

                ColourObjectToEnable.SetActive(true);
            }
        }
        if (Input.GetKeyDown(activationKey2))
        {
            // Enable the target object
            if (ColourObjectToEnable_1 != null)
            {
                ColourObjectToEnable.SetActive(false);
                ColourObjectToEnable_2.SetActive(false);
                ColourObjectToEnable_3.SetActive(false);
                ColourObjectToEnable_4.SetActive(false);
                ColourObjectToEnable_5.SetActive(false);

                ColourObjectToEnable_1.SetActive(true);
            }
        }
        if (Input.GetKeyDown(activationKey3))
        {
            // Enable the target object
            if (ColourObjectToEnable_2 != null)
            {
                ColourObjectToEnable_1.SetActive(false);
                ColourObjectToEnable_3.SetActive(false);
                ColourObjectToEnable_4.SetActive(false);
                ColourObjectToEnable_5.SetActive(false);
                ColourObjectToEnable_2.SetActive(true);
                ColourObjectToEnable.SetActive(false);
            }
        }
        if (Input.GetKeyDown(activationKey4))
        {
            // Enable the target object
            if (ColourObjectToEnable_3 != null)
            {
                ColourObjectToEnable_1.SetActive(false);
                ColourObjectToEnable_3.SetActive(true);
                ColourObjectToEnable_4.SetActive(false);
                ColourObjectToEnable_5.SetActive(false);
                ColourObjectToEnable_2.SetActive(false);
                ColourObjectToEnable.SetActive(false);
            }
        }
        if (Input.GetKeyDown(activationKey5))
        {
            // Enable the target object
            if (ColourObjectToEnable_3 != null)
            {
                ColourObjectToEnable_1.SetActive(false);
                ColourObjectToEnable_3.SetActive(false);
                ColourObjectToEnable_4.SetActive(false);
                ColourObjectToEnable_5.SetActive(false);
                ColourObjectToEnable_2.SetActive(false);
                ColourObjectToEnable.SetActive(false);
            }
        }



    }
}
