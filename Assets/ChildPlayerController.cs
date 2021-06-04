using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildPlayerController : MonoBehaviour
{
    public Animator _animator;
    public PLayerMovement _playermovement;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Count")
        {
            Destroy(other.gameObject);
            _playermovement.ChildActivation(other.gameObject);
        }
    }
}
