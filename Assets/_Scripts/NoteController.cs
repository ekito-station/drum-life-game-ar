using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    public LifeGameManager lifeGameManager;
    public MeshRenderer meshRenderer;
    public AudioSource audioSource;
    public LifeGameManager.SOUND_TYPE soundType;

    [System.NonSerialized]
    public bool isPlayed = false;
    [System.NonSerialized]
    public int count = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MainCamera" && !lifeGameManager.isStarted)
        {
            if (isPlayed)
            {
                meshRenderer.material = lifeGameManager.black;
                isPlayed = false;
            }
            else
            {
                meshRenderer.material = lifeGameManager.white;
                isPlayed = true;
                PlayNote();
            }
        }
    }

    public void PlayNote()
    {
        if (isPlayed)
        {
            // 音を鳴らす
            switch (soundType)
            {
                case LifeGameManager.SOUND_TYPE.CLAVE:
                    audioSource.PlayOneShot(lifeGameManager.clave);
                    break;
                case LifeGameManager.SOUND_TYPE.RIDE_IN:
                    audioSource.PlayOneShot(lifeGameManager.ride_in);
                    break;
                case LifeGameManager.SOUND_TYPE.CRASH_RIGHT:
                    audioSource.PlayOneShot(lifeGameManager.crash_right);
                    break;
                case LifeGameManager.SOUND_TYPE.HI_TOM:
                    audioSource.PlayOneShot(lifeGameManager.hi_tom);
                    break;
                case LifeGameManager.SOUND_TYPE.LOW_TOM:
                    audioSource.PlayOneShot(lifeGameManager.low_tom);
                    break;
                case LifeGameManager.SOUND_TYPE.HI_HAT_OPEN:
                    audioSource.PlayOneShot(lifeGameManager.hi_hat_open);
                    break;
                case LifeGameManager.SOUND_TYPE.HI_HAT_CLOSED:
                    audioSource.PlayOneShot(lifeGameManager.hi_hat_closed);
                    break;
                case LifeGameManager.SOUND_TYPE.SNARE:
                    audioSource.PlayOneShot(lifeGameManager.snare);
                    break;
                case LifeGameManager.SOUND_TYPE.KICK:
                    audioSource.PlayOneShot(lifeGameManager.kick);
                    break;
            }
            // 色を変える
            meshRenderer.material = lifeGameManager.beige;
        }
        else
        {
            // 色を変える
            meshRenderer.material = lifeGameManager.brown;
        }
        Invoke("ReturnColor", lifeGameManager.waitSec);
    }

    private void ReturnColor()
    {
        if (isPlayed)
        {
            meshRenderer.material = lifeGameManager.white;
        }
        else
        {
            meshRenderer.material = lifeGameManager.black;
        }
    }
}
