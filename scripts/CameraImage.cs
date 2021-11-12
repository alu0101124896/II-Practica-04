using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraImage : MonoBehaviour {
  public WebCamTexture webcamTexture;

  void Start() {
    SceneController.OnClickPlayCamEvent += OnClickPlayCam;
    SceneController.OnClickPauseCamEvent += OnClickPauseCam;
    SceneController.OnClickStopCamEvent += OnClickStopCam;
    webcamTexture = new WebCamTexture();
    Renderer renderer = GetComponent<Renderer>();
    renderer.material.mainTexture = webcamTexture;
    webcamTexture.Play();
  }

  void Update() {}

  void OnClickPlayCam() {
    if (!webcamTexture.isPlaying) {
      webcamTexture.Play();
    }
  }

  void OnClickPauseCam() {
    if (webcamTexture.isPlaying) {
      webcamTexture.Pause();
    }
  }

  void OnClickStopCam() {
    if (webcamTexture.isPlaying) {
      webcamTexture.Stop();
    }
  }

  void OnDisable() {
    SceneController.OnClickPlayCamEvent -= OnClickPlayCam;
    SceneController.OnClickPauseCamEvent -= OnClickPauseCam;
    SceneController.OnClickStopCamEvent -= OnClickStopCam;
  }
}
