using UnityEngine;
using UnityEngine.Audio;

public class RandomMusic : MonoBehaviour
{
    public AudioResource[] musics;

    void Start()
    {
        AudioSource source = GetComponent<AudioSource>();
        source.resource = musics[Random.Range(0, musics.Length)];
        source.Play();
    }
}
