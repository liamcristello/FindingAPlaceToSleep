using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioSource layer1Music;
    public AudioSource layer2Music;
    public AudioSource layer3Music;

    public AudioMixerSnapshot layer1On;
    public AudioMixerSnapshot layer1Off;
    public AudioMixerSnapshot layer2On;
    public AudioMixerSnapshot layer2Off;
    public AudioMixerSnapshot layer3On;
    public AudioMixerSnapshot layer3Off;

    public float transitionIn;
    public float transitionOut;
    public float longFadeOut;
    
    void Start()
    {
        StartTheMusic();
        IntensityOne();
    }

    public void IntensityOne()
    {
        layer1On.TransitionTo(transitionIn);
        layer2Off.TransitionTo(transitionOut);
        layer3Off.TransitionTo(transitionOut);
    }

    public void IntensityTwo()
    {
        layer1On.TransitionTo(transitionIn);
        layer2On.TransitionTo(transitionIn);
        layer3Off.TransitionTo(transitionOut);
    }

    public void IntensityThree()
    {
        layer1On.TransitionTo(transitionIn);
        layer2On.TransitionTo(transitionIn);
        layer3On.TransitionTo(transitionIn);
    }

    public void RestartIntensity(){
        layer1On.TransitionTo(0);
        layer2Off.TransitionTo(transitionOut);
        layer3Off.TransitionTo(transitionOut);
    }

    public void StartTheMusic()
    {
        RestartIntensity();
        layer1Music.Play();
        layer2Music.Play();
        layer3Music.Play();
    }

    public void StopTheMusic(){
        layer1Off.TransitionTo(longFadeOut);
        layer2Off.TransitionTo(longFadeOut);
        layer3Off.TransitionTo(longFadeOut);
    }
   
}
