using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;


    private void Awake()
    {
        Singleton();

    }

    public List<Highscore> GetHighscore() {
        List<Highscore> highscores = new List<Highscore>()
                    {
                        new Highscore(){Player = "Tommy", Score = 600 },
                        new Highscore(){Player = "Karen", Score = 15000 },
                        new Highscore(){Player = "Marco", Score = 2200 },
                        new Highscore(){Player = "Giovanni", Score = 551200 },
                        new Highscore(){Player = "Alex", Score = 515100 },
                        new Highscore(){Player = "Bodo", Score = 15000 },
                        new Highscore(){Player = "Kathrin", Score = 2200 },
                        new Highscore(){Player = "Maja", Score = 5211200 },
                        new Highscore(){Player = "Robert", Score = 445100 },
                        new Highscore(){Player = "Some Guy", Score = 111000 },
                        new Highscore(){Player = "Mario", Score = 26600 },
                        new Highscore(){Player = "Giovanni", Score = 12561200 },
                        new Highscore(){Player = "Alex", Score = 51442100 },
                        new Highscore(){Player = "Robert", Score = 4100 },
                        new Highscore(){Player = "Some Guy", Score = 1000 },
                        new Highscore(){Player = "Mario", Score = 2600 },
                        new Highscore(){Player = "Giovanni", Score = 1161200 },
                        new Highscore(){Player = "Alex", Score = 514100 }
                    };
        return highscores.OrderByDescending(m => m.Score).ToList();

    }

    private void Singleton()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
}
