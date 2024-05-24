using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class LaserGun : MonoBehaviour
{

    //動畫
    [SerializeField] private Animator laserAnimator;
    //音效
    [SerializeField] private AudioClip laserSFX;

    private AudioSource laserAudioSource;

    //start之前觸發，觸發後再start:抓組件
    private void Awake()
    {
        laserAudioSource = GetComponent<AudioSource>();
    }
    //射線
    public void LeserGunFired()
    {
        //播放動畫
        laserAnimator.SetTrigger("Fire");
        //播放音效
        laserAudioSource.PlayOneShot(laserSFX);
        //射線
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider.gameObject.CompareTag("Asteroid"))
            {
                Destroy(hit.collider.gameObject);
            }
        }
    }
}
