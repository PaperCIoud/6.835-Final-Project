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

    public float angleGive = 70;

    public float curTestAngle = 180;

    public UserCalibration userCal;

    private Matrix4x4 rotate90 = new Matrix4x4(
			new Vector4(1, 0, 0, 0),
			new Vector4(0, 0, -1, 0),
			new Vector4(0, -1, 0, 0),
			new Vector4(0, 0, 0, -1)
			);

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

        curTestAngle = (userCal != null)? userCal.curTestAngle : curTestAngle;

        if (!isInverted && Mathf.Abs(curTestAngle) < angleGive) { //is in range where hands should probs be flipped [-70, 70]
            flipDeviceOri();
        }
        else if (isInverted && Mathf.Abs(curTestAngle) > 180 - angleGive) { //is in range where hands should probs be flipped [-180, -110] and [110, 180]
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
        transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1, 1, -1));
        // transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y + 180, transform.eulerAngles.z);
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
