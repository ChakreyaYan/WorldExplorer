﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VMGBuilding : MonoBehaviour
{
    /// <summary>
    /// The data of a VMG Building.
    /// </summary>

    public string id;
    public List<Vector2> latLonList = new List<Vector2>();
    public float height;
    public float aoo; // Angle of orientation.

    public VMGBuilding(string id, List<Vector2> latLonList, float height, float aoo)
    {
        this.id = id;
        this.latLonList = latLonList;
        this.height = height;
        this.aoo = aoo;
    }
}
