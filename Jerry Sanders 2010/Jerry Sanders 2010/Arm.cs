using System;

namespace Jerry_Sanders_2010
{
	partial class jerry5Form
	{
		// MoveArm
		//  Calculate joint angles to move the arm to a specific
		//   position, then move it there. For more information about
		//   how the calculations were derived, see Chapter 3 of Robot
		//   Modeling and Control by Spong, Hutchinson, and Vidyasagar.
		//   Most of these calculations come directly from an example
		//   in that book which models a similar arm.
		//  Inputs: Xpos - desired X position of end effector of arm
		//          Ypos - desired Y position...
		//          Zpos - desired z position...
		//  Outputs: none
		//  Side Effects: moves the arm on the robot
		void MoveArm(float Xpos, float Ypos, float Zpos)
		{
			double Q1, Q2, Q3;

			double D;

			// length of first link
			double a2 = 12;
			double a3 = 13.5;

			double r;


			// check bounds (these bounds are kind of arbitrary right now.
			// I'll come up with better ones once the arm is up and running).
			if (Xpos > 24)
				Xpos = 24;
			if (Xpos < -24)
				Xpos = -24;
			
			if (Ypos > 24)
				Ypos = 24;
			if (Ypos < 5)
				Ypos = 5;

			if (Zpos > 24)
				Zpos = 24;
			if (Zpos < -5)
				Zpos = -5;
			
			// get waist angle
			Q1 = Math.Atan2(Ypos, Xpos);

			D = (Xpos * Xpos + Ypos * Ypos + Zpos * Zpos - a2 * a2 - a3 * a3) / (2 * a2 * a3);

			r = Math.Sqrt(Xpos * Xpos + Ypos * Ypos);

			// get elbow angle
			Q3 = Math.Atan2(-Math.Sqrt(1 - D * D), D);

			// get shoulder angle
			Q2 = Math.Atan2(Zpos, r) - Math.Atan2(a3 * Math.Sin(Q3), a2 + a3 * Math.Cos(Q3));


			// TODO: Convert Q angles to servo positions.  Right now,
			//       the servos range from 0 to 180 which should just be
			//       the angle I want, but the direction may not be correct.
			//       Zero degrees may also be at the wrong angle...
			sendServoParams((int)Q1, (int)Q2, (int)Q3);
		}
	}
}