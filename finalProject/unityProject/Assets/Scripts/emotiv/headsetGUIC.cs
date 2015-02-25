﻿// The code which displays the contact quality of the sensors belongs to Emotiv with small modifications on how we display the data and it's been rewritten in C# from Javascript.

using UnityEngine;
using System.Collections;
using System;

public class headsetGUIC : MonoBehaviour {

	public float int_scale = 0.7f;
	private Rect headArea;
	private Rect head;
	public static int[] node;

	public Texture2D headset;
	public Texture2D redButton;
	public Texture2D blackButton;
	public Texture2D orangeButton;
	public Texture2D yellowButton;
	public Texture2D greenButton;

	public Texture2D pushArrow;
	public Texture2D pullArrow;
	public Texture2D leftArrow;
	public Texture2D rightArrow;
	public Texture2D neutral;
	public Texture2D pushArrowActive;
	public Texture2D pullArrowActive;
	public Texture2D leftArrowActive;
	public Texture2D rightArrowActive;
	public Texture2D neutralActive;

	// Use this for initialization
	void Start () {

		node = new int[18];
		for (int i = 0; i < 18; i++)
		{
			node[i] = 0;
		}  
		
		headArea = new Rect(10, 15, 225 * int_scale, 200 * int_scale);
		if(head == new Rect(0,0,0,0))
		{
			head = new Rect(0, 0, 200 * int_scale, 200 * int_scale);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		for (int i = 0 ; i< EmoEngineInst.nChan ;i++)
		{
			node[i] = EmoEngineInst.Cq[i];
		}  
	}

	void OnGUI()
	{		
		DrawGUI();

		//Store backup values for the box style.
		GUIStyle backUpBox = GUI.skin.box;

		GUIStyle labelStyle = new GUIStyle();
		labelStyle.alignment = TextAnchor.MiddleLeft;

		GUI.Label(new Rect(10, 160, 300, 25), "<color=orange><b>Current Action: " /*+ EmoCognitiv.getCurrentAction()*/ + "</b></color>", labelStyle);
		
		//left arrow
		if (EmoCognitiv.getCurrentAction() == "COG_LEFT")
			GUI.DrawTexture ( new Rect(160*int_scale, 225*int_scale, 46*int_scale, 46*int_scale) , leftArrowActive);
		else
			GUI.DrawTexture ( new Rect(160*int_scale, 225*int_scale, 46*int_scale, 46*int_scale) , leftArrow);
		
		//right arrow
		if (EmoCognitiv.getCurrentAction() == "COG_RIGHT")
			GUI.DrawTexture ( new Rect(220*int_scale, 225*int_scale, 46*int_scale, 46*int_scale) , rightArrowActive);
		else
			GUI.DrawTexture ( new Rect(220*int_scale, 225*int_scale, 46*int_scale, 46*int_scale) , rightArrow);

		//forward arrow
		if (EmoCognitiv.getCurrentAction() == "COG_PUSH")
			GUI.DrawTexture ( new Rect(191*int_scale, 197*int_scale, 46*int_scale, 46*int_scale) , pushArrowActive);
		else
			GUI.DrawTexture ( new Rect(191*int_scale, 197*int_scale, 46*int_scale, 46*int_scale) , pushArrow);

		//backward arrow
		if (EmoCognitiv.getCurrentAction() == "COG_PULL")
			GUI.DrawTexture ( new Rect(191*int_scale, 255*int_scale, 46*int_scale, 46*int_scale) , pullArrowActive);
		else
			GUI.DrawTexture ( new Rect(191*int_scale, 255*int_scale, 46*int_scale, 46*int_scale) , pullArrow);

		//central circle
		if (EmoCognitiv.getCurrentAction() == "COG_NEUTRAL")
			GUI.DrawTexture ( new Rect(190*int_scale, 225*int_scale, 46*int_scale, 46*int_scale) , neutralActive);
		else
			GUI.DrawTexture ( new Rect(190*int_scale, 225*int_scale, 46*int_scale, 46*int_scale) , neutral);
		
		Texture2D myTexture = new Texture2D(1, 1);
		Color grey = new Color(0.5f, 0.5f, 0.5f);
		myTexture.SetPixel(1, 1, grey);
		myTexture.Apply();
		GUI.skin.box.normal.background = myTexture; 	

		//Draw background GUI box with default values.
		float power = (float) Math.Round(EmoCognitiv.getCurrentActionPower()*100, 2); 
		GUI.Box(new Rect(55, 203, 101, 15), "");

		//Compute green texture		
		Color green = new Color(0, 1, 0);
		myTexture.SetPixel(1, 1, green);
		myTexture.Apply();
		GUI.skin.box.normal.background = myTexture; 	

		//Display power box value.
		GUI.Box(new Rect(56, 205, power, 11), "");
		GUI.Label(new Rect(10, 200, 300, 25), "<color=orange><b>Power: </b></color>", labelStyle);
		
		//Restore to previous skin values.
		GUI.skin.box = backUpBox;
	}

	void DrawGUI(){
		
		GUI.BeginGroup (headArea);
		GUI.DrawTexture ( head , headset);
		
		GUI.DrawTexture ( new Rect(47*int_scale, 26*int_scale, 23*int_scale, 23*int_scale) , nodeStatus(node[3]));
		GUI.DrawTexture ( new Rect(130*int_scale, 26*int_scale, 23*int_scale, 23*int_scale) , nodeStatus(node[16]));
		
		GUI.DrawTexture ( new Rect(67*int_scale, 51*int_scale, 23*int_scale, 23*int_scale) , nodeStatus(node[5]));
		GUI.DrawTexture ( new Rect(110*int_scale, 51*int_scale, 23*int_scale, 23*int_scale) , nodeStatus(node[14]));
		
		GUI.DrawTexture ( new Rect(18*int_scale, 53*int_scale, 23*int_scale, 23*int_scale) , nodeStatus(node[4]));
		GUI.DrawTexture ( new Rect(159*int_scale, 53*int_scale, 23*int_scale, 23*int_scale) , nodeStatus(node[15]));
		
		GUI.DrawTexture ( new Rect(37*int_scale, 71*int_scale, 23*int_scale, 23*int_scale) , nodeStatus(node[5]));
		GUI.DrawTexture ( new Rect(141*int_scale, 71*int_scale, 23*int_scale, 23*int_scale) , nodeStatus(node[13]));
		
		// T7 T8
		GUI.DrawTexture ( new Rect(8*int_scale, 93*int_scale, 23*int_scale, 23*int_scale) , nodeStatus(node[7]));
		GUI.DrawTexture ( new Rect(169*int_scale, 93*int_scale, 23*int_scale, 23*int_scale) , nodeStatus(node[12]));
		
		//CMS
		GUI.DrawTexture ( new Rect(18*int_scale, 118*int_scale, 23*int_scale, 23*int_scale) , nodeStatus(node[0]));
		GUI.DrawTexture ( new Rect(159*int_scale, 118*int_scale, 23*int_scale, 23*int_scale) , nodeStatus(node[1]));
		
		GUI.DrawTexture ( new Rect(37*int_scale, 148*int_scale, 23*int_scale, 23*int_scale) , nodeStatus(node[8]));
		GUI.DrawTexture ( new Rect(140*int_scale, 148*int_scale, 23*int_scale, 23*int_scale) , nodeStatus(node[11]));
		
		GUI.DrawTexture ( new Rect(64*int_scale, 172*int_scale, 23*int_scale, 23*int_scale) , nodeStatus(node[9]));
		GUI.DrawTexture ( new Rect(113*int_scale, 172*int_scale, 23*int_scale, 23*int_scale) , nodeStatus(node[10]));
		
		GUI.EndGroup(); 
	}

	Texture2D nodeStatus(int node)
	{
		Texture2D returnButton;
		switch (node)
		{ 
		case 0:
			returnButton = blackButton;
			break;
		case 1:
			returnButton = redButton; 
			break; 
		case 2:
			returnButton = orangeButton;
			break; 
		case 3:
			returnButton = yellowButton; 
			break; 
		case 4:
			returnButton = greenButton; 
			break; 
		default:
			returnButton = blackButton;
			break;			
		}
		return returnButton; 
	}
} //class
