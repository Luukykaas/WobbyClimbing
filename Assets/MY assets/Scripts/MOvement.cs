using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UIElements;
using Unity.VisualScripting;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.Animations;

public enum Level
{
    PLAYER, BIOME1, BIOME2, CAVE, BOSS1, BOSS1CLIMB
}

public class MOvment : MonoBehaviour
{
    public Level level = Level.CAVE;
    public float speed = 7.0f;
    public Vector3 start; 
    public Vector3 aim; 
    public float launchForce = 0.1f;
    public float jumpForce = 5.0f;
    public bool isOnGround = false;
    public bool isOnBGround = false;
    public bool isHolding = false;
    public bool isInAir = false;
    public bool isTouchingWall = false;
    public bool falling = false;
    public float horizontalInput;
    public float forwardInput;
    private Rigidbody playerRb;
    public TextMeshProUGUI hpText;
    [SerializeField] GameObject Wall;
    [SerializeField] GameObject ShopPanel;
    [SerializeField] GameObject Menu;
    [SerializeField] GameObject Cave;
    [SerializeField] GameObject CaveEntrance;
    [SerializeField] GameObject Biome2;
    [SerializeField] GameObject Biome1;
    [SerializeField] GameObject Boss1;
    [SerializeField] GameObject Boss1Climb;
    [SerializeField] GameObject Audio;
    public float jumpBoost = 1.0f;
    public bool disabled = false;
    public float velocityY = 0.0f;
    public float maxVy = 0.0f;
    public int hp = 100;
    public double hpP = 100;
    public bool punching = false;
    KillRock killRock;
    public bool key = false;
    GobAI gobAI;
    public float rockYV;
    private double wait;
    Animator anim;
    AudioSource AudioScript;
    Dialoge dialoge;

    public void AudioPlay()
    {

    }
    void SetLevel(Level l)
    {
        level = l;

        switch (level)
        {
            case Level.PLAYER:
                break;

            case Level.BIOME1:
                gameObject.transform.position = Biome1.transform.position;
                break;

            case Level.BIOME2:
                gameObject.transform.position = Biome2.transform.position;
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                anim.SetBool("Walking", false);
                break;

            case Level.CAVE:
                gameObject.transform.position = Cave.transform.position;
                break;

            case Level.BOSS1:
                gameObject.transform.position = Boss1.transform.position;
                break;

            case Level.BOSS1CLIMB:
                gameObject.transform.position = Boss1Climb.transform.position;
                break;

            default: gameObject.transform.position = Biome1.transform.position; break;
        }
    }
    void Start()
    {
        playerRb = gameObject.GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        SetLevel(level);
        AudioScript = Audio.GetComponent<AudioSource>();
        dialoge = LevelManager.instance.gameObject.GetComponent<Dialoge>();
    }

    void Update()
    {
        if (level == Level.CAVE || isOnBGround && !ShopPanel.activeSelf)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            forwardInput = Input.GetAxis("Vertical");
            if (Math.Abs(horizontalInput) > 0 || Math.Abs(forwardInput) > 0)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
                transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
                anim.SetBool("Walking", true);
            }
            else anim.SetBool("Walking", false);

