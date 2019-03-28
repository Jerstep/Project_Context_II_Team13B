using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    [SerializeField] private AudioSource ac1;
    [SerializeField] private AudioSource ac2;

    private bool ac1Active = true;
    private bool ac2Active = false;

    public float lerpSpeed;

    public AudioClip[] audioClips; // Music for diffrent segments of the game

    public void ChangeMusic(int index)
    {
        if(ac1Active)
        {
            ac2.clip = audioClips[index];
            ac2.Play();
            StartCoroutine(Crossfade(ac1, ac2));
        }
        else
        {
            ac1.clip = audioClips[index];
            ac1.Play();
            StartCoroutine(Crossfade(ac2, ac1));
        }
        ac1Active = !ac1Active;
        ac2Active = !ac2Active;
    }

    IEnumerator Crossfade(AudioSource activeAC, AudioSource unactiveAC)
    {
        while(activeAC.volume > 0)
        {
            activeAC.volume -= lerpSpeed * Time.deltaTime;
            unactiveAC.volume += lerpSpeed * Time.deltaTime;
            yield return null;
        }
    }
}
