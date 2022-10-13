using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class StartClientBuild : MonoBehaviour
{
    public bool debug;
    public bool startHost;
    public bool startClient;

    // Start is called before the first frame update
    void Start()
    {
        if (debug) Invoke("StartSession", 3.5f);
    }

    public void StartHost() { NetworkManager.Singleton.StartHost(); }
    public void StartClient() { NetworkManager.Singleton.StartClient(); }

    public void StartSession() {
        if (startHost) NetworkManager.Singleton.StartHost();
        if (startClient) NetworkManager.Singleton.StartClient();
    }
}
