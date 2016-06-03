using UnityEngine;
using System.Collections;

public class jetpackFlames : MonoBehaviour {

    private ParticleSystem fire;
    private ParticleSystem smoke;

	// Use this for initialization
	void Start()
    {
        fire = gameObject.GetComponent<ParticleSystem>();
        //will not get the correct one
        smoke = gameObject.GetComponentInChildren<ParticleSystem>();
        stopFire();
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void enableFire()
    {
        fire.Play();
        smoke.Play();
    }

    public void stopFire()
    {
        fire.Stop();
        smoke.Stop();
    }
}
