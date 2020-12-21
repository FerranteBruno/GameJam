using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFx : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource Vape;

    public void PlayVape()
    {
        Vape.Play();
    }

}
