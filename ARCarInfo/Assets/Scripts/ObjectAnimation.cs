using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ObjectAnimation : MonoBehaviour
{
    [SerializeField]
    private string boolName;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void StartAnimation() {
        _animator.SetBool(boolName, true);
    }

    public void StopAnimation() {
        _animator.SetBool(boolName, false);
    }

}
