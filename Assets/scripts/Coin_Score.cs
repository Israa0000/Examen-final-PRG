using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Coin_Score : MonoBehaviour
{
    public TMP_Text scoreUI;
    Movement movement;
    public int score;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var position = new Vector2(Random.Range(10, -10), Random.Range(10, -10));
        transform.position = position;
        score++;
        Debug.Log("collision");

    }
    private void Update()
    {
        new Vector2(14, 14);
        new Vector2(-14, -14);
        scoreUI.text = score.ToString();
    }
}
