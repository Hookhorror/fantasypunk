using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{

    public int maxHP = 100;
    public int currentHP;

    public AudioClip hit;
    public AudioClip criticalHit;

    public HPBar hpBar;

    private AudioSource source;
    private GameObject player;

    internal bool dead = false;

    void Awake()
    {
        // currentHP = maxHP;
        // hpBar.SetMaxHP(maxHP);
        // source = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerManager.instance.player;
        currentHP = maxHP;
        hpBar.SetMaxHP(maxHP);
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Projectile") || other.gameObject.CompareTag("Enemy")){
            TakeDMG(10);
            var rbA = other.gameObject.GetComponent<Rigidbody2D>();
            var rbB = player.gameObject.GetComponent<Rigidbody2D>();
            if (rbA != null && rbB != null)
            {
                Debug.Log("IMPULSE");
                Vector3 diff = rbB.position - rbA.position;
                rbB.AddForce((diff.normalized)*8, ForceMode2D.Impulse);
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Projectile") || other.gameObject.CompareTag("Enemy")){
            TakeDMG(10);
            var rbA = other.gameObject.GetComponent<Rigidbody2D>();
            var rbB = player.gameObject.GetComponent<Rigidbody2D>();
            if (rbA != null && rbB != null)
            {
                Debug.Log("IMPULSE");
                Vector3 diff = rbB.position - rbA.position;
                rbB.AddForce((diff.normalized) * 8, ForceMode2D.Impulse);
            }
        }
    }

    void TakeDMG(int dmg)
    {
        currentHP -= dmg;
        hpBar.SetHP(currentHP);
        if (currentHP > maxHP * 0.4)
            source.PlayOneShot(hit);
        else source.PlayOneShot(criticalHit);

        if (currentHP <= 0)
        {
            // System.Threading.Thread.Sleep(2000);
            // SceneManager.LoadScene("Death");
            dead = true;
            // MakeLegsAndTorsoOpaque();
            Debug.Log("You died");
            Invoke("LoadDeathScreen", 2);
        }
        Debug.Log("Took damage: HP now " + currentHP);
    }

    public void DealDamageToSelf(int dmg)
    {
        TakeDMG(dmg);
        // Debug.Log(currentHP);
    }

    private void MakeLegsAndTorsoOpaque()
    {
        // player.GetComponent<Legs>().MakeOpaque();
        // player.GetComponent<Facing>().MakeOpaque();
    }

    private void LoadDeathScreen()
    {
        SceneManager.LoadScene("Death");
    }
}
