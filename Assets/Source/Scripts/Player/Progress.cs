using UnityEngine;
using UnityEngine.UI;

public class Progress : MonoBehaviour
{
    [SerializeField] private Transform character; // The character to follow


    [SerializeField] private Image fillImage; 
    [SerializeField] private int totalElements = 50; 
     public  int collectedElements = 20;

    [SerializeField] private AudioSource _collectableSounds;

    [SerializeField] private AudioClip _moneySound;
    [SerializeField] private AudioClip _failSound;


    private void Update() {

        if (collectedElements < 0) { 
            collectedElements = 0;
        }
    }


    public void UpdateProgressBar()
    {
        float fillAmount = (float)collectedElements / totalElements;
        fillImage.fillAmount = fillAmount;
    }

    // Method to collect an element
    public void CollectMoney()
    {
        if (collectedElements < totalElements)
        {
            collectedElements+=2;
            _collectableSounds.PlayOneShot(_moneySound);
            UpdateProgressBar();
        }
    }


    public void LoseMoney()
    {
        if (collectedElements < totalElements)
        {
            collectedElements -= 5;
            _collectableSounds.PlayOneShot(_failSound);
            UpdateProgressBar();
        }
    }

    public void LosingOnDoor()
    {
        if (collectedElements < totalElements)
        {
            collectedElements -= 10;
            _collectableSounds.PlayOneShot(_failSound);
            UpdateProgressBar();

        }
    }
    public void StudyDoor()
    {
        if (collectedElements < totalElements)
        {
            collectedElements += 10;
            _collectableSounds.PlayOneShot(_moneySound);
            UpdateProgressBar();
        }
    }
}