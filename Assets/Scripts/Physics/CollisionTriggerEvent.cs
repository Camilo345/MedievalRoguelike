using System;
using UnityEngine;

public class CollisionTriggerEvent : MonoBehaviour
{
    [SerializeField] private string targetTag;

    private bool _canDetect;
    private Collider _collider;

    public Action<Collider> OnTriggerEntered;
    public Action<Collider> OnTriggerExited;

    public bool CanDetect 
    {
        get
        {
            return _canDetect;
        }
        set 
        {
            _canDetect = value;
            ChangeColliderState(CanDetect);
        }
    }


    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _collider.enabled = false;
        CanDetect = false;
    }


    public void ChangeColliderState(bool state)
    {
        _collider.enabled = state;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(targetTag) || !CanDetect) return;
        OnTriggerEntered?.Invoke(other);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag(targetTag) || !CanDetect) return;

        OnTriggerExited?.Invoke(other);
    }

}
