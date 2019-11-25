﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float cameraMoveSpeed;

    bool moveCam;

    private void Awake()
    {
        moveCam = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        //print("colliding with " + other.tag + ", moveCam = " + moveCam);

        if (moveCam && other.tag != "Untagged")
        {
            switch (other.tag)
            {
                case "NorthDoor":
                    Vector3 NorthTarget = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z + 32);
                    Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, NorthTarget, cameraMoveSpeed/* * Time.deltaTime*/);
                    break;
                case "EastDoor":
                    Vector3 EastTarget = new Vector3(Camera.main.transform.position.x + 32, Camera.main.transform.position.y, Camera.main.transform.position.z);
                    Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, EastTarget, cameraMoveSpeed/* * Time.deltaTime*/);
                    break;
                case "SouthDoor":
                    Vector3 SouthTarget = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z - 32);
                    Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, SouthTarget, cameraMoveSpeed/* * Time.deltaTime*/);
                    break;
                case "WestDoor":
                    Vector3 WestTarget = new Vector3(Camera.main.transform.position.x - 32, Camera.main.transform.position.y, Camera.main.transform.position.z);
                    Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, WestTarget, cameraMoveSpeed/* * Time.deltaTime*/);
                    break;
            }
            moveCam = false;

            Invoke("EnableMoveCam", 5f);
        }
    }

    void EnableMoveCam()
    {
        print("ready to move cam");
        moveCam = true;
    }
}