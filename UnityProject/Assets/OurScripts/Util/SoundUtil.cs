﻿using UnityEngine;

/// <summary>
/// Un ensemble de méthodes pour jouer des sons
/// </summary>
public class SoundUtil : MonoBehaviour
{
    /// <summary>
    /// Joue un son une fois
    /// </summary>
    /// <param name="soundName">Le nom du son à charger et jouer.</param>
    public static void PlaySound(string soundName)
    {
        //On récupère le haut parleur normalement attaché à toutes les scènes.
        GameObject speaker = GameObject.FindGameObjectWithTag("Speaker");
        if (speaker == null) return;

        AudioSource source = speaker.GetComponent<AudioSource>();
        if (source != null)
        {
            AudioClip clip = (AudioClip)Resources.Load(soundName);
            source.PlayOneShot(clip);
        }
    }

    /// <summary>
    /// Remplace le son en fond par un nouveau clip
    /// </summary>
    /// <param name="soundName">Le nom du son à charger et jouer.</param>
    public static void PlayOnlySound(string soundName)
    {
        //On récupère le haut parleur normalement attaché à toutes les scènes.
        GameObject speaker = GameObject.FindGameObjectWithTag("Speaker");
        if (speaker == null) return;

        AudioSource source = speaker.GetComponent<AudioSource>();
        string newsound = soundName.Remove(0, 7);
       
        if (source != null && (source.clip.name!=newsound))
        {
            
            source.clip = (AudioClip)Resources.Load(soundName);
            source.Play();

        }
    }
}
