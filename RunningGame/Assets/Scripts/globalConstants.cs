using UnityEngine;
using System.Collections;

public static class globalConstants /*: ScriptableObject*/
{
    //was set to 10, set to 5
    //nerfed to 8 to make game easier (f***ing casuals)
    public static float scrollSpeed = 8;

    public static float maxFuel = 1;
    public static float fuelDepleteRate = 0.5f;

    //Add scene names as appropriate.
    public static string[] sceneNames = { "sci-fi", "cowboys", "gundam"};
}
