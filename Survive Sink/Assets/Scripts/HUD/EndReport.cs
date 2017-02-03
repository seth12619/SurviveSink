using UnityEngine;
using System.Collections;

public class EndReport : MonoBehaviour
{
    bool endTime = false;
    string report = "";

    public IEnumerator endReport(string report)
    {
        this.report = report;
        endTime = true;
        yield return null;
    }

    void OnGUI()
    {
        if(endTime)
            GUI.Box(new Rect(0,0,Screen.width, Screen.height), report);
    }
}
