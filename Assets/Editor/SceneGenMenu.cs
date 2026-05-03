
using UnityEditor;
using UnityEngine;

public class SceneGenMenu{
    [MenuItem("Tools/Generate Scene")]
    static void Run(){
        var g = GameObject.FindObjectOfType<SceneGenerator>();
        if(g==null) g=new GameObject("SceneGenerator").AddComponent<SceneGenerator>();
        g.Generate();
    }
}
