using UnityEngine;
using UnityEngine.UI;

public class MusicControls : MonoBehaviour
{
    [SerializeField] private MusicPlayer player;
    [SerializeField] private Slider timeSlider;
           
    private bool _isPaused;

    private void Start()
    {
        MusicTitle.NewMusicSelected += SetSliderValues;
    }

    private void SetSliderValues(int index)
    {
        timeSlider.value = 0;
        timeSlider.maxValue = MusicList.Musics[index].length;
    }

    private void UpdateTimeSlider()
    {
        timeSlider.value = player.source.time;
    }

    public void SetVolume(float volume)
    {
        player.source.outputAudioMixerGroup.audioMixer.SetFloat("Master", volume);
    }

    public void ChangeMusicTime(float time)
    {
        player.source.time = time;
    }

    public void TogglePause()
    {
        _isPaused = !_isPaused;
        if(_isPaused)
            player.source.Pause();
        else
            player.source.UnPause();
    }
}
