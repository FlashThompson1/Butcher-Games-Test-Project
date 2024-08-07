using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class First_Door : MonoBehaviour
{
    [SerializeField] private Animator _frstDoorAnimator;

    private AudioSource _doorSound;


    private void Start() {
        _doorSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Movement player))
        {
            _frstDoorAnimator.SetTrigger("Activate");
            _doorSound.Play();
        }
    }
}