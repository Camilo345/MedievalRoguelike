using UnityEngine;

public class FollowBone : MonoBehaviour
{
    [SerializeField] private Transform target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        transform.parent = target;
        transform.localPosition = Vector3.zero;
        transform.localRotation = new Quaternion(0,0,0,0);
    }
}
