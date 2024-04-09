using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class Block : MonoBehaviour
{
    [SerializeField] int points = 100;
    [SerializeField] AudioSource audioSource;
    [SerializeField] TMP_Text scoreText;

    Rigidbody rb;
    bool destroyed = false;
    public UnityAction<int> scoreEvent;

    private int score = 0;

    public int Score
    {
        get { return score; }
        set
        {
            score += value;
            score = int.Parse(scoreText.text) + score;
            scoreText.text = score.ToString();
            //check if the object is still alive before invoking the event
            if (scoreEvent != null)
            {
                scoreEvent.Invoke(score);
            }
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (rb.velocity.magnitude > 2 || rb.angularVelocity.magnitude > 2)
        {
            audioSource.Play();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!destroyed && other.CompareTag("Kill") && 
            rb.velocity.magnitude == 0 && 
            rb.angularVelocity.magnitude == 0)
        {
            destroyed = true;
            print(points);
            addPoints(points);
            Destroy(gameObject, 2);
        }
    }

    public void addPoints(int points)
    {
        Score += points;
    }
}
