﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NAND : Comportement
{
    //! Verifie que toutes les entrées ne sont pas vraies
    public override bool execute(Obj_Input[] inputs)
    {
        int len = inputs.Length;
        bool result = true;
        //Permet de vérifier si la porte est relier à au moins une autre porte.
        bool existingWiring = false;
        for (int i = 0; i < len; i++)
        {
            if (inputs[i].connection == null) { continue; }
            result = result && inputs[i].value;
            existingWiring = true;
        }
        return (existingWiring) ? !result : false;
    }
}