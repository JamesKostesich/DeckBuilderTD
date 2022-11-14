using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSlots : MonoBehaviour
{
    public Camera cam;
    public GameObject[] slots;

    public float xStart;
    public float xOffset;

    private Vector3 handPlacement;

    private void Start()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            handPlacement = slots[i].transform.position;
            handPlacement.x = xStart + (xOffset * i);
            slots[i].transform.position = handPlacement;
        }
    }

    void Update()
    {
        float distance = transform.position.z - cam.transform.position.z;
        Vector3 position = new Vector3(2000, 500, distance+0.25f);
        position = cam.ScreenToWorldPoint(position);
        transform.position = position;
    }
}
