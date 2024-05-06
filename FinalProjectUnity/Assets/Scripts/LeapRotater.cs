using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LeapRotater : MonoBehaviour
{

    public Camera camera;
    private string pathRoot = "C:/ProgramData/Ultraleap/TouchFree/Configuration/";
    public string inverterPath = "ConfigInverted.json";
    public string normalPath = "ConfigNormal.json";
    public string savePath = "TrackingConfig.json";

    public string invertVal = "";
    public string normalVal = "";
    public bool isInverted = false;

    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log("is new version");
        ReadString(pathRoot + normalPath, ref normalVal);
        ReadString(pathRoot + inverterPath, ref invertVal);
        isInverted = false;
        WriteString(pathRoot + savePath, normalVal);


    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, camera.transform.eulerAngles.y + 25, transform.eulerAngles.z);

        if (Input.GetKeyDown(KeyCode.Space)) {
            flipDeviceOri();
        }

    }

    void flipDeviceOri(){
        if (isInverted) { //make normal
            WriteString(pathRoot + savePath, normalVal);
        }
        else {
            WriteString(pathRoot + savePath, invertVal);
        }

        isInverted = !isInverted;
    }

    void ReadString(string path, ref string saveLoc, bool print = false){
        // Debug.Log(path);
        StreamReader reader = new StreamReader(path);
        saveLoc = reader.ReadToEnd();
        if (print) Debug.Log(saveLoc);
        reader.Close();
    }

    void WriteString(string path, string value) {
        StreamWriter writer = new StreamWriter(path, false);
        writer.Write(value);
        writer.Close();
    }


}
