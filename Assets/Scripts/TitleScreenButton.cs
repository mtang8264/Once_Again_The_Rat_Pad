using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenButton: MonoBehaviour
{
    public Action action;
    public Color defaultColor;
    public Color targetColor;
    public float speed;
    SpriteRenderer sprite;
    bool over;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(over)
        {
            sprite.color = Color.Lerp(sprite.color, targetColor, speed);
        }
        else
        {
            sprite.color = Color.Lerp(sprite.color, defaultColor, speed);
        }
    }

    private void OnMouseOver()
    {
        over = true;
    }
    private void OnMouseExit()
    {
        over = false;
    }

    private void OnMouseDown()
    {
        switch(action)
        {
            case Action.QUIT:
                Application.Quit();
                break;
            case Action.NEW_GAME:
                TransitionHandler.instance.Go();
                break;
        }
    }

    public enum Action { NEW_GAME, QUIT, CREDITS};
}
