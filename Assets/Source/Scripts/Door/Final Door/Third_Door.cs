using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Third_Door : MonoBehaviour
{
    [SerializeField] private Animator _thirdDoorAnimator;

    private AudioSource _doorSound;


    private void Start()
    {
        _doorSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Movement player))
        {
            _thirdDoorAnimator.SetTrigger("Activate");
            _doorSound.Play();
        }
    }

}