using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public abstract class SoundsList<T> : MonoBehaviour where T : class
{
    [SerializeField] private SerializableStringAduiClipDictionary _sounds;

    private AudioSource _source;
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError($"Trying to use uninitialized sounds manager!");
            }
            return _instance;
        }
        private set
        {
            _instance = value;
        }
    }


    private void Awake()
    {
        _source = GetComponent<AudioSource>();
        Instance = this as T;
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
