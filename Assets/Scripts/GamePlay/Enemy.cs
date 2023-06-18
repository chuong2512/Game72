using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Duration = 8;

    public SpriteRenderer spriteRenderer;
    public Sprite change;

    // Start is called before the first frame update
    void OnEnable()
    {
        transform.DOMove(transform.position + Vector3.down * 10.3f, Duration).SetEase(Ease.Linear).OnComplete(() =>
        {
            ShowLose();
        });
    }

    private void ShowLose()
    {
        if (change != null)
        {
            spriteRenderer.sprite = change;
        }
        
        if (GameManager.Instance.currentState != State.Lose)
        {
            GameManager.Instance.ShowLose();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}