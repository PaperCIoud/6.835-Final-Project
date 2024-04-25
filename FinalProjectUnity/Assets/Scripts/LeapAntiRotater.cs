using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeapAntiRotater : MonoBehaviour
{

    public Transform parentRotater;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.Euler(transform.eulerAngles.x, -parentRotater.eulerAngles.y, transform.eulerAngles.z);
    }
}
