using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerMovement : MonoBehaviour
{
    public CharacterController _charactercontroller;
    public Animator _animator;
    public enum Animations {Idle,Run,Shoot};
    public Animations _animations;
    Vector3 MoveDirection;
    public float movespeed;
    public float steps;
    public float moveXlimit;
    public GameObject ChildPlayerObj;
    public List<GameObject> Childplayer;
    public bool[] PlayerPlace;

    void Start()
    {
        
    }

    // Update is called once per frame
    void  FixedUpdate()
    {
        if (Variables.StartGame == true)
        {
            float movex = Input.GetAxisRaw("Horizontal");
            MoveDirection = new Vector3(movex, steps, 0);
            MoveDirection.x = Mathf.Clamp(MoveDirection.x, -moveXlimit, moveXlimit);
            MoveDirection *= movespeed;
            _charactercontroller.Move(MoveDirection);
            Vector3 Clampdir = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
            Clampdir.x = Mathf.Clamp(Clampdir.x, -moveXlimit, moveXlimit);
            transform.position = Clampdir;
            AnimationController(Animations.Run);
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
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Count")
        {
            Destroy(other.gameObject);
            ChildActivation(other.gameObject);
        }
    }

    public void ChildActivation(GameObject obj)
    {
        for (int i = 0; i < obj.GetComponent<Count>().CountNumber; i++)
        {
            GameObject _obj = Instantiate(ChildPlayerObj);
            _obj.transform.SetParent(transform);
            Childplayer.Add(_obj);
        }
    } 
}
