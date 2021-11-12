using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {
  public delegate void OnClickDelegate();
  public static event OnClickDelegate OnClickStartMicEvent, OnClickEndMicEvent;
  public static event OnClickDelegate OnClickPlayCamEvent, OnClickPauseCamEvent;
  public static event OnClickDelegate OnClickStopCamEvent;

  void Start() {}

  void Update() {}

  void OnGUI() {
    if (GUILayout.Button("Start Microphone")) {
      OnClickStartMicEvent();
    }
    if (GUILayout.Button("End Microphone")) {
      OnClickEndMicEvent();
    }
    if (GUILayout.Button("Play Camera")) {
      OnClickPlayCamEvent();
    }
    if (GUILayout.Button("Pause Camera")) {
      OnClickPauseCamEvent();
    }
    if (GUILayout.Button("Stop Camera")) {
      OnClickStopCamEvent();
    }
  }
}
