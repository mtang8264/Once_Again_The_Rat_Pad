using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScreenManager : MonoBehaviour
{
    private bool begun = false;
    private bool leaving = false;
    private bool done = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(TransitionHandler.instance.state == TransitionHandler.State.WAIT && !begun)
        {
            begun = true;
            TextHandler.me.Go(1, 13);
        }

        if (TextHandler.me.done && !leaving)
        {
            leaving = true;
            TextHandler.me.Hide();
        }

        if(TextHandler.me.visible == false && !done && leaving  )
        {
            done = true;
            TransitionHandler.instance.Go();
        }
    }
}
