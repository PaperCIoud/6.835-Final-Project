using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserCalibration : MonoBehaviour
{
    public CubemanController cubemanController;
    public Transform headTransform;

    public Vector3 tPosePos;
    public Vector3 leftPos;
    public Vector3 rightPos;
    public Vector3 backPos;
    public Vector3 downPos;

    private int numClicks;
    //radial distance in x z plane from tablet
    public  Vector2 tabletCenter2D;
    private float heighFromTablet;

    public float offsetAngle;

    public float curTestAngle;



    // Start is called before the first frame update
    void Start()
    {
        numClicks = 0;
        tabletCenter2D = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            switch (numClicks)
            {
                case 0: tPosePos = headTransform.position; var test1 = GameObject.CreatePrimitive(PrimitiveType.Sphere); test1.transform.position = headTransform.position; test1.transform.localScale = Vector3.one * 0.08f; break;
                case 1: downPos = headTransform.position; test1 = GameObject.CreatePrimitive(PrimitiveType.Sphere); test1.transform.position = headTransform.position;test1.transform.localScale = Vector3.one * 0.08f;break;
                case 2: leftPos = headTransform.position; test1 = GameObject.CreatePrimitive(PrimitiveType.Sphere); test1.transform.position = headTransform.position;test1.transform.localScale = Vector3.one * 0.08f;break;
                case 3: backPos = headTransform.position; test1 = GameObject.CreatePrimitive(PrimitiveType.Sphere); test1.transform.position = headTransform.position;test1.transform.localScale = Vector3.one * 0.08f;break;
                case 4: rightPos = headTransform.position; test1 = GameObject.CreatePrimitive(PrimitiveType.Sphere); test1.transform.position = headTransform.position;test1.transform.localScale = Vector3.one * 0.08f;break;
                default: break;
            }
            Debug.Log("num clicks: " + numClicks + " headPos: " + headTransform.position);

            numClicks += 1;
        }

        if (numClicks == 5)
        {

            heighFromTablet = tPosePos.y - downPos.y;

            tabletCenter2D = LineIntersection(
                new Vector2(tPosePos.x, tPosePos.z),
                new Vector2(backPos.x, backPos.z),
                new Vector2(leftPos.x, leftPos.z),
                new Vector2(rightPos.x, rightPos.z)
            );
            Debug.Log("Center: " + tabletCenter2D);

            cubemanController.initialPosition = new Vector3(cubemanController.initialPosition.x-tabletCenter2D.x, cubemanController.initialPosition.y + 0.0f, cubemanController.initialPosition.z-tabletCenter2D.y);

            numClicks ++;
        }

        curTestAngle = Mathf.Atan2(headTransform.position.x - tabletCenter2D.x, headTransform.position.z - tabletCenter2D.y) * 180 / Mathf.PI;


    }


    public Vector2 LineIntersection(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4)
    {

        float Ax, Bx, Cx, Ay, By, Cy, d, e, f, num/*,offset*/;
        float x1lo, x1hi, y1lo, y1hi;

        Ax = p2.x - p1.x;
        Bx = p3.x - p4.x;

        // X bound box test/
        if (Ax < 0) {
            x1lo = p2.x;
            x1hi = p1.x;
        }
        else {
            x1hi = p2.x;
            x1lo = p1.x;
        }

        if (Bx > 0) {
            // if (x1hi < p4.x || p3.x < x1lo) return null;
        }
        else
        {
            // if (x1hi < p3.x || p4.x < x1lo) return null;
        }

        Ay = p2.y - p1.y;
        By = p3.y - p4.y;

        // Y bound box test//
        if (Ay < 0) {
            y1lo = p2.y;
            y1hi = p1.y;
        }
        else {
            y1hi = p2.y;
            y1lo = p1.y;
        }

        if (By > 0) {
            // if (y1hi < p4.y || p3.y < y1lo) return null;
        }
        else
        {
            // if (y1hi < p3.y || p4.y < y1lo) return null;
        }

        Cx = p1.x - p3.x;
        Cy = p1.y - p3.y;
        d = By * Cx - Bx * Cy;  // alpha numerator//
        f = Ay * Bx - Ax * By;  // both denominator//

        // alpha tests//
        if (f > 0)
        {
            // if (d < 0 || d > f) return null;
        }
        else
        {
            // if (d > 0 || d < f) return null;
        }

        e = Ax * Cy - Ay * Cx;  // beta numerator//

        // beta tests //
        if (f > 0)
        {
            // if (e < 0 || e > f) return null;
        }
        else
        {
            // if (e > 0 || e < f) return null;
        }

        // check if they are parallel
        if (f == 0) return Vector2.zero;
        // compute intersection coordinates //
        num = d * Ax; // numerator //
        //    offset = same_sign(num,f) ? f*0.5f : -f*0.5f;   // round direction //
        //    intersection.x = p1.x + (num+offset) / f;
        Vector2 intersection = Vector2.zero;
        intersection.x = p1.x + num / f;

        num = d * Ay;
        //    offset = same_sign(num,f) ? f*0.5f : -f*0.5f;
        //    intersection.y = p1.y + (num+offset) / f;
        intersection.y = p1.y + num / f;

        return intersection;

    }
}
