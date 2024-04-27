using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] VoidEventChannel levelClearedEventChannel;
    PlayerGroundDetector groundDetector;
    #region OLD METHOD
    //     Animator animator;
    //
    //   void Awake()
    //   {
    //      animator = GetComponentInChildren<Animator>();
    //   }
    // 
    //     void Update()
    //     {
    //         if(Keyboard.current.aKey.isPressed||Keyboard.current.dKey.isPressed)
    //         {
    //             animator.Play("Run");
    //         }
    //         else
    //         {
    //             animator.Play("Idle");
    //         }
    //     }
    #endregion

    PlayerInput input;

    public Rigidbody rigidBody;

    public AudioSource VoicePlayer { get; private set; }
    public bool Victory { get; set; }
    public bool CanAirJump { get; set; }
    public bool IsGround => groundDetector.IsGrounded;
    //public bool IsCoyo => groundDetector.IsCoyote;
    public bool IsFalling => rigidBody.velocity.y < 0 && !IsGround;
    public float MoveSpeed => Mathf.Abs(rigidBody.velocity.x);
    public bool isStun; 
    public CapsuleCollider capsuleCollider;

    void Awake()
    {
        groundDetector = GetComponentInChildren<PlayerGroundDetector>();
        input = GetComponent<PlayerInput>();
        rigidBody = GetComponent<Rigidbody>();
        VoicePlayer = GetComponentInChildren<AudioSource>();
        capsuleCollider = GetComponentInChildren<CapsuleCollider>();
    }

    void Start()
    {
        input.EnableGameplayInputs();
    }

    void OnEnable()
    {
        levelClearedEventChannel.AddListener(OnLevelCleared);
    }

    void OnDisable()
    {
        levelClearedEventChannel.RemoveListener(OnLevelCleared);
    }

    private void OnLevelCleared()
    {
        Victory = true;
    }

    public void Move(float speed)
    {
        if(input.Move)
        {
            transform.localScale = new Vector3(input.AxisX,1f,1f);
        }

        SetVelocityX(speed * input.AxisX);
    }




    public void SetVelocity(Vector3 velocity)
    {
        rigidBody.velocity = velocity;
    }

    public void SetVelocityX(float velocityX)
    {
        rigidBody.velocity = new Vector3(velocityX, rigidBody.velocity.y);
    }

    public void SetVelocityY(float velocityY)
    {
        rigidBody.velocity = new Vector3(rigidBody.velocity.x,velocityY);
    }    

    public void SetUseGravity(bool value)
    {
        rigidBody.useGravity = value;
    }

    public void OnDefeated()
    {
        input.DisableGameplayInputs();

        rigidBody.velocity = Vector3.zero;
        rigidBody.useGravity = false;
        rigidBody.detectCollisions = false;

        GetComponent<StateMachine>().SwitchState(typeof(PlayerState_Defeated));      
    }
}
