using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TransitionHandler : MonoBehaviour
{
    public static TransitionHandler instance;
    Image fade;
    public int goalScene;
    public float timeIn, timeOut;
    public State state;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(instance);
        instance = this;

        fade = GameObject.FindWithTag("Fade").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(state == State.IN)
        {
            fade.color = new Color(0, 0, 0, fade.color.a - Time.deltaTime / timeIn);
        }
        if(state == State.OUT)
        {
            fade.color = new Color(0, 0, 0, fade.color.a + Time.deltaTime / timeOut);
        }
        
        if(fade.color.a <= 0 && state == State.IN)
        {
            state = State.WAIT;
        }
        if(fade.color.a > 1 && state == State.OUT)
        {
            SceneManager.LoadScene(goalScene);
        }
    }

    public void Go()
    {
        state = State.OUT;
    }

    public enum State { IN, WAIT, OUT};
}
