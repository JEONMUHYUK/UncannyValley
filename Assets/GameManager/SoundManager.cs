using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //Singleton
    #region Singleton

    static private SoundManager instance;
    static public SoundManager Inst
    {
        get
        {
            if(instance == null)
                instance = FindObjectOfType<SoundManager>();
            if (instance == null)
                instance = new SoundManager();
            return instance;
        }
    }
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
