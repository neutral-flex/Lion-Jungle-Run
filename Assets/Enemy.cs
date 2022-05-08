using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float Speed;

    public GameObject player;

    public float SeeDistance;
    public static Enemy instance;

    public GameObject restartMenu;

    public GameObject gameScene;
    public Canvas can;

    public AudioSource GameOver;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Player.pl.Play == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, Speed * Time.deltaTime);

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player.pl.Play = false;
            GameOver.Play(); 
            PlayerPrefs.SetInt("Restart", 1);
            restartMenu.SetActive(true);
            gameScene.SetActive(false);
            can.renderMode = RenderMode.ScreenSpaceOverlay;
        }
    }
    public void RestartGame()
    {
        Restart.instance.IsReset = true;
        SceneManager.LoadScene("Game");
    }
    public void RestartScene()
    {
        PlayerPrefs.SetInt("Restart", 0);

        SceneManager.LoadScene("Game");
    }
}
