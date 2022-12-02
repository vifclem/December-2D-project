
using UnityEngine;
using UnityEngine.Audio;

public class audioManageur : MonoBehaviour
{

    public AudioClip[] playlist;
    public AudioSource audioSource;
    private int musicIndex = 0;
    public static audioManageur instance;
    public AudioMixerGroup soundEffectMixer;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = playlist[0];
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            PlayNextSong();
        }
    }

    private void PlayNextSong()
    {
        musicIndex = (musicIndex + 1) % playlist.Length;
        audioSource.clip = playlist[musicIndex];
        audioSource.Play();
    }

    //public AudioSource PlayClipAt(AudioClip clip,Vector3 pose)
    //{
        //GameObject TempGO = new GameObject("TempAudio");
        //TempGO.transform.position = pose ;
        //AudioSource audioSource = TempGO.AddComponent<AudioSource>();
        //audioSource.clip = clip ;
       // audioSource.outputAudioMixerGroup = soundEffectMixer;
        //audioSource.Play();
       //Destroy(TempGO, clip.length);
        //return audioSource;
    //}
}
