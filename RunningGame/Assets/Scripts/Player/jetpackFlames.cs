using UnityEngine;
using System.Collections;

public class jetpackFlames : MonoBehaviour {

    private ParticleSystem fire;
    private ParticleSystem smoke;
    private GameObject smokeObject;

	// Use this for initialization
	void Start()
    {
        fire = gameObject.GetComponent<ParticleSystem>();
        //will not get the correct one
        //Should now get the correct one?
        smoke = GameObject.Find("PlayerSmoke").GetComponent<ParticleSystem>();

            //Change Foreground to the layer you want it to display on 
            //You could prob. make a public variable for this
        fire.GetComponent<Renderer>().sortingLayerName = "Foreground";
        smoke.GetComponent<Renderer>().sortingLayerName = "Foreground";
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void enableFire()
    {
        fire.Play(true);
        smoke.Play(true);
    }

    public void stopFire()
    {
        fire.Stop();
        smoke.Stop();
    }
}