            if (Input.GetKey(KeyCode.Mouse0))
            {
                anim.SetBool("Punch", true);
                punching = true;
            }
            else
            {
                anim.SetBool("Punch", false);
                punching = false;
            }
        }

        hpText.text = "HP: " + Math.Round(hpP).ToString();
        if (hpP <= 0)
        {
            hpP = 0;
            PlayerDied();
            Debug.Log("Death");
        }

        if (Input.GetKeyDown(KeyCode.Escape) )
        {
            Menu.SetActive(!Menu.activeSelf);
            if (Time.timeScale == 1) Time.timeScale = 0;
            else if (Time.timeScale == 0) Time.timeScale = 1;
        }

        if (Input.GetKeyDown(KeyCode.V))
        {

        }

        

        if (level != Level.CAVE)
        {
            //if (!ShopPanel.activeSelf)
            if (isTouchingWall)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                Vector3 mousePos = Input.mousePosition;
                if (Input.GetKey(KeyCode.Mouse0) && !falling)
                {
                    if (!isHolding)
                    {
                        start = mousePos;

                        isHolding = true;
                        Debug.Log("Start");
                        Debug.Log(mousePos.x);
                        Debug.Log(mousePos.y);
                    }
                    else
                    {
                        aim = start - mousePos;
                        aim.y = Math.Clamp(aim.y, 0, 180);
                        aim.x = Math.Clamp(aim.x, -75, 75);
                    }
                    if (isInAir && isHolding)
                    {
                        isInAir = false;
                        playerRb.useGravity = false;
                        playerRb.velocity = Vector3.zero;
                    }
                    else
                    {
                        //playerRb.useGravity = true;
                    }

                }
                else
                {
                    if (isHolding)
                    {
                        isHolding = false;
                        isInAir = true;
                        isOnGround = false;
                        //transform.Translate(aim * launchForce);
                        playerRb.AddForce(aim * launchForce, ForceMode.Impulse);
                        playerRb.useGravity = true;
                        anim.SetBool("Climbing", true);
                        Debug.Log("Aim");
                        Debug.Log(aim.x);
                        Debug.Log(aim.y);
                    }
                }



            }
        }
        velocityY = playerRb.velocity.y;
        if (velocityY < 0)
        {
            falling = true;
            anim.SetBool("Falling", true);
            if (velocityY < -5 && !AudioScript.isPlaying)
            {
                AudioScript.clip = AudioSources.instance.AAA;
                AudioScript.Play();
            }
        }
        else
        {
            falling = false;
            anim.SetBool("Falling", false);
            if (AudioScript.clip = AudioSources.instance.AAA) AudioScript.Stop();
            if (maxVy < -5) AudioScript.Play();
        }
        
        if (velocityY < maxVy) maxVy = velocityY;
    }
    public void PlayerDied()
    {
        LevelManager.instance.GameOver();
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            isTouchingWall = true;
        }
        /*
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("BottomGround"))
        {
            isOnGround = true;
            isInAir = false;
            
            hp = (int)Math.Round(hpP);
            hpP = hp;
            if (hp < 0)
            {
                hp = 0;
                anim.SetBool("Death", true);
            }
            

            if (maxVy < -10)
            {
                AudioScript.clip = AudioSources.instance.Oof;
                AudioScript.Play();
                if (!OreDection.instance.boots) hpP += maxVy * 2;
                else
                {
                    if (maxVy * 2 < 70)
                    {
                        hpP += maxVy;
                    }
                    else hpP += maxVy * 2;
                }
            }
            if (hpP <= 0)
            {
                hpP = 0;
                hp = 0;
                anim.SetBool("Death", true);
                AudioScript.clip = AudioSources.instance.Death;
                AudioScript.Play();
                PlayerDied();
            }
            maxVy = 0;
            

            anim.SetBool("Climbing", false);
            anim.SetBool("Mining", false);
            anim.SetBool("Falling", false);
            hpText.text = "HP: " + Math.Round(hpP).ToString();
        }
        */
        if (other.gameObject.CompareTag("BottomGround"))
        {
            isOnBGround = true;
        }
        if (other.gameObject.CompareTag("Rock"))
        {
            Rigidbody kr = other.gameObject.GetComponent<Rigidbody>();
            Debug.Log("HIT BY KR: " + kr.velocity.y);
            if (!OreDection.instance.helmet)
            {
                if (kr.velocity.y < 0)
                {
                    hpP += (kr.velocity.y * 3);
                    hpText.text = "HP: " + Math.Round(hpP).ToString();
                }
                else
                {
                    hpP -= (kr.velocity.y * 3);
                    hpText.text = "HP: " + Math.Round(hpP).ToString();
                }
            }
            else
            {
                if (kr.velocity.y < 0)
                {
                    hpP += (kr.velocity.y * 2);
                    hpText.text = "HP: " + Math.Round(hpP).ToString();
                }
                else
                {
                    hpP -= (kr.velocity.y * 2);
                    hpText.text = "HP: " + Math.Round(hpP).ToString();
                }
            }
            if (hpP <= 0)
            {
                hpP = 0;
                hp = 0;
                anim.SetBool("Death", true);
                AudioScript.clip = AudioSources.instance.Death;
                AudioScript.Play();
                PlayerDied();
            }
        }
        if (other.gameObject.CompareTag("Ice"))
        {
            Rigidbody kr = other.gameObject.GetComponent<Rigidbody>();
            Debug.Log("HIT BY KR: " + kr.velocity.y);
            hpP += (kr.velocity.y * 3);
            hpText.text = "HP: " + Math.Round(hpP).ToString();
        }
        if (other.gameObject.CompareTag("IceCube"))
        {
            Rigidbody kr = other.gameObject.GetComponent<Rigidbody>();
            float kr2 = 0;
            if (kr.velocity.y > 0) kr2 = -kr.velocity.y;
            if (kr.velocity.y < 0) kr2 = kr.velocity.y;
            Debug.Log("HIT BY KR: " + kr.velocity.y);
            hpP += (kr2);
            hpText.text = "HP: " + Math.Round(hpP).ToString();
        }
        if (other.gameObject.CompareTag("Kill"))
        {
            PlayerDied();
        }
        if (other.gameObject.CompareTag("Door"))
        {
            if (key)
            {
                SetLevel(Level.BIOME2);
            }
        }
        if (other.gameObject.CompareTag("Shop"))
        {
            ShopPanel.SetActive(true);
            UIManager.instance.Freeze(true);
            UIManager.instance.ChangeShopActive(true);
        }
        else
        {
            ShopPanel.SetActive(false);
            UIManager.instance.Freeze(false);
            UIManager.instance.ChangeShopActive(false);
        }
        if (other.gameObject.name == "Snowy Mercant")
        {
            dialoge.Say();
            UIManager.instance.Freeze(true);
        }
        if (other.gameObject.CompareTag("Artifact1"))
        {
            OreDection.instance.Artifact(1);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Artifact2"))
        {
            OreDection.instance.Artifact(2);
            Destroy(other.gameObject);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Heal"))
        {
            hpP += 0.05;
            hp = (int)hpP;
            anim.SetBool("Climbing", false);
            anim.SetBool("Mining", false);
            anim.SetBool("Falling", false);
            hpText.text = "HP: " + hp.ToString();
        }
        if (other.gameObject.CompareTag("CaveTrigger"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("YOU HAVE ENTERED THE CAVE");
                SetLevel(Level.CAVE);
            }
        }
        if (other.gameObject.CompareTag("CaveExit"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("YOU HAVE LEAVED THE CAVE");
                gameObject.transform.position = CaveEntrance.transform.position;
                level = Level.BIOME1;
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                anim.SetBool("Walking", false);
            }
        }
        if (other.gameObject.CompareTag("Sludge"))
        {
            speed = 4.0f; 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            isTouchingWall = false;
        }
        if (other.gameObject.CompareTag("BottomGround"))
        {
            isOnBGround = false;
        }
        if (other.gameObject.CompareTag("Sludge"))
        {
            speed = 7.0f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("BottomGround"))
        {
            isOnGround = true;
            isInAir = false;
            /*
            hp = (int)Math.Round(hpP);
            hpP = hp;
            if (hp < 0)
            {
                hp = 0;
                anim.SetBool("Death", true);
            }
            */

            if (maxVy < -10)
            {
                AudioScript.clip = AudioSources.instance.Oof;
                AudioScript.Play();
                if (!OreDection.instance.boots) hpP += maxVy * 2;
                else
                {
                    if (maxVy * 2 < 70)
                    {
                        hpP += maxVy;
                    }
                    else hpP += maxVy * 2;
                }
            }
            if (hpP <= 0)
            {
                hpP = 0;
                hp = 0;
                anim.SetBool("Death", true);
                AudioScript.clip = AudioSources.instance.Death;
                AudioScript.Play();
                PlayerDied();
            }
            maxVy = 0;


            anim.SetBool("Climbing", false);
            anim.SetBool("Mining", false);
            anim.SetBool("Falling", false);
            hpText.text = "HP: " + Math.Round(hpP).ToString();
        }
    }
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (!OreDection.instance.chestplate) hpP -= 0.05;
            else hpP -= 0.025;
            hp = (int)hpP;
            hpText.text = "HP: " + hp.ToString();
        }
        if (other.gameObject.CompareTag("Boss"))
        {
            if (!OreDection.instance.chestplate) hpP -= 0.1;
            else hpP -= 0.05;
            hp = (int)hpP;
            hpText.text = "HP: " + hp.ToString();
        }
    }
}
