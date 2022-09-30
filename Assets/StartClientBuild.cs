using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class StartClientBuild : MonoBehaviour
{
    public bool startHost;
    public bool startClient;

    // Start is called before the first frame update
    void Start()
    {
        if (startHost) NetworkManager.Singleton.StartHost();
        if (startClient) NetworkManager.Singleton.StartClient();
    }
}
