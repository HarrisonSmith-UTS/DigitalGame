using UnityEngine;
using System.Collections;

public class RangedAttackController : MonoBehaviour
{
    //Private timing variables
    private bool attacking;
    private bool charging;
    private bool damaging;
    private bool onCooldown;

    private float timer = 0;

    //Attack attributes
    //public float damage;
    public bool destroyObjectOnCollision;
    public bool stopAttackOnCollision;
    //Time that attack will last in seconds

    //Determines the sprites that the top level animator will use for animations
    public float chargeTime;
    public Sprite[] chargeSprites;
    public float damageTime;
    public Sprite[] damageSprites;
    public float cooldownTime;
    public Sprite[] cooldownSprites;

    public GameObject projectile;
    private GameObject spawnedProjectile;

    public bool aimAtPlayer;
    public bool aimAtPlayerWhenCharging;
    private GameObject player;
    private Vector3 aimPosition;

    // Use this for initialization
    void Start()
    {
        //Should select the first Collider2D in the instance
    }

    void OnEnable()
    {
        if (aimAtPlayer)
        {
            player = GameObject.Find("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            if (charging)
            {
                startDamage();
            }
            else if (damaging)
            {
                startCooldown();
            }
            else if (onCooldown)
            {
                endAttack();
            }
        }
    }

    void startAttack()
    {
        //Doesn't start the attack if already attacking.
        if (!attacking)
        {
            attacking = true;
            charging = true;
            timer = chargeTime;
            //Tells upper objects not to attack because already attacking.
            SendMessageUpwards("isAttacking", true);
            if (chargeSprites.Length > 0)
            {
                SendMessageUpwards("startSpecialAnim", chargeSprites);
            }
            if (aimAtPlayerWhenCharging && aimAtPlayer)
            {
                aimPosition = player.transform.position;
            }
        }
    }

    void startDamage()
    {
        charging = false;
        damaging = true;
        timer = damageTime;
        if (damageSprites.Length > 0)
        {
            SendMessageUpwards("startSpecialAnim", damageSprites);
        }
        if (!aimAtPlayerWhenCharging && aimAtPlayer)
        {
            aimPosition = player.transform.position;
        }
        //Creates projectile
        spawnedProjectile = (GameObject)Instantiate(projectile, gameObject.transform.position, Quaternion.identity);
        spawnedProjectile.SetActive(true);
        spawnedProjectile.GetComponent<Projectile>().Launch(aimPosition);
    }

    void startCooldown()
    {
        onCooldown = true;
        damaging = false;
        timer = cooldownTime;
        if (cooldownSprites.Length > 0)
        {
            SendMessageUpwards("startSpecialAnim", cooldownSprites);
        }
        else
        {
            SendMessageUpwards("endSpecialAnim");
        }
    }

    void endAttack()
    {
        onCooldown = false;
        attacking = false;
        SendMessageUpwards("isAttacking", false);
        if (cooldownSprites.Length != 0)
        {
            SendMessageUpwards("endSpecialAnim");
        }
    }
}
