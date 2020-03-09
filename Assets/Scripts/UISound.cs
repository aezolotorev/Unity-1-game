using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public   class UISound : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _openPanel;
    [SerializeField] private AudioClip _closePanel;
    [SerializeField] private AudioClip _openStorage;
    [SerializeField] private AudioClip _closeStorage;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public  void OpenPanel()
    {                
        Debug.Log("открыто");
        _audioSource.PlayOneShot(_openPanel);     
    }
    public void ClosePanel()
    {
        _audioSource.PlayOneShot(_closePanel);
    } 
    public void OpenStorage()
    {
        _audioSource.PlayOneShot(_openStorage);
    }
    public void CloseStorage()
    {
        _audioSource.PlayOneShot(_closeStorage);
    }
} 
