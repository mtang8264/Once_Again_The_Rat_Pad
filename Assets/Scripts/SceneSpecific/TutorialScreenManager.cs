using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScreenManager : MonoBehaviour
{
    private bool begun = false;
    private bool playing = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!begun && TransitionHandler.instance.state  == TransitionHandler.State.WAIT)
        {
            begun = true;
            TextHandler.me.Go(14, 15);
        }

        if(begun && TextHandler.me.visible == false && !playing)
        {

        }
    }
}
