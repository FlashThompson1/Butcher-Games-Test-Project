using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinorLose : MonoBehaviour
{

    public Progress progress;
    [SerializeField] private AudioClip _winMusic;
    [SerializeField] private AudioClip _loseMusic;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private Animator _playerAnimatorForWinorLose;
    private AudioSource _winOrLoseSound;


    private void Start()
    {
        _winOrLoseSound = GetComponent<AudioSource>();
    }

  


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Movement player))
        {
            if (progress.collectedElements >= 80)
            {
                _playerAnimatorForWinorLose.Play("Wining Dance");
                _winPanel.SetActive(true);
                _winOrLoseSound.PlayOneShot(_winMusic);

            }
            else
            {
                _playerAnimatorForWinorLose.Play("Lose");
                _losePanel.SetActive(true);
                _winOrLoseSound.PlayOneShot(_loseMusic);
            }

        }
        
    }
}
