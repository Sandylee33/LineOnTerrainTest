using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine: MonoBehaviour {

    public Vector3 start;
    public Vector3 end;

    public GameObject line;
	// Use this for initialization
	void Start () {
		
	}
	
	

    public void Draw (Vector3 startPos, Vector3 endPos)
    {
        GameObject go = Instantiate(line,this.transform) as GameObject;
        //go.transform.localPosition = new Vector3((startPos.x+endPos.x)/2,90f,(startPos.z+endPos.z)/2);
        go.transform.localPosition = new Vector3(startPos.x,90f,startPos.z);
        Quaternion localRot = go.transform.localRotation;
        localRot.eulerAngles = new Vector3(90f,0f,Mathf.Atan2(endPos.z-startPos.z,endPos.x-startPos.x) * Mathf.Rad2Deg);
        go.transform.transform.localRotation = localRot;
        Projector p = go.GetComponent<Projector>();
        float f = Mathf.Sqrt((endPos.z-startPos.z)*(endPos.z-startPos.z)+(endPos.x-startPos.x)*(endPos.x-startPos.x))/50f;
        StartCoroutine(DrawAnimation(f,p));
    }

    IEnumerator DrawAnimation(float des, Projector p)
    {
        p.aspectRatio = 0.1f;
        while (p.aspectRatio < des)
        {
            p.aspectRatio += 0.25f;
            yield return null;
        }
    }

}
