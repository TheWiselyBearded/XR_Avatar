using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarTrigger : MonoBehaviour
{
    [SerializeField] public Button ButtonEvent;
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("FullHand")) {
            Debug.Log($"Collided with {other.gameObject.name}");
            ButtonEvent.onClick.Invoke();
        }
    }
}
