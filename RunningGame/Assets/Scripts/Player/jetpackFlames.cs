using UnityEngine;
using System.Collections;

public class jetpackFlames : MonoBehaviour {

    public ParticleSystem fire;
    public ParticleSystem smoke;

	// Use this for initialization
	void Start()
    {
        fire = gameObject.GetComponent<ParticleSystem>();
        //will not get the correct one
        //Should now get the correct one?
        smoke = GameObject.Find("PlayerSmoke").GetComponent<ParticleSystem>();
        fire = GameObject.Find("PlayerFlames").GetComponent<ParticleSystem>();

        //Change Foreground to the layer you want it to display on 
        //You could prob. make a public variable for this
        //fire.GetComponent<Renderer>().sortingLayerName = "Foreground";
        //smoke.GetComponent<Renderer>().sortingLayerName = "Foreground";
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void enableFire()
    {
        /*
        fire.Play(true);
        smoke.Play(true);
        */

        
        fire.enableEmission = true;
        smoke.enableEmission = true;
        
    }

    public void stopFire()
    {
        /*
        fire.Play(false);
        fire.Play(false);
        */
        
        fire.enableEmission = false;
        smoke.enableEmission = false;
        
    }
}
