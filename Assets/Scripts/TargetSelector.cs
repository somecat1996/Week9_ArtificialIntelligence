using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSelector : MonoBehaviour
{
    public enum Mode
    {
        Closest,
        Furthest
    }

    public Mode mode = Mode.Closest;

    private List<Transform> targets = new List<Transform>();

    public Transform Target
    {
        get
        {
            Transform target = null;
            if (targets.Count > 0)
            {
                switch (mode)
                {
                    case Mode.Closest:
                        // find closest transform
                        float minDistance = float.MaxValue;
                        foreach (Transform t in targets)
                        {
                            float currentDistance = (t.position - transform.position).magnitude;
                            if (currentDistance < minDistance)
                            {
                                target = t;
                                minDistance = currentDistance;
                            }
                        }
                        break;
                    case Mode.Furthest:
                        // find furthest transform
                        float maxDistance = float.MaxValue;
                        foreach (Transform t in targets)
                        {
                            float currentDistance = (t.position - transform.position).magnitude;
                            if (currentDistance > maxDistance)
                            {
                                target = t;
                                maxDistance = currentDistance;
                            }
                        }
                        break;
                }
            }

            return target;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        targets.Add(other.transform);
    }

    private void OnTriggerExit(Collider other)
    {
        targets.Remove(other.transform);
    }
}
