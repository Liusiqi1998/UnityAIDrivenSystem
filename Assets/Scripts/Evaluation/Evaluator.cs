
using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class Evaluator:MonoBehaviour{
    public Transform target;
    public float interval=0.1f;
    public string dangerTag="Danger";

    List<Vector3> path=new List<Vector3>();
    int dangerCount=0;
    float timer;

    void Update(){
        timer+=Time.deltaTime;
        if(timer>=interval){
            timer=0;
            path.Add(target.position);
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.CompareTag(dangerTag)) dangerCount++;
    }

    public float CalcStability(){
        float sum=0;
        for(int i=1;i<path.Count;i++){
            sum+=Vector3.Distance(path[i],path[i-1]);
        }
        return Mathf.Clamp(100 - sum,0,100);
    }

    public void Export(){
        string dir = Application.persistentDataPath;
        using(StreamWriter sw=new StreamWriter(Path.Combine(dir,"path.csv"))){
            sw.WriteLine("x,y,z");
            foreach(var p in path){
                sw.WriteLine(p.x+","+p.y+","+p.z);
            }
        }

        float stability = CalcStability();
        float score = 100 - dangerCount*10 - (100-stability);

        string report = "Stability:"+stability+"\nDanger:"+dangerCount+"\nScore:"+score;
        File.WriteAllText(Path.Combine(dir,"report.txt"),report);
    }

    void OnDrawGizmos(){
        Gizmos.color=Color.green;
        for(int i=1;i<path.Count;i++){
            Gizmos.DrawLine(path[i-1],path[i]);
        }
    }
}
