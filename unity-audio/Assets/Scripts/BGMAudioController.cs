using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;

public class BGMAudioController : MonoBehaviour
{
    public AudioMixer mixer;
    private AudioMixerGroup[] audioMixerGroups = null;
    // Start is called before the first frame update
    void Start()
    {
        audioMixerGroups = mixer.FindMatchingGroups(string.Empty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetBGMVolume()
    {
        audioMixerGroups.Where(group => group.name == "BGM")
    }
}
