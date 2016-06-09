using UnityEngine;
using System.Collections;

public class extraLifeController : MonoBehaviour
{
    private ParticleSystem fireworks;
    private GameObject extraLifeText;

    private bool appear;
    public float appearTime;
    private float appearTimer;

	// Use this for initialization
	void Start ()
    {
        fireworks = GameObject.Find("ExtraLifeParticles").GetComponent<ParticleSystem>();
        extraLifeText = GameObject.Find("ExtraLifeText");
        appear = false;
        appearTimer = 0;
        extraLifeText.SetActive(false);
    }

    public void shootFireworks()
    {
        fireworks.Play();
        extraLifeText.SetActive(true);
        appearTimer = appearTime;
        appear = true;
    }


	// Update is called once per frame
	void Update ()
    {
        if (appear)
        {
            appearTimer -= Time.deltaTime;
            if (appearTimer <= 0)
            {
                //disable renderer
                extraLifeText.SetActive(false);
                appear = false;
            }
        }
	}
}
