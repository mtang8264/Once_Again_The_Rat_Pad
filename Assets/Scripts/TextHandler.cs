using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextHandler : MonoBehaviour
{
    public static TextHandler me;

    public TextAsset dialogue;
    public TextMeshPro text;
    public string[] dialogueStrings;
    public AudioClip[] vergilSqueaks;
    public AudioClip[] homerSqueaks;

    private Vector3 hiddenPos = new Vector3(0, -2.5f, 0);
    private Vector3 visiblePos = new Vector3(0, 0, 0);
    private Vector3 hiddenScale = new Vector3(0, 0, 0);
    private Vector3 visibleScale = new Vector3(1, 1, 1);
    public AnimationCurve positionCurve, scaleCurve;
    private float apperance;

    [Header("Behavior Controls")]
    public bool appear;
    public bool visible;
    public Speakers speaker;
    public int firstLine;
    public int lastLine;
    public int currentLine;
    public int lineLength;
    public int currentCharacter;
    public float waitTime;
    private float lastTime;
    public bool typing;
    public bool done;

    private void Awake()
    {
        if(me != null)
            Destroy(me.gameObject);
        me = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(dialogue.ToString());
        dialogueStrings = dialogue.text.Split('\n');
    }

    // Update is called once per frame
    void Update()
    {
        //Apperance animations and stuff
        if(appear && !visible)
        {
            apperance += Time.deltaTime * 2;

            transform.position = new Vector3(0, -2.5f + positionCurve.Evaluate(apperance));
            transform.localScale = Vector3.Lerp(hiddenScale, visibleScale, scaleCurve.Evaluate(apperance));

            if(apperance >= 1)
            {
                visible = true;
            }
        }
        else if(!appear && visible)
        {
            apperance -= Time.deltaTime * 2 ;

            transform.position = new Vector3(0, -2.5f + positionCurve.Evaluate(apperance));
            transform.localScale = Vector3.Lerp(hiddenScale, visibleScale, scaleCurve.Evaluate(apperance));

            if (apperance <= 0)
            {
                visible = false;
            }
        }

        //Text setting
        if (!visible)
        {
            text.text = "";
        }
        else
        {
            text.text = dialogueStrings[currentLine - 1].Substring(0, currentCharacter);
            if (Time.time > lastTime + waitTime && typing)
            {
                lastTime = Time.time;
                currentCharacter++;
                MusicManager.me.SendMessage("Squeak");
                if (currentCharacter > dialogueStrings[currentLine - 1].Length)
                {
                    currentCharacter--;
                    typing = false;
                }
            }
            else if(!typing)
            {
                text.text = dialogueStrings[currentLine - 1];
            }

            if(dialogueStrings[currentLine-1][0] == 'V')
            {
                speaker = Speakers.VERGIL;
            }
            else if(dialogueStrings[currentLine-1][0] == 'H')
            {
                speaker = Speakers.HOMER;
            }
            else if (dialogueStrings[currentLine - 1][0] == '*')
            {
                speaker = Speakers.DUCK;
            }
        }
    }

    public void Show()
    {
        appear = true;
    }
    public void Hide()
    {
        appear = false;
    }

    public void Next()
    {
        if (visible)
        {
            if (typing)
            {
                typing = false;
            }
            else
            {
                if (currentLine < lastLine)
                {
                    currentLine++;
                    currentCharacter = 0;
                    typing = true;
                }
                else
                {
                    done = true;
                    appear = false;
                }
            }
        }
    }

    public void OnMouseDown()
    {
        Next();
    }
    public void Go(int first, int last)
    {
        firstLine = first;
        lastLine = last;
        typing = true;
        Show();
        currentLine = first;
        currentCharacter = 0;
    }

    public enum Speakers { VERGIL, HOMER, DUCK, NONE };
}
