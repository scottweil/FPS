using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BazierCurve : MonoBehaviour
{
    public Transform[] p;
    LineRenderer lr;
    public int maxPosition = 20;
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }
    void Update()
    {
        lr.positionCount = maxPosition;
        for (int i = 0; i < lr.positionCount; i++)
        {
            float t = (float)i / (maxPosition - 1);
            Vector3 pos = GetCurvePosition(p[0].position, p[1].position, p[2].position, t);
            lr.SetPosition(i, pos);
        }
        Vector3 GetCurvePosition(Vector3 a, Vector3 b, Vector3 c, float t)
        {
            Vector3 ab = Vector3.Lerp(a, b, t);
            Vector3 bc = Vector3.Lerp(b, c, t);

            return Vector3.Lerp(ab, bc, t);
        }
    }
}
