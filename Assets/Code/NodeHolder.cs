using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NodeHolder{

	private static NodeHolder master;
	public Dictionary<Point, HexNode> HexList;
	public Dictionary<Point, RoadNode> RoadList;
	public Dictionary<Point, SettNode> SettList;

	public NodeHolder(){
		HexList = new Dictionary<Point, HexNode>();
		RoadList = new Dictionary<Point, RoadNode>();
		SettList = new Dictionary<Point, SettNode>();
	}


	public static NodeHolder instance(){
		if(master!=null){
			return master;
		}
		else{
			master = new NodeHolder();
			return master;
		}
	}
}
