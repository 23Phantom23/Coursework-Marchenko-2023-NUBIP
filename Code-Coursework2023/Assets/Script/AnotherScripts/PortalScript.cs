using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    public float x;
    public float y;
    public float z;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            other.gameObject.transform.position = new Vector3(x, y, z);
            other.gameObject.SetActive(true);
        }
    }
}
