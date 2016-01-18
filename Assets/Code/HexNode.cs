using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HexNode{
	public Dictionary<int, HexNode> HexNbrs;
	public Dictionary<int, SettNode> SettNbrs;
	public Point coords;
	public R res;
	public int num;
	
	public HexNode(){
		HexNbrs = new Dictionary<int, HexNode>();
		SettNbrs = new Dictionary<int, SettNode>();
	}	
	public int getX(){
		return coords.x;
	}

	public int getY(){
		return coords.y;
    }
    
	public Vector3 coordTransform(){
		return new Vector3(coords.x*2.0f + coords.y*1.0f, 0f, Mathf.Sqrt(3)*coords.y);
	}

	public bool initCoords(int x, int y){
		if(!NodeHolder.instance().HexList.ContainsKey(new Point(x,y))){
			coords.x = x;
			coords.y = y;
			NodeHolder.instance().HexList.Add((new Point(x,y)), this);
			Debug("Hex created at " + x + "," + y);
	
			updateNbrs();
			return true;
		}
        Debug("Already a Hex at " + x + "," + y);
		return false;
	}

    public void addHexNbrs(){
		addHexNbr(0);
		addHexNbr(1);
		addHexNbr(2);
		addHexNbr(3);
		addHexNbr(4);
        addHexNbr(5);
	}
	public void updateNbrs(){
        for(int i = 0; i<6; i++){
            int x = this.coords.x;
            int y = this.coords.y;
            if(i!=3 && i!=0){
                if(i<3){ x++;}
                else{ x--;}
            }
            if(i!=1 && i!=4){
                if(i<4 && i >1){ y--;}
                else{ y++;}
            }
            if(NodeHolder.instance().HexList.ContainsKey(new Point(x,y))){
				HexNbrs[i] = NodeHolder.instance().HexList[new Point(x,y)];
				HexNbrs[i].HexNbrs[(i+3)%6] = this;
				Debug("Connecting " + this.coords.asString() + " to " + HexNbrs[i].coords.asString() + " (" + i + ")");
            }
			else{
				HexNbrs[i]= this;
			}

        }
    }

	public void addHexNbr(int location){
		int x = this.coords.x;
		int y = this.coords.y;
		if(location!=3 && location!=0){
			if(location<3){ x++;}
			else{ x--;}
		}
		if(location!=1 && location!=4){
			if(location<4 && location >1){ y--;}
			else{ y++;}
        }
        HexNbrs[location] = new HexNode();
		if(!HexNbrs[location].initCoords(x,y)){
			HexNbrs[location] = NodeHolder.instance().HexList[new Point(x,y)];
		}
		HexNbrs[location].HexNbrs[(location+3)%6] = this;
    }
    
    public void addSettNbrs(){
        addSettNbr(0);
        addSettNbr(1);
        addSettNbr(2);
        addSettNbr(3);
        addSettNbr(4);
        addSettNbr(5);
	}

	public void addSettNbr(int location){
		int x = coords.x*2+coords.y;
		int y = coords.y*3;
		if(location>0 && location <4) y--;
		else y++;
		if(location==2) y--;
		if(location==5) y++; 
		if(location<2) x++;
		if(location>2 && location<5) x--;
		SettNbrs[location] = new SettNode();
		int direction = location%2;
		if(location==0) direction = 0;
		SettNbrs[location].direction = direction;
		if(!SettNbrs[location].initCoords(x,y)){
			SettNbrs[location] = NodeHolder.instance().SettList[new Point(x,y)];
		}
        //SettNbrs[location].direction = direction;
		SettNbrs[location].updateNbrs();
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
