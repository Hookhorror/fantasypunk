using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [Header("New Scene Variables")]
    public string sceneToLoad;
    public Vector2 playerPosition;
    public VectorValue playerStorage;

    public VectorValue camMin;
    public VectorValue camMax;

    [Header("Tarnsition Variables")]

    public GameObject fadeInPanel;
    public GameObject fadeOutPanel;

    public float fadeWait;

    private void Awake() {
        if(fadeInPanel != null)
        {
            GameObject panel = Instantiate(fadeOutPanel);
            Destroy(panel, 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            playerStorage.initialValue = playerPosition;
            StartCoroutine(FadeCo());
        }
    }

    protected IEnumerator FadeCo()
    {
        if(fadeOutPanel != null)
        {
            Instantiate(fadeOutPanel, Vector3.zero, Quaternion.identity);
        }
        yield return new WaitForSeconds(fadeWait);
        
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneToLoad);
        while(!async.isDone)
        {
            yield return null;
        }
    }

}
