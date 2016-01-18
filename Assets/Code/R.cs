using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//Resource enum
public struct R{
	
	public static R Wood;
	public static R Wheat;
	public static R Sheep;
	public static R Brick;
	public static R Ore;

	public static Stack<R> createHexPile(){
		R[] pile = new R[19];
		pile = new R[]{
			Wood, Wood, Wood, Wood, 
			Wheat, Wheat, Wheat, Wheat, 
			Sheep, Sheep, Sheep, Sheep,
			Brick, Brick, Brick, 
			Ore, Ore, Ore
		};
		for (int i = pile.Length - 1; i > 0; i--) {
			int r = Random.Range(0,i);
			R tmp = pile[i];
			pile[i] = pile[r];
			pile[r] = tmp;
		}
		return new Stack<R>(pile);
	}
}
