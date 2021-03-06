﻿using Assets.Scripts;
using HoloToolkit.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoShip : SingletonCustom<DemoShip>
{
    public GameObject ship;
    public GameObject largeShip;

    void Start()
    {
        ship = GameObject.Find("Ship");
        largeShip = GameObject.Find("ShipLarge");

        largeShip.SetActive(false);
    }

    public void ActivateShip()
    {
        largeShip.SetActive(true);
        var devicePosition = Camera.main.transform.position;
        //Debug.Log(devicePosition);
        largeShip.transform.position = new Vector3(devicePosition.x, -2, devicePosition.z);
    }

    public void DeactivateShip()
    {
        largeShip.SetActive(false);
    }
}
