using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    [SerializeField] private Animator _checkPointAnimator;
    [SerializeField] private AudioSource _source;

    public void Activator() {
        _checkPointAnimator.SetTrigger("Activate");
        _source.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Movement player))
        {
            Activator();
        }
    }
 }
