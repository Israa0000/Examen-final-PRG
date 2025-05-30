using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int score = 0;
    public TMP_Text scoreText;

    public void AddPoint()
    {
        score++;
        Debug.Log("Puntos: " + score);
        scoreText.text = score.ToString();
    }

    public void Update()
    {
        scoreText.transform.rotation = Quaternion.identity;

    }

    public void RemovePoint()
    {
        score = Mathf.Max(0, score - 1);
    }
}
