using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource BackGround_Music;
    public AudioSource ShortMusic;
    public AudioClip Sound_001;			
    public AudioClip Sound_002;
    public AudioClip Sound_003;
    public AudioClip Sound_004;

    public AudioClip Short_001;
    public AudioClip Short_002;
    public AudioClip Short_003;
    public AudioClip Short_004;
    //背景音
   public enum BG_Music
    {
        sound_1,
        sound_2,
        sound_3,
        sound_4
    }
    //音效
   public enum Music
   {
       music_1,
       music_2,
       music_3,
       music_4
   }
    // Start is called before the first frame update
    void Start()
    {
        BackGround_Music = GetComponent<AudioSource>();
        ShortMusic = GameObject.Find("MusicOBJ").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            playBGmusic(BG_Music.sound_1);
        }
        if (Input.GetMouseButtonDown(1))
        {

            playBGmusic(BG_Music.sound_2);
        }
        }

    public void playMusic(Music which)
    {
        switch (which)
        {
            case Music.music_1:
                ShortMusic.PlayOneShot(Short_001);
                break;
            case Music.music_2:
                ShortMusic.PlayOneShot(Short_002);
                break;
            case Music.music_3:
                ShortMusic.PlayOneShot(Short_003);
                break;
            case Music.music_4:
                ShortMusic.PlayOneShot(Short_004);
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// 选择播放哪个背景音乐
    /// </summary>
    public void playBGmusic(BG_Music which)
    {
        switch (which)
        {
            case BG_Music.sound_1:
                BackGround_Music.clip = Sound_001;
                BackGround_Music.Play();
                break;
            case BG_Music.sound_2:
                BackGround_Music.clip = Sound_002;
                BackGround_Music.Play();
                break;
            case BG_Music.sound_3:
                BackGround_Music.clip = Sound_003;
                BackGround_Music.Play();
                break;
            case BG_Music.sound_4:
                BackGround_Music.clip = Sound_004;
                BackGround_Music.Play();
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// 暂停音乐
    /// </summary>
    public void stopAudio(BG_Music which)
    {
        switch (which)
        {
            case BG_Music.sound_1:
               // All_Music.Stop(Sound_001);
                break;
            case BG_Music.sound_2:
             //   All_Music.PlayOneShot(Sound_002);
                break;
            case BG_Music.sound_3:
            //    All_Music.PlayOneShot(Sound_003);
                break;
            case BG_Music.sound_4:
              //  All_Music.PlayOneShot(Sound_004);
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// 静音
    /// </summary>
    public void muteAudio(BG_Music which)
    {
        switch (which)
        {
            case BG_Music.sound_1:
                // All_Music.Stop(Sound_001);
                break;
            case BG_Music.sound_2:
                //   All_Music.PlayOneShot(Sound_002);
                break;
            case BG_Music.sound_3:
                //    All_Music.PlayOneShot(Sound_003);
                break;
            case BG_Music.sound_4:
                //  All_Music.PlayOneShot(Sound_004);
                break;
            default:
                break;
        }
    }
}
