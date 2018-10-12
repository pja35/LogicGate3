﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveParam : MonoBehaviour
{



    public void save_parameters()
    {
        Debug.Log("Saving Parameters");
        ParametersLoader loader = (ParametersLoader)GameObject.FindGameObjectsWithTag("Parameters")[0].GetComponent(typeof(ParametersLoader));
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/parameters.gd");
        Debug.Log("test = " + loader.parameters.music_volume + " " + loader.parameters.snooze);
        bf.Serialize(file, loader.parameters);
        file.Close();
    }
}
