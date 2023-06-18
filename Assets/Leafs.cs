using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leafs : MonoBehaviour
{
    public Canvas canvasHojas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wheels") || other.CompareTag("Player"))
        {
            //Debug.Log("Activar el canvas del las hojas");
            canvasHojas.gameObject.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
