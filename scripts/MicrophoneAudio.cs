using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MicrophoneAudio : MonoBehaviour {
  public AudioSource audioSource;
  public List<AudioClip> audioList;

  void Start() {
    SceneController.OnClickStartMicEvent += OnClickStartMic;
    SceneController.OnClickEndMicEvent += OnClickEndMic;
    SceneController.OnClickReproduceMicEvent += OnClickReproduce;
    audioSource = GetComponent<AudioSource>();
    audioList = new List<AudioClip> {};
  }

  void Update() {}

  void OnClickStartMic() {
    if (!Microphone.IsRecording("")) {
      audioList.Add(Microphone.Start("", true, 10, 44100));
    }
  }

  void OnClickEndMic() {
    if (Microphone.IsRecording("")) {
      Microphone.End("");
    }
  }

  void OnClickReproduce() {
    for(int i = 0; i < audioList.Count; i++) {
      audioSource.clip = audioList[i];
      audioSource.Play();
    }
  }

  void OnDisable() {
    SceneController.OnClickStartMicEvent -= OnClickStartMic;
    SceneController.OnClickEndMicEvent -= OnClickEndMic;
    SceneController.OnClickReproduceMicEvent -= OnClickReproduce;
  }
}
