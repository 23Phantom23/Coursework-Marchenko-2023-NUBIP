using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class IsHost : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    private void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
          
        }
        else
        if (!PhotonNetwork.IsMasterClient)
        {
            GameObject spawnobject = GameObject.FindGameObjectWithTag("SpawnEnemyes");
            Destroy(spawnobject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
