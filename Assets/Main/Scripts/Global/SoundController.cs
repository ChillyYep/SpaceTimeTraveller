using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoundController : MonoBehaviour {
    public static SoundController instance = null;
    [HideInInspector]
    public AudioSource music;
    public AudioSource soundEffect;
    private string sceneCode;

    //public List<AudioClip> bgMusic = new List<AudioClip>();//背景音乐
    public AudioClip mainUIMusice;
    public AudioClip beforeGameMusic;
    public AudioClip firstChapterMusic;
    public AudioClip secondChapterMusic;
    public AudioClip happyEndMusic;
    public AudioClip badEndMusic;

    public enum SoundEffect { /*HIT,*/DOOR,DIALOG,SHOCK};
    //public AudioClip hitSound;//撞击音效
    public AudioClip doorSound;//门音效
    public AudioClip dialogSound;//对话音效
    public AudioClip shockSound;//惊叹音效

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(instance);
        }
        DontDestroyOnLoad(gameObject);
        sceneCode = SceneManager.GetActiveScene().name;
        music = GetComponent<AudioSource>();
        ChangeMusicBySceneCode(sceneCode);
        soundEffect.loop = false;
        InitMusic();
    }

    void Update()
    {
        if (sceneCode != SceneManager.GetActiveScene().name)
        {
            Debug.Log("BeforeUpdate:sceneCode=" + sceneCode);
            sceneCode = SceneManager.GetActiveScene().name;
            Debug.Log("AfterUpdate:sceneCode=" + sceneCode);
            ChangeMusicBySceneCode(sceneCode);
        }
    }

    void InitMusic()
    {
        music.volume = ReadWriteSetting.GetInstance().ReadSetting().musicVolumn;//音量初始化
        music.loop = true;
    }

    //因场景改变而改变背景音乐
    void ChangeMusicBySceneCode(string sceneCode)
    {
        switch (sceneCode)
        {
<<<<<<< HEAD
            case GloabalManager.SceneCodeManager.MainUI:
                ChangeMusicOrSoundEffect(music, mainUIMusice);
                break;
            case GloabalManager.SceneCodeManager.BeforeGame1:
            case GloabalManager.SceneCodeManager.BeforeGame2:
            case GloabalManager.SceneCodeManager.BeforeGame3:
                ChangeMusicOrSoundEffect(music, beforeGameMusic);
                break;
            case GloabalManager.SceneCodeManager.FirstChapter:
                ChangeMusicOrSoundEffect(music, firstChapterMusic);
                break;
            case GloabalManager.SceneCodeManager.SecondChapter:
                ChangeMusicOrSoundEffect(music, secondChapterMusic);
                break;
            case GloabalManager.SceneCodeManager.HappyEnd:
                ChangeMusicOrSoundEffect(music, happyEndMusic);
                break;
            case GloabalManager.SceneCodeManager.BadEnd:
=======
            case GlobalManager.SceneCode.MainUI:
                ChangeMusicOrSoundEffect(music, mainUIMusice);
                break;
            case GlobalManager.SceneCode.BeforeGame1:
            case GlobalManager.SceneCode.BeforeGame2:
            case GlobalManager.SceneCode.BeforeGame3:
                ChangeMusicOrSoundEffect(music, beforeGameMusic);
                break;
            case GlobalManager.SceneCode.FirstChapter:
                ChangeMusicOrSoundEffect(music, firstChapterMusic);
                break;
            case GlobalManager.SceneCode.SecondChapter:
                ChangeMusicOrSoundEffect(music, secondChapterMusic);
                break;
            case GlobalManager.SceneCode.HappyEnd:
                ChangeMusicOrSoundEffect(music, happyEndMusic);
                break;
            case GlobalManager.SceneCode.BadEnd:
>>>>>>> new
                ChangeMusicOrSoundEffect(music, badEndMusic);
                break;
            default:
                break;

        }
    }
    //改变背景音乐
    void ChangeMusicOrSoundEffect(AudioSource audioSource, AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.time = 0.0f;
        audioSource.Play();
        Debug.Log("audioSource:" + audioSource.isPlaying);
    }

    //播放各种音效
    public void PlaySoundEffect(SoundEffect effect)
    {
        switch (effect)
        {
            //case SoundEffect.HIT:
            //    ChangeMusicOrSoundEffect(soundEffect,hitSound);
            //    break;
            case SoundEffect.DOOR:
                ChangeMusicOrSoundEffect(soundEffect, doorSound);
                break;
            case SoundEffect.DIALOG:
                ChangeMusicOrSoundEffect(soundEffect, dialogSound);
                break;
            case SoundEffect.SHOCK:
                ChangeMusicOrSoundEffect(soundEffect, shockSound);
                break;
            default:
                break;
        }
    }
}
