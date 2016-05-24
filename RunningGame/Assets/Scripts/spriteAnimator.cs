using UnityEngine;
using System.Collections;

public class spriteAnimator : MonoBehaviour
{

    public Sprite[] runSprites;
    public Sprite[] attackSprites;
    public float framesPerSecond;
    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //attacking?
        if (/*player is doing something like attacking or whatever*/)
        {

        }
        else
        //Running
        {
            int index = (int)(Time.timeSinceLevelLoad * framesPerSecond);
            index = index % runSprites.Length;
            spriteRenderer.sprite = runSprites[index];
        }
    }
}
