using UnityEngine;
using System.Collections;

public class TestScript : MonoBehaviour {
	public HexNode hx;
	public GameObject hex, sett;
	// Use this for initialization
	void Awake(){
	}
	void Start () {
		hx = new HexNode();
		hx.initCoords(0,0);
		hx.addHexNbrs();
		HexNode[] hhh = new HexNode[hx.HexNbrs.Count];
		hx.HexNbrs.Values.CopyTo(hhh,0);
		foreach(HexNode h in hhh){
            h.addHexNbrs();
        }
		foreach(HexNode h in NodeHolder.instance().HexList.Values){
			GameObject go = GameObject.Instantiate(hex);
			go.transform.position = h.coordTransform();
			h.addSettNbrs();
/*			Debug.Log ("Hex at " + h.coords.asString() + " with neighbours at " +
			           h.HexNbrs[0].coords.asString() + ", " + 
			           h.HexNbrs[1].coords.asString() + ", " + 
			           h.HexNbrs[2].coords.asString() + ", " + 
			           h.HexNbrs[3].coords.asString() + ", " + 
			           h.HexNbrs[4].coords.asString() + ", " + 
			           h.HexNbrs[5].coords.asString() + ", ");*/
		}
		foreach(SettNode s in NodeHolder.instance().SettList.Values){
			GameObject whamo = GameObject.Instantiate(sett);
			whamo.transform.position = s.coordTransform();
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
