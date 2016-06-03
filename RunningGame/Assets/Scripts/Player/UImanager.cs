using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UImanager : MonoBehaviour {

    public Slider fuelBar;
    public Text healthDisplay;
    public Text scoreDisplay;
    public Text finalScoreDisplay;
    public GameObject gameOverPanel;

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

    public void updateHealthDisplay(float health)
    {
        healthDisplay.text = Mathf.RoundToInt(health).ToString();
    }

    public void updateScoreDisplay(float score)
    {
        scoreDisplay.text = Mathf.RoundToInt(score).ToString();
        finalScoreDisplay.text = Mathf.RoundToInt(score).ToString();
    }

    //Used to update the current fuel bar status.
    public void updateFuelBar(float currentFuel)
    {
        fuelBar.value = currentFuel;
    }

    public void showGameOverScreen()
    {
        //displays hidden game over elements
        gameOverPanel.SetActive(true);
    }
}
