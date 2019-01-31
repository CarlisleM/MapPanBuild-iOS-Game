using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet : MonoBehaviour {

    string PetName;
    int eggTimer = 0;
    float elapsed = 0f;
    
	// Update is called once per frame
	void Update () {
        IncreaseEggTimer();
        if (eggTimer == 900)
        {
            Debug.Log("Pet has hatched");
            // Debug.Log("What would you like to name your pet?");
            // User input pet name
            // Hatch the egg
        }
	}

    void IncreaseEggTimer()
    {
        elapsed += Time.deltaTime;

        if (elapsed >= 1f)
        {
            elapsed = elapsed % 1f;
            eggTimer++;
        }        
    }
}
