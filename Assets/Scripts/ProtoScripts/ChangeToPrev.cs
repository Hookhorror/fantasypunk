using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    private int prevScene;
    // Start is called before the first frame update
    void Start()
    {
        prevScene = SceneManager.GetActiveScene().buildIndex - 1;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        SceneManager.LoadScene(prevScene);
    }
}
