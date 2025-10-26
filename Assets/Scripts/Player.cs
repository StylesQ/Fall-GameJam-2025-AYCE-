using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player instance { get; private set; }
    public float strokeMeter = 0;
    public float strokeMax = 30;
    public Slider slider;
    public GameObject deathscreen;
    public PlayerMovement movement;
    public Volume volume;
    public AudioSource source;

    void Awake(){
        if (instance == null) { instance = this; }
        else if (instance != this) { Destroy(this); }
        slider.maxValue = strokeMax;
    }

    void Update()
    {
        volume.weight = (strokeMeter / strokeMax);
        slider.value = strokeMeter;
        strokeMeter += Time.deltaTime;

        if(strokeMeter >= strokeMax && !deathscreen.activeInHierarchy)
        {
            deathscreen.SetActive(true);
            movement.enabled = false;
            source.Play();

        }
    }

    void ReplenishStroke()
    {
        strokeMeter -= 10;
        if (strokeMeter < 0) { strokeMeter = 0; }
    }
    
    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Candy")
        {
            ReplenishStroke();
            Destroy(col.gameObject);
        }
    }
}
