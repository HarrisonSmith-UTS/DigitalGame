using UnityEngine;
using System.Collections;

public class spriteAnimator : MonoBehaviour
{
    //Should be set to standing or running sprites
    public Sprite[] defaultSprites;

    //Test - to see if this can replace the runSprites
    private Sprite[] sprites;
    private int index;

    //Animation timing
    public float framesPerSecond;
    //Adding own sprite timer (instead of using 'timesincelevelload')
    private float animTimer;


    //private bool animateAttack;
    private bool stopOnLastFrame;
    private bool invulnAnimate;

    private SpriteRenderer spriteRenderer;
    public Sprite[] invulnSprites;

    // Use this for initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        sprites = defaultSprites;
        invulnAnimate = false;
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Loops through sprites array
        /*
        if (stopOnLastFrame)
        //Animates until the last frame is hit, and freezes on that
        {
            if (index < (sprites.Length - 1))
            {
                index = (int)(Time.timeSinceLevelLoad * framesPerSecond);
                index = index % sprites.Length;
                spriteRenderer.sprite = sprites[index];
            }
            else
            {
                spriteRenderer.sprite = sprites[sprites.Length - 1];
            }
        }
        else
        //Normal continuous sprite animation
        {
            index = (int)(Time.timeSinceLevelLoad * framesPerSecond);
            index = index % sprites.Length;
            spriteRenderer.sprite = sprites[index];
        }
        */


        if (stopOnLastFrame)
        //Animates until the last frame is hit, and freezes on that
        {
            if (index < (sprites.Length - 1))
            {
                index = (int)(animTimer * framesPerSecond);
                index = index % sprites.Length;
                spriteRenderer.sprite = sprites[index];
            }
            else
            {
                spriteRenderer.sprite = sprites[sprites.Length - 1];
            }
        }
        else
        //Normal continuous sprite animation
        {
            index = (int)(animTimer * framesPerSecond);
            index = index % sprites.Length;
            spriteRenderer.sprite = sprites[index];
        }
        //Controls timer for animations
        animTimer += Time.deltaTime;
        
        //Meant to flash the sprite on and off like old platforming games
        /*
        if (invulnAnimate)
        {
            spriteRenderer.enabled = !enabled;
        }
        */
    }

    void startSpecialAnim(Sprite[] animSprites)
    {
        //Switches to attack sprites until defined
        //animateAttack = true;
        stopOnLastFrame = true;
        this.sprites = animSprites;
        index = 0;
        animTimer = 0;
    }

    void endSpecialAnim()
    {
        //animateAttack = false;
        stopOnLastFrame = false;
        sprites = defaultSprites;
        index = 0;
        animTimer = 0;
    }

    void enableInvulnAnim(bool enabled)
    {
        invulnAnimate = enabled;
        if (enabled == true)
        {
            startSpecialAnim(invulnSprites);
        }
        else
        {
            endSpecialAnim();
        }
    }
}
