using UnityEngine;

public class EnemyNavMesh : MonoBehaviour
{
    public Transform target;
    [Space(5)]
    [Header("Detection Variable")]
    [SerializeField] float distanceDetection;
    [SerializeField] float AmplitudVision;

    string tagTarget;
    [Space(5)]
    [Header("States")]
    [SerializeField] MonoBehaviour stadoPatrullar;
    [SerializeField] MonoBehaviour stadoPerseguir;


    private void Awake()
    {
        tagTarget = target.tag;
    }

    void Update()
    {
        if (OnVision())
        {
            stadoPatrullar.enabled = false;
            stadoPerseguir.enabled = true;
        }
        else
        {
            stadoPatrullar.enabled = true;
            stadoPerseguir.enabled = false;
        }
    }

    private bool OnVision()
    {
        if (target != null)
        {
            if (Vector3.Distance(transform.position,target.position) < distanceDetection)
            {
                Vector3 dir = target.position - transform.position;
                dir.Normalize();

                float dot = Vector3.Dot(transform.forward, dir);

                if (dot >= -AmplitudVision && dot <= AmplitudVision)
                {
                    RaycastHit hit;
                    Physics.Raycast(transform.position, dir, out hit);

                    if (hit.transform.CompareTag(tagTarget))
                    {
                        return true;
                    }
                }
            } 
        }
        return false;
    }
}
