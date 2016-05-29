using UnityEngine;
using System.Collections;

public class spriteAnimator : MonoBehaviour
{
    //Should be set to standing or running sprites
    public Sprite[] defaultSprites;

    //Test - to see if this can replace the runSprites
    private Sprite[] sprites;

    public float framesPerSecond;

    //private bool animateAttack;
    private bool stopOnLastFrame;

    private SpriteRenderer spriteRenderer;


    // Use this for initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        sprites = defaultSprites;
    }

    // Update is called once per frame
    void Update()
    {
        //Loops through sprites array
        int index = 0;
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
        
        
    }

    void startSpecialAnim(Sprite[] animSprites)
    {
        //Switches to attack sprites until defined
        //animateAttack = true;
        stopOnLastFrame = true;
        this.sprites = animSprites;
    }

    void endSpecialAnim()
    {
        //animateAttack = false;
        stopOnLastFrame = false;
        sprites = defaultSprites;
    }
}
