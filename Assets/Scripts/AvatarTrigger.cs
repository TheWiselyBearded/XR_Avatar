using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A simple class to detect avatar hand collisions in a button-like manner
/// and invoke Unity Events 
/// </summary>
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
