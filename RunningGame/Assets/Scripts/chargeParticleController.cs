using UnityEngine;
using System.Collections;

public class chargeParticleController : MonoBehaviour {

    private ParticleSystem particles;

    // Use this for initialization
    void Start ()
    {
        particles = gameObject.GetComponent<ParticleSystem>();
        particles.Stop();
    }

    // Update is called once per frame
    void Update ()
    {
	
	}

    void isCharging()
    {
        //enable particle system
        particles.Play();
    }

    void isDamaging()
    {
        //disables animation
        particles.Stop();
    }
}
