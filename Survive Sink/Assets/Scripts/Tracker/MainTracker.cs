using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainTracker : MonoBehaviour {
    private int lifeJacketTracker;
    private int stamina;
    private float time = 0;

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

    public string report()
    {
		
		float a = GameObject.Find("/HUD/GritUI/GritSlider").GetComponent<Slider>().value;
        string rep = "";
        rep += lifeJacketTracker > 0 ? "Wore a life jacket...\n" : "Did not have a life jacket...\n";
        rep += stamina > 700 ? "You feel energized..." : stamina > 300 ? "You feel a little winded..." : "You feel exhausted...";
        rep += "\n";
        rep += time < 150 ? "You escaped very quickly..." : time < 600 ? "You got out in time..." : "You took a really long time...";
        int score = 0;
        score += lifeJacketTracker > 0 ? 2000 : 0;
        score += stamina;
        score += 1000 - (int)time;
		rep +=  "\nHealth: " + a.ToString();
        rep += "\nYour Score: ";
        rep += score < 1000 ? "F" : score < 1500 ? "D" : score < 2000 ? "C" : score < 2500 ? "B" : "A";
		
		if(a <= 0){
			rep = "You Died";
		}
			
		SceneManager.LoadScene("EndReport", LoadSceneMode.Single);
        return rep;
    }
}
