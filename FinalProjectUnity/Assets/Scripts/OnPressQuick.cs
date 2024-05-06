using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;

public class OnPressQuick : MonoBehaviour
{

    public LeapServiceProvider lsp;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (lsp) lsp.setInversion(false);
            Debug.Log("is not flipped");
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            if (lsp) lsp.setInversion(true);
            Debug.Log("Is FLipped");
        }
    }
}
