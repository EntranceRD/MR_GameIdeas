using Entrance;
using UnityEngine;
using Entrance.Games.Demos;
using Entrance.Games;

public class BounceBall_Manager : MonoBehaviour
{
    public ModsGenerator modsGenerator;
    public BallGenerator ballGenerator;
    public BallBowl ballBowl;


    void Restart()
    {
        modsGenerator.Restart();
        ballBowl.Restart();
        ballGenerator.Restart();
    }

    void Start()
    {
        Restart();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
    }
}
