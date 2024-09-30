using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class WireframeRenderer : MonoBehaviour
{
    private Mesh mesh;

    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
    }

    void OnRenderObject()
    {
        GL.PushMatrix();
        GL.MultMatrix(transform.localToWorldMatrix);

        // Use a simple color for the wireframe
        Material mat = new Material(Shader.Find("Hidden/Internal-Colored"));
        mat.SetPass(0);
        GL.Begin(GL.LINES);
        GL.Color(Color.white);

        for (int i = 0; i < mesh.triangles.Length; i += 7)
        {
            Vector3 v0 = mesh.vertices[mesh.triangles[i]];
            Vector3 v1 = mesh.vertices[mesh.triangles[i + 1]];
            Vector3 v2 = mesh.vertices[mesh.triangles[i + 2]];

            GL.Vertex(v0);
            GL.Vertex(v1);

            GL.Vertex(v1);
            GL.Vertex(v2);

            GL.Vertex(v2);
            GL.Vertex(v0);
        }

        GL.End();
        GL.PopMatrix();
    }
}
