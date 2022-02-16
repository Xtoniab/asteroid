using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    private Dictionary<string, AudioClip> _sounds = new Dictionary<string, AudioClip>();
    private AudioSource _source;

    private static SoundManager _instance;
    public static SoundManager Instance => _instance; 
    
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Debug.LogError("Audio maager multiple initialization!");
        }
        _source = GetComponent<AudioSource>();
    }
   
    public void AddSound(string name, AudioClip clip) // Добавляем аудио в список
    {
        if(!_sounds.ContainsKey(name))
        {
            _sounds[name] = clip;
        }
        else
        {
            Debug.LogError("Trying to add sound effect with name that already exist!");
        }
    }
    public void PlaySound(string name) // Воспроизводим аудио
    {
        if (_sounds.ContainsKey(name))
        {
            _source.PlayOneShot(_sounds[name]);
        }
        else
        {
            Debug.LogError("Trying to play audio wich doesnt exist!");
        }
    }
}
