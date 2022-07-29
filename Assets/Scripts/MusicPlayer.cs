using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    
    public AudioSource source;

    private void Awake() => 
        source = GetComponent<AudioSource>();

    private void Start()
    {
        MusicTitle.NewMusicSelected += Play;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            canvas.SetActive(!canvas.activeSelf);
            Cursor.visible = canvas.activeSelf;
        }        
    }

    private void Play(int index)
    {
        source.clip = MusicList.Musics[index];
        source.Play();
    }
}
