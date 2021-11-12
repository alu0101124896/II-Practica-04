using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneAudio : MonoBehaviour {
  public AudioSource audioSource;

  void Start() {
    SceneController.OnClickStartMicEvent += OnClickStartMic;
    SceneController.OnClickEndMicEvent += OnClickEndMic;
    audioSource = GetComponent<AudioSource>();
    audioSource.clip = Microphone.Start("", true, 10, 44100);
  }

  void Update() {}

  void OnClickStartMic() {
    if (!Microphone.IsRecording("")) {
      audioSource.clip = Microphone.Start("", true, 10, 44100);
    }
  }

  void OnClickEndMic() {
    if (Microphone.IsRecording("")) {
      Microphone.End("");
      audioSource.Play();
    }
  }

  void OnDisable() {
    SceneController.OnClickStartMicEvent += OnClickStartMic;
    SceneController.OnClickEndMicEvent += OnClickEndMic;
  }
}
