using UnityEngine;

public class audio : MonoBehaviour
{
    public AudioSource music;
    public AudioSource sf;
    public AudioClip nhacnen;
    public AudioClip nhacbancung;
    public AudioClip nhacbanchetthuhoang;
    public AudioClip nhacWin;
    public AudioClip nhactrudiem;
    public AudioClip nhacOver;
    public AudioClip backG;

    void Start()
    {
        Nhacnen();
    }

    public void PlaySfnhac(AudioClip sfclip)
    {
        if (sfclip == null) return;
        sf.clip = sfclip;
        sf.Play();
    }

    public void Nhacnen()
    {
        music.clip = nhacnen;
        music.Play();
    }

    public void StopG()
    {
        if (music.isPlaying) music.Stop();
    }
}
