using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class fuelBarManager : MonoBehaviour {

    float maxFuel;

    public Slider fuelBar;

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    //Used to set a maximum value for the fuel bar to use. May set other variables up.
    public void initFuelBar(float maxFuel)
    {
        fuelBar.minValue = 0;
        fuelBar.maxValue = maxFuel;
    }

    //Used to update the current fuel bar status.
    public void updateFuelBar(float currentFuel)
    {
        fuelBar.value = currentFuel;
    }
}
