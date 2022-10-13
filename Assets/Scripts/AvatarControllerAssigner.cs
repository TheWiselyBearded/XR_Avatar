using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class AvatarControllerAssigner : NetworkBehaviour {
    public List<GameObject> sourceJoints;
    [SerializeField ]public AvatarController networkRigAvatarController;
    public GameObject localAvatarRig;

    private void Awake() {
        NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnected;
        //if (localAvatar) GetComponent<NetworkObject>().SpawnAsPlayerObject(NetworkManager.Singleton.LocalClientId);
    }

    private void OnDestroy() {
        NetworkManager.Singleton.OnClientConnectedCallback -= OnClientConnected;
    }

    public void OnClientConnected(ulong clientID) {
        Debug.Log("Client connected");
        if (clientID == NetworkManager.Singleton.LocalClientId) {
            Debug.Log("Local clinet connected");
            networkRigAvatarController = NetworkManager.Singleton.LocalClient.PlayerObject.GetComponent<AvatarController>();
            //networkRigAvatarController = 
            //    NetworkManager.Singleton.ConnectedClients[NetworkManager.Singleton.LocalClientId].PlayerObject.GetComponent<AvatarController>();
            if (networkRigAvatarController == null) {
                networkRigAvatarController =
                    NetworkManager.Singleton.LocalClient.PlayerObject.GetComponentInChildren<AvatarController>();
                //NetworkManager.Singleton.ConnectedClients[NetworkManager.Singleton.LocalClientId].PlayerObject.GetComponentInChildren<AvatarController>();
            }
            networkRigAvatarController.AssignMappings(sourceJoints);
            localAvatarRig.SetActive(false);
        } else {
            Debug.Log("Remote Client connected");
            //NetworkManager.Singleton.ConnectedClients[clientID].PlayerObject.GetComponent<AvatarController>().enabled = false;
        }
        //skeletalToggle.ToggleBodyParts(false);
    }


    /*public override void OnNetworkSpawn() {
        // Do things with m_MeshRenderer
        Debug.Log("OnNetworkSpawn invoked");
        if (IsOwner) {
            Debug.Log("Player instance owned locally");
            //skeletalToggle.ToggleBodyParts(false);
        }
        base.OnNetworkSpawn();
    }*/
}
