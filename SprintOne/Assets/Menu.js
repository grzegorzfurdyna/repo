var isQuitButton = false;
var enter : Sprite;
var exit : Sprite;

function OnMouseEnter()
{
GetComponent(SpriteRenderer).sprite = enter;
}

function OnMouseExit()
{
GetComponent(SpriteRenderer).sprite = exit;
}

function OnMouseUp()
{
if( isQuitButton )
{
Application.Quit();
}
else
{
Application.LoadLevel(1);
}
}
Screen.showCursor = true;