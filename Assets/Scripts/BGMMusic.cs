using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMMusic : MonoBehaviour
{
    private void Awake()
    {
        if(FindObjectsOfType<BGMMusic>().Length>1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
