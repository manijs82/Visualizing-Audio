using UnityEngine;

public class SampleCreator : MonoBehaviour
{
    public static float[] Samples;

    [SerializeField] private int sampleCount;
    
    private AudioSource _audioSource;
    
    void Awake()
    {
        Samples = new float[sampleCount];
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        GetSpectrumAudioSource();
    }

    private void GetSpectrumAudioSource()
    {
        _audioSource.GetSpectrumData(Samples, 0, FFTWindow.Blackman);
    }
}
