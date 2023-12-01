using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; set; }
    public AudioSource MenuIntro;
    public AudioSource MenuMain;
    public AudioSource Ambience;
    public AudioSource VitaIntro;
    public AudioSource VitaMain;
    public AudioSource MortIntro;
    public AudioSource MortMain;
    public AudioSource JumpVita;
    public AudioSource JumpMort;
    private AudioSource introPlay1;
    private AudioSource afterIntro1;
    private AudioSource introPlay2;
    private AudioSource afterIntro2;
    private bool waitingOnIntro;
    private Dictionary<string, AudioSource> soundLibrary = new Dictionary<string, AudioSource>();

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (Instance == null)
        {
            Instance = this;
        }
        soundLibrary.Add("Ambience", Ambience);
        soundLibrary.Add("MenuIntro", MenuIntro);
        soundLibrary.Add("MenuMain", MenuMain);
        soundLibrary.Add("VitaIntro", VitaIntro);
        soundLibrary.Add("VitaMain", VitaMain);
        soundLibrary.Add("MortIntro", MortIntro);
        soundLibrary.Add("MortMain", MortMain);
        soundLibrary.Add("JumpVita", JumpVita);
        soundLibrary.Add("JumpMort", JumpMort);
    }

    public void Update()
    {
        if (waitingOnIntro && introPlay1 != null && !introPlay1.isPlaying)
        {
            afterIntro1.Play();
            if(introPlay2 != null){
                afterIntro2.Play();
            }
            waitingOnIntro = false;
        }
    }
    public void PlayAmbience()
    {
        Ambience.Play();
        Ambience.loop = true;
    }

    public void StartMusic(string name)
    {
        if (name == "Menu")
        {
            MenuIntro.loop = false;
            MenuIntro.Play();
            introPlay1 = MenuIntro;
            afterIntro1 = MenuMain;
            afterIntro1.loop = true;
        }
        else if (name == "Vita" || name == "Mort")
        {
            VitaIntro.loop = false;
            MortIntro.loop = false;
            introPlay1 = (name == "Vita") ? VitaIntro : MortIntro;
            afterIntro1 = (name == "Vita") ? VitaMain : MortMain;
            introPlay2 = (name == "Vita") ? MortIntro : VitaIntro;
            afterIntro2 = (name == "Vita") ? MortMain : VitaMain;
            afterIntro1.loop = true;
            afterIntro2.loop = true;
        }
        waitingOnIntro = true;
    }

    public void PlaySound(string soundKey, bool looping = false){
        if(!soundLibrary.ContainsKey(soundKey)){
            Debug.Log("Sound, \"" + soundKey + "\" was not found in library!");
            return;
        }
        AudioSource selectedSound = soundLibrary[soundKey];
        selectedSound.loop = looping;
        selectedSound.Play();
    }

    public void SwitchCharacterTracks(bool vitaOrMort){
        VitaIntro.mute = vitaOrMort;
        MortIntro.mute = !vitaOrMort;
        VitaMain.mute = vitaOrMort;
        MortIntro.mute = vitaOrMort;
    }

    public void SetPosition(Vector2 newPosition) => transform.position = newPosition;
}
