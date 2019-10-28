using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(Collider2D))]
public class SignalOnTouch : MonoBehaviour
{
    public UnityEvent onTouch;
    public bool playAudioOnTouch = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        SendSignal(collider.gameObject);
    }
    void SendSignal(GameObject objectThatHit)
    {
        if (objectThatHit.CompareTag("Player"))
        {
            if (playAudioOnTouch)
            {
                var audio = GetComponent<AudioSource>();
                if (audio && audio.gameObject.activeInHierarchy)
                    audio.Play();
            }
            onTouch.Invoke();
        }
    }
}

