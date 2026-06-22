using TMPro;
using UnityEngine;

public class audiomanager : MonoBehaviour
{
    public AudioSource music;
    public AudioSource soundfx;

    [Header("----------sOUNDS-------------")]
    public AudioClip player_death;
    public AudioClip bgmusic;
    public AudioClip bees;
    public AudioClip bossentry;
    public AudioClip boss_theme;
    public AudioClip helicopter;
    public AudioClip bomb;
    public AudioClip box_falling;
    public AudioClip box_destroying;
    public AudioClip letterpop;
    public AudioClip closing;
    public AudioClip attack;
    public AudioClip squish;
    public AudioClip finalbosslaugh;
    public void Start()
    {
        music.clip = bgmusic;
        music.volume = 0.05f;
        music.Play();
    }
    public void playsfx(AudioClip clip)
    {
        if(clip == box_falling)
        {
            soundfx.volume = 0.3f;
            soundfx.PlayOneShot(clip);
        }
        else
        {
            soundfx.volume = 0.6f;
            soundfx.PlayOneShot(clip);
        }
    }
    public void playmusic(AudioClip clip, bool play)
    {
        if (play)
        {
            music.Stop();
            music.clip = null;
            music.clip = clip;
            if(clip == bees)
            {
                music.volume = 10f;
            }
            music.Play();
        }
        if (!play)
        {
            music.Stop();
            music.clip = bgmusic;
            music.volume = 0.05f;
            music.Play();
        }
    }
    
}
