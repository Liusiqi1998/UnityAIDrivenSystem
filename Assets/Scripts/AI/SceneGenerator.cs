
using UnityEngine;
using System.IO;
using System.Collections.Generic;

[System.Serializable]
public class SceneObjectData{ public string prefab; public float[] position; }
[System.Serializable]
public class SceneData{ public List<SceneObjectData> objects; }

public class SceneGenerator:MonoBehaviour{
    public void Generate(){
        var path = Path.Combine(Application.streamingAssetsPath,"scene.json");
        var data = JsonUtility.FromJson<SceneData>(File.ReadAllText(path));
        foreach(var o in data.objects){
            var p = Resources.Load<GameObject>("Prefabs/"+o.prefab);
            if(p==null) continue;
            Instantiate(p,new Vector3(o.position[0],o.position[1],o.position[2]),Quaternion.identity);
        }
    }
}
