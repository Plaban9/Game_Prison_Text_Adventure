using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//https://gamebucket.io/game/a3257414-922a-49dc-bbf3-7cca0ac255da - URL for this game

public class TextController : MonoBehaviour 
{
	public Text text;
	private enum STATES {cell, mirror, lock_0, sheets_0, cell_mirror, lock_1, sheets_1, corridor_0, floor, stairs_0, 
						closet_door, corridor_1, stairs_1, in_closet, corridor_2, stairs_2, corridor_3, courtyard}; 
	private STATES myState;
	private bool isHandSafe = false;
	private bool isJanitorUniform = false;
	
	// Use this for initialization
	void Start() 
	{
		text.text = "Welcome to Prison...\n\nPress Space to continue...";
		
		/*if (Input.GetKeyDown(KeyCode.Space))
		{
			Prologue();
		}*/
		
		myState = STATES.cell;
	}
	
	// Update is called once per frame
	void Update () 
	{	
		print (myState);
		
		switch (myState)
		{
			case STATES.cell:	state_cell();
									break;
			case STATES.sheets_0: 	state_sheet_0();
									break;
			case STATES.mirror:   state_mirror();
									break;
			case STATES.lock_0:	state_lock_0();
									break;
			case STATES.cell_mirror: state_inspect_mirror();
									break;
			case STATES.sheets_1: state_sheet_1();
									break;
			case STATES.lock_1: state_lock_1();
									break;
			case STATES.corridor_0: state_corridor_0();
									break;												
			case STATES.stairs_0: state_stairs_0();
									break;
			case STATES.floor: state_floor();																				
									break;
			case STATES.closet_door: state_closet_door();
									break;
			case STATES.corridor_1: state_corridor_1();
									break;
			case STATES.stairs_1: state_stairs_1();
									break;
			case STATES.in_closet: state_in_closet();
									break;
			case STATES.corridor_2: state_corridor_2();
									break;
			case STATES.stairs_2: state_stairs_2();
									break;
			case STATES.corridor_3: state_corridor_3();
									break;
			case STATES.courtyard: state_courtyard();
									break;																																																																							
		}
	}
	
	/*void Prologue()
	{
		
		text.text = "Jack and Daniel are wrongly convicted of theft and " + 
					"are sentenced to 13 years in prison. One day, Jack " +
					"notices that the patroling guards have a pattern of " +
					"patrolling and finds out there is a chance of breaking " +
					"out of the prison. Only one thing is stopping him, Daniel " +
					"is unwilling to escape... \n\nWill Daniel agree?\n\n             Press RETURN to continue...."; 	
					
		if (Input.GetKeyDown(KeyCode.Return))
		{
			Update();
		}		
		
	}*/
	
	#region State Handler Methods
	
	void state_cell()
	{
		text.text = "You are in a prison cell, and you want to talk to your partner Daniel. " +
					"There are some dirty sheets on the bed, a mirror on the wall, and cell " +
					"is locked from outside.\n\n" +
					"Press S to view Sheets, M to view Mirror, L to view Lock";
					
		if (Input.GetKeyDown(KeyCode.S))
		{
			myState = STATES.sheets_0;	
		}
		
		else if (Input.GetKeyDown(KeyCode.M))
		{
			myState = STATES.mirror;	
		}
		
		else if (Input.GetKeyDown(KeyCode.L))
		{
			myState = STATES.lock_0;	
		}
	}
	
	void state_sheet_0()
	{
		text.text = "You can't believe that you sleep in these things. You have flashback of your past life's luxuries " +
					"and curse the system who wrongly convicted you. \n\n\"Life can change drastically if you are not careful enough.\"\n\n" +
					"Press R to return to roaming your cell";
					
		if (Input.GetKeyDown(KeyCode.R))
		{
			myState = STATES.cell;
		}
	}
	
	void state_mirror()
	{
		text.text = "It's been a fortnight and you see yourself as you never have seen yourself before - As an untidy, smelly and filthy person.\n\n" +
					"\"(Sigh)How times have changed!!\" You say to yourself (for you are lonely) as you slowly turn away... " +
					"while turning away, you see a broken glass which has shaped like a key...\n\n" +
					"\"The previous prisoner must have tried to escape...\"  you wonder.\n\n\n" +
					"Press C to inspect closely or Press R to return to cell...";
					
		if (Input.GetKeyDown(KeyCode.C))
		{
			myState = STATES.cell_mirror;
		}
		
		else if (Input.GetKeyDown(KeyCode.R))
		{
			myState = STATES.cell;
		}
		
	}
	
	void state_lock_0()
	{
		text.text = "You look at the lock and think only of freedom. You have flashbacks of the countryside you used to " +
					"visit during this time of the year...\n\nPress R to return to cell...";
					
		if (Input.GetKeyDown(KeyCode.R))
		{
			myState = STATES.cell;
		}
	}
	
	void state_inspect_mirror()
	{
		text.text = "Upon further inspection, you realize that the edges are sharp but seems like a key.\n\n" +
					"Press S to hold the broken mirror piece with your dirty sheets or Press L to try putting in the lock.";
		
		if (Input.GetKeyDown(KeyCode.S))
		{
			myState = STATES.sheets_1;
		}
		
		else if(Input.GetKeyDown(KeyCode.L))
		{
			myState = STATES.lock_1;
		}
	}
	
