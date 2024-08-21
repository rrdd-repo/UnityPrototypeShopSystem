using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    // Character's movement speed
    [SerializeField]
    private float _movSpeed;

    private Rigidbody2D _rb;
    private Animator _anim;

    // Saves original character scale
    private Vector2 _characterScale;

    // The vector for the inputs made by the player
    private Vector2 _movInput;

    // Bool to stop movement in shop
    public bool canMove = true;

    //Hashing animations for performance
    private static readonly int Idle = Animator.StringToHash("Idle");
    private static readonly int Walk = Animator.StringToHash("Walk");

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _characterScale = transform.localScale;
        canMove = true;
    }

    private void Update()
    {
        // Quit the game button
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();

        if (canMove)
        {
            MoveInput();
            //Flips character!
            Flip();

            //Checks which state the animation is in and sets which animation that's gonna play
            var state = AnimateState();
            _anim.CrossFade(state, 0, 0);
        }
        else _anim.CrossFade("Idle", 0, 0);

    }

    private void FixedUpdate()
    {
        // Character movement
        _rb.velocity = canMove ? _movInput * _movSpeed : Vector2.zero;
    }

    private void MoveInput()
    {
        // Player's input
        float dirX = Input.GetAxisRaw("Horizontal");
        float dirY = Input.GetAxisRaw("Vertical");

        // Normalize input values for any controller
        _movInput = new Vector2(dirX, dirY).normalized;

    }

    int AnimateState()
    {
        // Will check whether player is moving or not for the walk animation
        return _movInput == Vector2.zero ? Idle : Walk;

    }

    void Flip()
    {
        // Flips character
        if (_movInput.x > 0) transform.localScale = new Vector2(_characterScale.x, _characterScale.y); 
        else if(_movInput.x < 0) transform.localScale = new Vector2(-_characterScale.x, _characterScale.y);
    }


    public Vector2 GetInput()
    {
        return _movInput;
    }

    public void SetInput(bool move)
    {
        canMove = move;
    }
}
