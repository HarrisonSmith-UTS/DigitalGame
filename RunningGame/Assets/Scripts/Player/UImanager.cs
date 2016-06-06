using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UImanager : MonoBehaviour {

    private Slider fuelBar;
    private Text healthDisplay;
    private Text scoreDisplay;
    private Text finalScoreDisplay;
    private GameObject gameOverPanel;

	// Use this for initialization
	void Start ()
    {
        fuelBar = GameObject.Find("fuelBar").GetComponent<Slider>();
        healthDisplay = GameObject.Find("HealthDisplay").GetComponent<Text>();
        scoreDisplay = GameObject.Find("scoreDisplay").GetComponent<Text>();
        finalScoreDisplay = GameObject.Find("finalScoreDisplay").GetComponent<Text>();
        gameOverPanel = GameObject.Find("gameOverDisplay");
        //Disable the game over panel for the moment
        gameOverPanel.SetActive(false);
    }

    void Awake()
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
