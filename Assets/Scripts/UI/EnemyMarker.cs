using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMarker : MonoBehaviour
{

    public GameObject checkEnemies;
    public void SetMarkerOn()
    {
        checkEnemies.SetActive(true);
    }
    public void SetMarkerOff()
    {
        checkEnemies.SetActive(false);
    }

}
