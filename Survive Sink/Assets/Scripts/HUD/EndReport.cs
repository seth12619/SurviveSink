using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

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

}
