using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSize : MonoBehaviour
{
    public bool testing;
    public CameraPreset[] cameraPresets;
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(testing)
        {
            Debug.Log(cam.aspect);
        }

        for(int i = 0; i < cameraPresets.Length; i ++)
        {
            if(cam.aspect > cameraPresets[i].cameraAspect - cameraPresets[i].allowance &&
                cam.aspect < cameraPresets[i].cameraAspect + cameraPresets[i].allowance)
            {
                cam.orthographicSize = cameraPresets[i].orthoSize;
                break;
            }
        }
    }
}

[System.Serializable]
public class CameraPreset
{
    public string name;
    public float cameraAspect;
    public float allowance;
    public float orthoSize;
}