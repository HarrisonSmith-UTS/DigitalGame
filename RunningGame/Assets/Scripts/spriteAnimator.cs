using UnityEngine;
using System.Collections;

public class spriteAnimator : MonoBehaviour
{
    public Sprite[] runSprites;
    public Sprite[] attackSprites;
    public Sprite[] jumpSprites;
    //Not sure if this is needed yet:
    public Sprite[] jumpAttackSprites;
    public float framesPerSecond;

    private bool animateAttack;

    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        int index = 0;
        //attacking?
        if (animateAttack)
        {
            if (index < attackSprites.Length-1)
            {
                //increment as normal
                index = (int)(Time.timeSinceLevelLoad * framesPerSecond);
                index = index % attackSprites.Length;
                spriteRenderer.sprite = attackSprites[index];
            }
            else
            {
                //stay on the last frame until the attack ends
                spriteRenderer.sprite = attackSprites[attackSprites.Length - 1];
            }
        }
        else
        //Running
        {
            index = (int)(Time.timeSinceLevelLoad * framesPerSecond);
            index = index % runSprites.Length;
            spriteRenderer.sprite = runSprites[index];
        }
    }

    void startAttack()
    {
        //Switches to attack sprites until defined
        animateAttack = true;
    }

    void endAttack()
    {
        animateAttack = false;
    }
}
