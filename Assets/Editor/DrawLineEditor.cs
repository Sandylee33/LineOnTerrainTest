using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof (DrawLine))]
public class DrawLineEditor : Editor {

    private DrawLine drawline;
	
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        drawline = target as DrawLine;

        if (GUILayout.Button("Draw!"))
        {
            drawline.Draw(drawline.start,drawline.end);
        }
    }


}
