using UnityEngine;
using System.Collections;

public class SettNode{
	public HexNode[] HexNbrs;
	public SettNode[] SettNbrs;
	private Point coords;
	public int direction;
	
	public SettNode(){
		SettNbrs = new SettNode[3];
		HexNbrs = new HexNode[3];
	}	
	public int getX(){
		return coords.x;
	}
	
	public int getY(){
		return coords.y;
	}

	public bool initCoords(int x, int y){
		if(!NodeHolder.instance().SettList.ContainsKey(new Point(x,y))){
			coords.x = x;
			coords.y = y;
			NodeHolder.instance().SettList.Add((new Point(x,y)), this);
			Debug("Sett created at " + x + "," + y);
			
			//updateNbrs();
			return true;
		}
		Debug("Already a Sett at " + x + "," + y);
		return false;
	}
	public void updateNbrs(){
		if(direction == 0){
			if(NodeHolder.instance().SettList.ContainsKey(new Point(coords.x+1, coords.y+1))){
				SettNbrs[0] = NodeHolder.instance().SettList[new Point(coords.x+1, coords.y+1)];
                SettNbrs[0].SettNbrs[1] = this;
                Debug("Connecting " + this.coords.asString() + " to " + SettNbrs[0].coords.asString() + " (0)");
			}
			if(NodeHolder.instance().SettList.ContainsKey(new Point(coords.x, coords.y-2))){
				SettNbrs[1] = NodeHolder.instance().SettList[new Point(coords.x, coords.y-2)];
                SettNbrs[1].SettNbrs[2] = this;
                Debug("Connecting " + this.coords.asString() + " to " + SettNbrs[1].coords.asString() + " (1)");
			}
			if(NodeHolder.instance().SettList.ContainsKey(new Point(coords.x-1, coords.y+1))){
				SettNbrs[2] = NodeHolder.instance().SettList[new Point(coords.x-1, coords.y+1)];
                SettNbrs[2].SettNbrs[0] = this;
                Debug("Connecting " + this.coords.asString() + " to " + SettNbrs[2].coords.asString() + " (2)");
			}
		}
		else{
			if(NodeHolder.instance().SettList.ContainsKey(new Point(coords.x+1, coords.y-1))){
				SettNbrs[0] = NodeHolder.instance().SettList[new Point(coords.x+1, coords.y-1)];
                SettNbrs[0].SettNbrs[2] = this;
                Debug("Connecting " + this.coords.asString() + " to " + SettNbrs[0].coords.asString() + " (0)");
			}
			if(NodeHolder.instance().SettList.ContainsKey(new Point(coords.x-1, coords.y-1))){
				SettNbrs[1] = NodeHolder.instance().SettList[new Point(coords.x-1, coords.y-1)];
                SettNbrs[1].SettNbrs[0] = this;
                Debug("Connecting " + this.coords.asString() + " to " + SettNbrs[1].coords.asString() + " (1)");
			}
			if(NodeHolder.instance().SettList.ContainsKey(new Point(coords.x, coords.y+2))){
				SettNbrs[2] = NodeHolder.instance().SettList[new Point(coords.x, coords.y+2)];
				SettNbrs[2].SettNbrs[1] = this;
				Debug("Connecting " + this.coords.asString() + " to " + SettNbrs[2].coords.asString() + " (2)");
            }
		}
	}

	public Vector3 coordTransform(){
		return new Vector3(coords.x*1f, 0f, coords.y*0.58f);
	}
	
	public void Debug(){
		//GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		//cube.transform.position = new Vector3(coords.x+0f,coords.y+0f,0);
	}
	public void Debug(string message){
		GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube.transform.position = new Vector3(-1f,-1f,0);
		cube.name = message;
		cube.SetActive(false);
	}

}
