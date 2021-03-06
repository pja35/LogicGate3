﻿using System;
using UnityEngine;

/// <summary>
/// Permet de dupliquer un objet et de dragger l'objet cree.
/// </summary>
public class DraggerInstantiater : MonoBehaviour
{
    /// <summary>
    /// La porte nouvellement crée
    /// </summary>
    public GameObject cloned = null;

    /// <summary>
    /// Clone l'objet et rend le clone déplacable.
    /// </summary>
    public void OnMouseDown()
    {
        try
        {
            CloneObject();
            DragGameObject();
        }
        catch (NullReferenceException)
        {
            Debug.Log("Aucun objet à cloné n'as été donné à " + gameObject.name);
        }

    }

    private void CloneObject()
    {
        //Crée un clone de l'ojet qui ne pourra pas se dupliquer et que l'on va dragger
        cloned = Instantiate(gameObject);
        cloned.transform.SetParent(gameObject.transform.parent);
        cloned.transform.localScale = gameObject.transform.localScale;
    }

    private void DragGameObject()
    {
        cloned.AddComponent<Dragger>();

        //Emule le mouse down du drag mais avec un distance recalculée.
        cloned.GetComponent<Dragger>().mouseDown = true;
        cloned.GetComponent<Dragger>().initialObjMouseDistance = gameObject.transform.position
            - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    /// <summary>
    /// Dépose l'objet et détruit ce script.
    /// </summary>
    public void OnMouseUp()
    {
        cloned.GetComponent<Dragger>().OnMouseUp();
        Destroy(cloned.GetComponent<DraggerInstantiater>());
    }

}
