using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class Player2DController : MonoBehaviour
{
    private KeywordRecognizer kwRec;
    //private GrammarRecognizer grammarRecognizer;
    private Dictionary<string, Action> action = new Dictionary<string, Action>();
    public Text Listening;
    public float addTurbo;
    public float MovementSpeed = 1f;
    public float JumpingForce = 1f;
    private int walk;
    private bool controlDisabled;
    [SerializeField]
    private bool SpeechMode;

    private bool isGrounded;
    private bool isJumping;
    private float maxYvel;
    //public float fallPositionY;

    Vector2 Move;
    private Rigidbody2D _rB;
    public SoundController sound;
    // Start is called before the first frame update
    void Start()
    {
        _rB = GetComponent<Rigidbody2D>();
        if(controlDisabled == false)
        {
            if (SpeechMode)
            {
                //test speech first
                action.Add("Are you here", Attention);
                action.Add("Are you here!", Attention);
                action.Add("Are you here?", Attention);
                action.Add("Are you here.", Attention);
                action.Add("Are you here,", Attention);

                //jump speech list
                action.Add("box jump", Jump);
                action.Add("box jump!", Jump);
                action.Add("box jump?", Jump);
                action.Add("box jump.", Jump);
                action.Add("jumping", Jump);
                action.Add("jumping!", Jump);
                action.Add("jumping?", Jump);
                action.Add("jumping.", Jump);
                action.Add("jumped", Jump);
                action.Add("jumped!", Jump);
                action.Add("jumped?", Jump);
                action.Add("jumped.", Jump);
                action.Add("go up", Jump);
                action.Add("go up!", Jump);
                action.Add("go up?", Jump);
                action.Add("go up.", Jump);



                //move front speech list
                action.Add("box go", isMove);
                action.Add("box go!", isMove);
                action.Add("box go?", isMove);
                action.Add("box go.", isMove);
                action.Add("go", isMove);
                action.Add("go!", isMove);
                action.Add("go?", isMove);
                action.Add("go.", isMove);
                action.Add("books go", isMove);
                action.Add("Run", isMove);
                action.Add("Walk", isMove);
                action.Add("Move Front", isMove);
                action.Add("Move Front!", isMove);
                action.Add("Move Front?", isMove);
                action.Add("Move Front.", isMove);
                action.Add("Forward", isMove);
                action.Add("Forwards", isMove);
                action.Add("Move Forward", isMove);
                action.Add("Move Forwards", isMove);
                action.Add("go Forward", isMove);

                //move back speech list
                action.Add("box reflect", isReversed);
                action.Add("box reflect!", isReversed);
                action.Add("box reflect?", isReversed);
                action.Add("box reflect.", isReversed);
                action.Add("back", isReversed);
                action.Add("back!", isReversed);
                action.Add("back?", isReversed);
                action.Add("back.", isReversed);
                action.Add("books reflect", isReversed);
                action.Add("books back", isReversed);
                action.Add("Move Back", isReversed);
                action.Add("Move Back!", isReversed);
                action.Add("Move Back?", isReversed);
                action.Add("Move Back.", isReversed);
                action.Add("Backward", isReversed);
                action.Add("Backwards", isReversed);
                action.Add("Move Backward", isReversed);
                action.Add("go Backward", isReversed);

                //stop speech list
                action.Add("box stop", isStop);
                action.Add("box stop!", isStop);
                action.Add("box stop?", isStop);
                action.Add("box stop.", isStop);
                action.Add("stop", isStop);
                action.Add("stop!", isStop);
                action.Add("stop?", isStop);
                action.Add("stop.", isStop);
                action.Add("stopped", isStop);
                action.Add("stopped!", isStop);
                action.Add("stopped?", isStop);
                action.Add("stopped.", isStop);
                action.Add("books stop", isStop);


                //combination speech list
                //action.Add("go and jump", goJump);
                //action.Add("go and jump!", goJump);
                //action.Add("go and jump?", goJump);
                //action.Add("go and jump.", goJump);

                //state speed speech
                action.Add("turbo speed", isTurbo);
                action.Add("turbo speed!", isTurbo);
                action.Add("turbo speed?", isTurbo);
                action.Add("turbo speed.", isTurbo);
                action.Add("normal speed", isNormal);
                action.Add("normal speed!", isNormal);
                action.Add("normal speed?", isNormal);
                action.Add("normal speed.", isNormal);



                kwRec = new KeywordRecognizer(action.Keys.ToArray());
                kwRec.OnPhraseRecognized += RecognizedSpeech;
                kwRec.Start();


            }
            else
            {
                //if not on speech mode you can add script for normal mode here.
            }
        }
        
        
    }
    
    private void FixedUpdate()
    {
        _rB.velocity = new Vector2(Move.x * (MovementSpeed * 10 + addTurbo)  * Time.deltaTime, _rB.velocity.y);
    }
    
    // Update is called once per frame
    void Update()
    {
        if(controlDisabled == false)
        {
            //Debug.Log(_rB.velocity.y);
            if (SpeechMode)
            {
                if (walk == 0)
                {
                    Move = new Vector2(0, 0);
                }
                else if (walk == 1)
                {
                    Move = new Vector2(1, 0);
                }
                else if (walk == -1)
                {
                    Move = new Vector2(-1, 0);
                }
                else
                {
                    Debug.LogError("Error : Invalid input!");
                }
            }
            else
            {
                if (Input.GetButtonDown("Jump"))
                {
                    Jump();
                }

                Move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
                isJumping = false;
            }
        }
        

    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        
        //Fixing Output
        if ((speech.text == "box go!") || (speech.text == "box go?") || (speech.text == "box go.") || (speech.text == "books go"))
        {
            Listening.text = "box go";
        }
        else if ((speech.text == "box stop!") || (speech.text == "box stop?") || (speech.text == "box stop.") || (speech.text == "books stop"))
        {
            Listening.text = "box stop";
        }
        else if ((speech.text == "box reflect!") || (speech.text == "box reflect?") || (speech.text == "box reflect.") || (speech.text == "books reflect"))
        {
            Listening.text = "box reflect";
        }
        else if ((speech.text == "box jump!") || (speech.text == "box jump?") || (speech.text == "box jump.") || (speech.text == "books jump"))
        {
            Listening.text = "box jump";
        }
        else
        {
            Listening.text = speech.text;
        }

        action[speech.text].Invoke();
    }
    private void Attention()
    {
        
    }

    public void Speechmode(bool s) 
    {
        if(s == true)
        {
            SpeechMode = true;
        }
        else
        {
            SpeechMode = false;
        }
    }

    public void ctrlDisabled(bool dis)
    {
        if(dis == false)
        {
            controlDisabled = false;
        }
        else
        {
            controlDisabled = true;
            Move = new Vector2(0,0);
        }
    }
    public void isMove()
    {
        walk = 1;
        isJumping = false;
    }
    public void isTurbo()
    {
        addTurbo = 100f;
    }
    public void isNormal()
    {
        addTurbo = 0f;
    }
    public void isStop()
    {
        walk = 0;
        addTurbo = 0f;
        isJumping = false;
    }
    public void isReversed()
    {
        walk = -1;
        isJumping = false;
    }
    public void Jump()
    {
        if ( Mathf.Abs(_rB.velocity.y) < 0.001f)
        {
            isJumping = true;
            _rB.AddForce(new Vector2(0, JumpingForce), ForceMode2D.Impulse);
        }
    }
}
