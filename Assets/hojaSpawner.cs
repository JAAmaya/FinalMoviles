using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hojaSpawner : MonoBehaviour
{
    public GameObject hojas;
    // Start is called before the first frame update
    void Start()
    {
        var initstate = (int)(Time.realtimeSinceStartup * 100000);
        //Debug.Log(initstate);
        Random.InitState(initstate);
        float random = Random.Range(0, maxInclusive:1);
        //Debug.Log(random);
        if(random >= 0.5)
        {
            hojas.SetActive(true);
        }
    }
}