	void state_sheet_1()
	{
		text.text = "You tear a piece of cloth from the dirty sheets and wrap it around the glass piece..\n\nPress R to continue...";
		isHandSafe = true;	
					
		if (Input.GetKeyDown(KeyCode.R))
		{
			myState = STATES.cell_mirror;
		}
	}
	
	void state_lock_1()
	{
		text.text = "You try to turn the glass key....\n....the key seems to move.\n\n" +
					"You see a ray of hope and get excited....\n\nPress T to turn the glass key...";
					
		if (Input.GetKeyDown(KeyCode.T))
		{
			myState = STATES.corridor_0;
		}
					
		
	}
	
	void state_corridor_0()
	{
		if (isHandSafe)
		{
			text.text = "You escaped the Prison Cell... \n\n" +
						"\nbut......... for how long?\n\n\nPress S to check stairs, Press F to check floor and Press C to examine Closet";
		}
		
		else
		{
			text.text = "You get excited seeing the key turn and cut you hand in the process....\n\n" +
						"\"I still haven't learnt the lesson...\" - You say to yourself\n" +
						"\n\n\"But I am free.....\n.....at least...for....now.\"\n\n\n" +
						"Press S to check stairs, Press F to examine floor and Press C to examine closet";
		}
		
		if (Input.GetKeyDown(KeyCode.S))
		{
			myState = STATES.stairs_0;
		}
		
		else if (Input.GetKeyDown(KeyCode.F))
		{
			myState = STATES.floor;
		}
		
		else if (Input.GetKeyDown(KeyCode.C))
		{
			myState = STATES.closet_door;
		}
	}
	
	void state_stairs_0()
	{
		text.text = "The stairs seem to be heavily guarded. Can't go through espicially dressed as a prisoner. The stairs lead to a courtyard.\n\n\nPress R to Return";
		
		if (Input.GetKeyDown(KeyCode.R))
		{
			myState = STATES.corridor_0;
		}
	}
	
	void state_floor()
	{
		text.text = "A hair clip is present on the clip, maybe fallen from a janitor.\n\n\nPress R to return or Press T to take the hair clip.";
		
		if (Input.GetKeyDown(KeyCode.R))
		{
			myState = STATES.corridor_0;
		}
		
		else if (Input.GetKeyDown(KeyCode.T))
		{
			myState = STATES.corridor_1;
		}
	}
	
	void state_closet_door()
	{
		text.text = "The closet door seems to be locked...\n\n\nPress R to return to Corridor";
		
		if (Input.GetKeyDown(KeyCode.R))
		{
			myState = STATES.corridor_0;
		}
	}
	
	void state_corridor_1()
	{
		text.text = "\"The hair clip should do the trick....\"\n\n\nPress S to check stairs again or Press P to pick closet lock";
		
		if (Input.GetKeyDown(KeyCode.S))
		{
			myState = STATES.stairs_1;
		}
		
		else if (Input.GetKeyDown(KeyCode.P))
		{
			myState = STATES.in_closet;
		}
	}
	
	void state_stairs_1()
	{
		text.text = "The stairs are still heavily guarded and it seems they are not leaving anytime soon.\n\n\nPress R to return to the corridor";
		
		if (Input.GetKeyDown(KeyCode.R))
		{
			myState = STATES.corridor_1;
		}
	}
	
	void state_in_closet()
	{
		text.text = "The hair pin!!... can help.....\nVoila, the closet door opened. There are janitor uniforms inside.\n\n\n" +
					"Press R to return to corridor or Press D to change to a janitor uniform";
				
		if (Input.GetKeyDown(KeyCode.R))
		{
			myState = STATES.corridor_2;
		}
		
		else if (Input.GetKeyDown(KeyCode.D))
		{
			myState = STATES.corridor_3;
			isJanitorUniform = true;
		}
	}	
	
	void state_corridor_2()
	{
		text.text = "The corridor seems silent... \n\n\nPress C to check closet or Press S to check stairs again";
		
		if (Input.GetKeyDown(KeyCode.C))
		{
			myState = STATES.in_closet;
		}

		else if (Input.GetKeyDown(KeyCode.S))
		{
			myState = STATES.stairs_2;
		}
	}
	
	void state_stairs_2()
	{
		text.text = "The stair is still heavily guarded.... \n\nAt the water cooler, a janitor is cleaning the spilled water.\n\n\nPress R to return to corridor";
		
		if (Input.GetKeyDown(KeyCode.R))
		{
			myState = STATES.corridor_2;
		}
	}
	
	void state_corridor_3()
	{
		text.text = "\"Maybe I can escape now....\" -You\n\n\nPress S to go to courtyard through the stairs or Press U remove Janitor Uniform";
		
		if (Input.GetKeyDown(KeyCode.U))
		{
			myState = STATES.in_closet;
			isJanitorUniform = false;
		}
		
		else if (Input.GetKeyDown(KeyCode.S))
		{
			myState = STATES.courtyard;
		}
	}
	
	void state_courtyard()
	{
		text.text = "\"The guards do not seem to notice anything different...\"\n\n\".....There's the courtyard\"\n\n\"At last......I am.....Free(sigh)...\"\n\n\n\nPress P to play agian";
		
		if (Input.GetKeyDown(KeyCode.P))
		{
			myState = STATES.cell;
		}
	}
	
	#endregion
}