using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManagers : SingleTon<AudioManagers>
{
    [SerializeField] private AudioClip lobbyBgm = null;
    [SerializeField] private AudioClip gameBgm = null;
    [SerializeField] private AudioClip enterRoom = null;
    [SerializeField] private AudioClip leftRoom = null;
    [SerializeField] private AudioClip click = null;
    [SerializeField] private AudioClip attack = null;
    [SerializeField] private AudioClip death = null;

    [SerializeField] private AudioSource BGMSource = null;
    [SerializeField] private AudioSource FXSource = null;

    public AudioClip LobbyBGM { get { return lobbyBgm; } }
    public AudioClip GameBgm { get { return gameBgm; } }
    public AudioClip EnterRoom { get { return enterRoom; } }
    public AudioClip LeftRoom { get { return leftRoom; } }
    public AudioClip Click { get { return click; } }
    public AudioClip Attack { get { return attack; } }
    public AudioClip Death { get { return death; } }


    void Start()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
    public void BGM(AudioClip bgm)
    {
        BGMSource.Stop();
        BGMSource.clip = bgm;
        BGMSource.Play();
    }
    public void FX(AudioClip fx) => FXSource.PlayOneShot(fx);



    
}
