using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Study_Door : MonoBehaviour
{
    [SerializeField] private Progress progress;


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Movement player))
        {
            progress.StudyDoor();
        }
    }
}