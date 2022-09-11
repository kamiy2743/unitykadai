using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyDetector : MonoBehaviour
{
    public UnityEvent OnDetect = new UnityEvent();

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<EnemyMover>(out var _))
        {
            OnDetect.Invoke();
        }
    }
}
