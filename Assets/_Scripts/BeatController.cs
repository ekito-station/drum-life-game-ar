using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BeatController : MonoBehaviour
{
    public UnityEvent noteEvent = new UnityEvent();
    public NoteController[] notes;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayNotes()
    {
        noteEvent.Invoke();
    }
}
