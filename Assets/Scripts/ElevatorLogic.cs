using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElevatorLogic : MonoBehaviour
{
    public string nextLevel;

    void OnTriggerEnter2D()
    {
        SceneManager.LoadScene(nextLevel);
    }
}
