using UnityEngine;
using UnityEditor;
using System.Collections;

public class SimplePlane : MonoBehaviour {

    const float verticesValue = 0.5f;
    const string AssetName = "SimplePlane";
    const string AssetPath = "Assets/SimplePlane.asset";

    [MenuItem("MyTools/Simple Plane")]
    static void Create() {
        GameObject obj = new GameObject(AssetName);

        // 必要なメッシュデータを用意する
        MeshFilter meshFilter = obj.AddComponent<MeshFilter>();
        MeshCollider meshCollider = obj.AddComponent<MeshCollider>();
        MeshRenderer meshRenderer = obj.AddComponent<MeshRenderer>();

        // メッシュのアセット情報が内部に保存されていればそのまま使用
        Mesh mesh = (Mesh)AssetDatabase.LoadAssetAtPath(AssetPath, typeof(Mesh));
        
        // なければアセット情報を作成
        if (mesh == null) {
            mesh = new Mesh();
            mesh.name = AssetName;
            
            // 頂点情報を作成
            Vector3[] vertices = new Vector3[]{
                new Vector3( verticesValue,  verticesValue, 0),
                new Vector3(-verticesValue, -verticesValue, 0),
                new Vector3(-verticesValue,  verticesValue, 0),
                new Vector3( verticesValue, -verticesValue, 0),
            };

            // 三角ポリゴンの構成を指定
            int[] triangles = new int[]{
                0, 1, 2, 
                3, 1, 0,
            };

            // 頂点に対応するUVを設定
            Vector2[] uv = new Vector2[]{
                new Vector2(1, 0),
                new Vector2(0, 0),
                new Vector2(0, 1),
                new Vector2(1, 0),
            };

            // 各種情報を設定
            mesh.vertices   = vertices;
            mesh.triangles  = triangles;
            mesh.uv         = uv;

            // マテリアル情報を設定
            meshRenderer.sharedMaterial = new Material(Shader.Find("Diffuse"));

            // メッシュのアセット情報を保存
            AssetDatabase.CreateAsset(mesh, AssetPath);
            AssetDatabase.SaveAssets();
        }

        // GameObjectのMeshに設定し、バウンディングボックス更新
        meshFilter.sharedMesh = mesh;
        mesh.RecalculateBounds();

        // コライダー
        meshCollider.sharedMesh = mesh;
        mesh.RecalculateNormals();
 }
}
