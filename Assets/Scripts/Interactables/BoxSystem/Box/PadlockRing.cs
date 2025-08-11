using System;
using UnityEngine;

public class PadlockRing : MonoBehaviour
{
    private int ringValue;
    private float anglePerStep = 36f;
    private float offset = 216f;

    public int RingValue => ringValue;

    private void Awake()
    {
        ringValue = 0;
        transform.localRotation = Quaternion.Euler(offset, 0f, 0f);
    }

    public void Rotate(int direction)
    {
        ringValue = (ringValue + direction + 10) % 10;
        float angle = offset - ringValue * anglePerStep;
        transform.localRotation = Quaternion.Euler(angle, 0f, 0f);
    }

}