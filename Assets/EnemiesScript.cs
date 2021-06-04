using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesScript : MonoBehaviour
{
    public Animator _animator;
    public CharacterController _charactercontroller;
    public Transform PlayerTransform;
    public float movespeed;
    public enum Animations { Idle, Run, Hit };
    public Animations _animations;
    public bool Isdead;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Variables.StartGame == true)
        {

            if (Isdead == false)
            {
                Vector3 dir = PlayerTransform.position - transform.position;
                float dist = dir.magnitude;
                Debug.Log(dist);
                if (dist > 1.3f)
                {
                    AnimationController(Animations.Run);
                    Vector3 movedirection = new Vector3(0, 0.5f, 0);
                    movedirection = transform.TransformDirection(Vector3.up) * movespeed;
                    _charactercontroller.Move(movedirection.normalized * 0.05f);
                }
                else
                {
                    AnimationController(Animations.Hit);
                }
            }
        }
    }
    void AnimationController(Animations _anim)
    {
        if (_anim == Animations.Idle)
        {
            _animator.SetBool("Run", false);
        }
        else if (_anim == Animations.Run)
        {
            _animator.SetBool(Animations.Run.ToString(), true);

        }
        else if (_anim == Animations.Hit)
        {
            _animator.SetBool(Animations.Hit.ToString(), true);

        }
    }
}
