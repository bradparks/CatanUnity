using UnityEngine;
using System.Collections;

public struct Point{
	public int x,y;
	public Point(int ax, int ay){
		x = ax;
		y = ay;
	}
	public string asString(){
		return ("[X:" + x + " Y:"+ y + "]");
	}
}
