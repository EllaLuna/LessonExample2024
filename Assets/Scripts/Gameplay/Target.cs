using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] TargetSO targetInfo;
    [SerializeField] float timeToDestroy = 0.1f;
    bool collided = false;
    private ScoreChannel scoreChannel;
    public static Action<int, string> UpdateScore;

    private void Start()
    {
        var beacon = FindObjectOfType<Beacon>();
        scoreChannel = beacon.scoreChannel;

        GetComponent<SpriteRenderer>().sprite = targetInfo.sprite;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (collided)
            return;
        if(other.gameObject.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().color = Color.green;
            scoreChannel.InvokeUpdateScore(targetInfo.reward, targetInfo.name);
            StartCoroutine(WaitToDestory());
        }
        if(other.gameObject.CompareTag("Floor"))
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            scoreChannel.InvokeUpdateScore(targetInfo.penalty, targetInfo.name);
            StartCoroutine(WaitToDestory());
        }
    }

    IEnumerator WaitToDestory()
    {
        collided = true;
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(gameObject);
    }
}