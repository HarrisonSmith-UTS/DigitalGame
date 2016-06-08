using UnityEngine;
using System.Collections;

public class damageParticleController : MonoBehaviour {

    private ParticleSystem particles;

    // Use this for initialization
    void Start()
    {
        particles = gameObject.GetComponent<ParticleSystem>();
        particles.Pause();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void isDamaging()
    {
        //starts animation
        particles.Play();
    }

    void isCooldown()
    {
        //ends animation
        particles.Stop();
    }
}
