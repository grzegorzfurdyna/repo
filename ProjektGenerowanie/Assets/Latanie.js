var Speed : float = 0;

function Update()
{
renderer.material.mainTextureOffset = new Vector2(Time.time * Speed,0f);
}
