using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;


public class Gem : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private PolygonCollider2D polygonCollider2D;
    public GameController gameController;
    public int Score = 100;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        polygonCollider2D = GetComponent<PolygonCollider2D>();
        gameController = GetComponent<GameController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            spriteRenderer.enabled = false;
            polygonCollider2D.enabled = false;

            GameController.Instance.totalScore += Score;
            GameController.Instance.UpdateTotalScore();

            Destroy(gameObject, 0.2f);
        }
    }
}
