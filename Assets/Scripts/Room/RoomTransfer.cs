using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomTransfer : MonoBehaviour
{
    public Vector2 playerAdjust;
    public Vector2 cameraAdjust;
    public GameObject placeMarker;
    public Text placeText;
    public string placeName;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            GameObject player = other.gameObject;
            CameraMovement cam = Camera.main.GetComponent<CameraMovement>();
            cam.minP += cameraAdjust;
            cam.maxP += cameraAdjust;
            player.transform.position += new Vector3(playerAdjust.x, playerAdjust.y, 0);
            StartCoroutine(textCo());

        }
    }

    protected IEnumerator textCo()
    {
        placeMarker.SetActive(true);
        placeText.text = placeName;
        yield return new WaitForSeconds(4);
        placeMarker.SetActive(false);
    }
}
