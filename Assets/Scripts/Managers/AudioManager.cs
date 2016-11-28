using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

    public AudioClip[] fx;
    private AudioSource audioSource;

    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayFX(int index, float volume) {
        audioSource.PlayOneShot(fx[index],volume);
    }
}
