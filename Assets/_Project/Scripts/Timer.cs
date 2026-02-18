using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] private UnityEvent<float> _onTimeChange;
    [SerializeField] private UnityEvent _onTimeEnd;

    [SerializeField] private float _timerDuration = 60f;

    public float TimerLeft { get; private set; }

    private void Start()
    {
        StartTimer(_timerDuration);
    }

    public void StartTimer(float duration)
    {
        TimerLeft = duration;
    }

    private void UpdateTimer()
    {
        if (TimerLeft <= 0f) return;

        TimerLeft -= Time.deltaTime;
        _onTimeChange.Invoke(TimerLeft);

        if(TimerLeft <= 0f)
        {
            TimerLeft = 0f;
            _onTimeEnd.Invoke();
        }
    }
    private void Update()
    {
        UpdateTimer();
    }
}
