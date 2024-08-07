using UnityEngine;

public class Poor_Doors : MonoBehaviour
{
    [SerializeField]private Progress progress;


  

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Movement player))
        {
            progress.LosingOnDoor();
        }
    }
}
