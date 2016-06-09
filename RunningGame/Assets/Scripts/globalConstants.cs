using UnityEngine;
using System.Collections;

public static class globalConstants /*: ScriptableObject*/
{
    //was set to 10, set to 5
    //nerfed to 8 to make game easier
    public static float scrollSpeed = 8;

    //Control global timescale
    public static float globalTimeScale = 0.5f;

    //Increased from 0.85 max fuel and 1 deplete rate
    public static float maxFuel = 1;
    public static float fuelDepleteRate = 0.5f;

    public static float playerHealth = 5;

    //Add scene names as appropriate.
    public static string[] sceneNames = { "sci-fi", "cowboys", "gundam"};
}
