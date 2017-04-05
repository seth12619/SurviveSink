using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class MainTracker : MonoBehaviour {
    private int lifeJacketTracker;
    private int stamina;
    private float time = 0;
	private bool watered = false;
	int health = 100;
	int score = 0;

	// Use this for initialization
	void Start () {
        lifeJacketTracker = 0;
        stamina = 1000;
		DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
	}

    public IEnumerator addLifeJacket()
    {
        lifeJacketTracker++;
        yield return null;
    }
	
	public void hasJumped()
	{
		watered = true;
	}
	
	public bool didJump()
	{
		return watered;
	}

    public IEnumerator useStamina(int st)
    {
        stamina -= st;
        yield return null;
    }

    public IEnumerator endDay()
    {
        GameObject.Find("Ship").GetComponent<WaitTilting>().stopWorking();
        StartCoroutine(GetComponent<EndReport>().endReport(report()));
        yield return null;
    }

    public bool hasStamina()
    {
        return stamina > 0;
    }
	
	public int getLifeJacketTracker() {
		return lifeJacketTracker;
	}

    public int staminaNo()
    {
        return stamina;
    }
	
	public int getTime() {
		return (int)time;
	}
	
	public int getHealth() {
		return health;
	}
	
	public int getScore() {
		return score;
	}
	
	

    public string report()
    {
		
		float a = GameObject.Find("/HUD/GritUI/GritSlider").GetComponent<Slider>().value;
        string rep = "";
        rep += stamina > 700 ? "You feel energized..." : stamina > 300 ? "You feel a little winded..." : "You feel exhausted...";
        rep += "\n";
        rep += time < 150 ? "You escaped very quickly..." : time < 600 ? "You got out in time..." : "You took a really long time...";
        
        score += lifeJacketTracker > 0 ? 2000 : 0;
        score += stamina;
        score += 1000 - (int)time;
		if (didJump()) {
			score += -1000;
		} 
		rep +=  "\nHealth: " + a.ToString();
        rep += "\nYour Score: ";
        rep += score < 1000 ? "F" : score < 1500 ? "D" : score < 2000 ? "C" : score < 2500 ? "B" : "A";
		health = (int)a;
		if(a <= 0){
			rep = "You Died";
		}
			
		
        return rep;
    }
}
