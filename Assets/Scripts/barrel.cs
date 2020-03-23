using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrel : MonoBehaviour
{

    private Animator animator;

    public AudioClip soundEffect;
    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Smash()
    {
        animator.SetBool("smash", true);
        source.PlayOneShot(soundEffect);
        StartCoroutine(breakCo());
    }

    IEnumerator breakCo()
    {
        yield return new WaitForSecondsRealtime(5);
        this.gameObject.SetActive(false);
    }
}
