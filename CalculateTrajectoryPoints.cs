using UnityEngine;

[System.Serializable]
public class CalculateTrajectoryPoints
{
	/// This script is based on the physics trajectory equation
	/// https://www.omnicalculator.com/physics/trajectory-projectile-motion
	/// httphttps://en.wikipedia.org/wiki/Projectile_motions://en.wikipedia.org/wiki/Projectile_motion
	
	public CalculateTrajectoryPoints(float gravitationPower)
	{
		this.gravitationPower = gravitationPower;
	}
	
	private float gravitationPower;

	internal Vector2 CalculatePosition(float time, float distanceToGround, Vector2 velocity)
	{
		Vector2 position;
		position.x = velocity.x * time;
		position.y = distanceToGround + velocity.y * time - gravitationPower * (time * time) / 2;
		
		return position;
	}
	
	internal float TimeToHitTheGround(float distanceToGround, Vector2 velocity)
	{
		float a = gravitationPower / 2;
		float b = -velocity.y;
		float c = -distanceToGround;
		float delta = CalculateDelta(b, a, c);
		Vector2 functionZeros = CalculateFunctionZeros(delta, a, b);

		float time1 = functionZeros.x;
		float time2 = functionZeros.y;
		if (time1 > time2)
		{
			return time1;
		}
		return time2;
	}

	private static float CalculateDelta(float b, float a, float c)
	{
		return (b*b) - 4*a*c;
	}

	private static Vector2 CalculateFunctionZeros(float delta, float a, float b)
	{
		float part1 = -b / (2*a);
		float part2 = Mathf.Sqrt(delta) / (2*a);
		
		float x1 = part1 - part2;
		float x2 = part1 + part2;
		
		return new Vector2(x1, x2);
	} 
	

}
