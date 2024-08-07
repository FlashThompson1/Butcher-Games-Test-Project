using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Second_Door : MonoBehaviour
{
    [SerializeField] private Animator _secondDoorAnimator;

    private AudioSource _doorSound;

    private void Start()
    {
        _doorSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Movement player))
        {
            _secondDoorAnimator.SetTrigger("Activate");
            _doorSound.Play();
        }
    }
}
