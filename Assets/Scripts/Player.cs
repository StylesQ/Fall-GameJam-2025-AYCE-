using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance { get; private set; }

    void Awake(){
        if(instance == null){ instance = this; }
        else if( instance != this){ Destroy(this); }
    }

    void Update()
    {
        
    }
}
