#pragma strict

var waterLevel : float;

private var isUnderwater : boolean;
private var normalColor : Color;
private var underwaterColor : Color;


//NEW VARIABLES
private var canSwim : boolean = false;
private var underGround : boolean = false;
var groundLevel : float;

function Start () 
	{
		normalColor = new Color (0.5f, 0.5f, 0.5f, 0.5f);
        underwaterColor = new Color (0.22f, 0.65f, 0.77f, 0.5f);

    }

function Update () 
	{

SetUnderwater();
            


     }

function SetNormal () 
		{
            RenderSettings.fogColor = normalColor;
            RenderSettings.fogDensity = 0.002f;
	
        }
     
function SetUnderwater () 
		{
            RenderSettings.fogColor = underwaterColor;
            RenderSettings.fogDensity = 0.03f;
     
        }