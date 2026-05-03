
using UnityEngine;

public class ControlPanel:MonoBehaviour{
    public Evaluator evaluator;

    public void OnExport(){
        evaluator.Export();
        Debug.Log("Export Done");
    }
}
