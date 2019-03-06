using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public Track[] tracks;
    public AudioSource squeaker;

    public static MusicManager me;

    private void Awake()
    {
        me = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(me == null)
        {
            Debug.LogError("MuiscManager.me is not bound!");
        }
    }

    public void Squeak()
    {
        if(TextHandler.me.speaker == TextHandler.Speakers.VERGIL)
        {
            squeaker.clip = TextHandler.me.vergilSqueaks[Random.Range(0, 6)];
            squeaker.Play();
        }
        else if (TextHandler.me.speaker == TextHandler.Speakers.HOMER)
        {
            squeaker.clip = TextHandler.me.homerSqueaks[Random.Range(0, 6)];
            squeaker.Play();
        }
    }
}

[System.Serializable]
public class Track
{
    public string name;
    public AudioSource source;

    public void Play()
    {
        source.Play();
    }
    public void Pause()
    {
        source.Pause();
    }
    public void UnPause()
    {
        source.UnPause();
    }
    public void Stop()
    {
        source.Stop();
    }
    public void ChangeTrack(AudioClip a)
    {
        source.clip = a;
    }
    public void SetVolume(float v)
    {
        source.volume = v;
    }
}
