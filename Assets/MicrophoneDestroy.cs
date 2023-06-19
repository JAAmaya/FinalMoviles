using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MicrophoneDestroy : MonoBehaviour
{
    bool useMic = true;
    AudioSource _audioSource;
    public AudioMixerGroup _mixerMicro;
    public AudioMixerGroup _mixerGeneral;
    private float[] clipSampleData = new float[128];
    public float minimumlevel; 
    private float currentVol;

    public TextMeshProUGUI texto;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        if(useMic){
            if(Microphone.devices.Length >0)
            {
                var microSeleccionado = Microphone.devices[0].ToString();
                _audioSource.outputAudioMixerGroup = _mixerMicro;
                _audioSource.clip = Microphone.Start(microSeleccionado, true, 1, AudioSettings.outputSampleRate);
                
            }else{
                useMic = false;
            }
        }
        if(!useMic){
            Debug.Log("Microfono no encontrado");
            _audioSource.outputAudioMixerGroup = _mixerGeneral;
        }
        _audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        currentVol = getMicVolume();
        texto.text = currentVol.ToString();
        if (currentVol >= minimumlevel)
        {
            this.gameObject.SetActive(false);
        }
    }

    public float getMicVolume()
    {
        _audioSource.GetOutputData(clipSampleData, 0);
        float totalLoud = 0;
        for (int i = 0; i < 128; i++)
        {
            totalLoud += Mathf.Abs(clipSampleData[i]);
        }
        return (totalLoud / 128);
    }
}
