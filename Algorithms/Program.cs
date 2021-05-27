using System;

// Reference: https://leetcode.com/problems/lru-cache/

namespace Algorithms.RobotBoundedInCircle
{
    struct Position
    {
        public Position(Orientation o, Point p) { this.Orientation = o; this.Point = p; }
        public Orientation Orientation { get; set; }
        public Point Point { get; set; }
    }

    struct Point
    {
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public bool AtOrigin { get => this.X == 0 && this.Y == 0; }
    }

    enum Orientation
    {
        North = 0,
        East = 1,
        South = 2,
        West = 3,
    }

    enum TurnDirection
    {
        Left,
        Right
    }

    class Program
    {
        static void Main()
        {
            string instructions = "GLRLGLLGLGRGLGL";
            Console.WriteLine(Bound(instructions));
        }

        public static bool Bound(string instructions)
        {
            if (instructions == null || instructions.Length == 0)
                return true;

            Position location1 = ProcessInstructions(instructions);
            if (location1.Point.AtOrigin)
                return true;

            Position location2 = ProcessInstructions(instructions, location1);
            if (location2.Point.AtOrigin)
                return true;

            Position location3 = ProcessInstructions(instructions, location2);
            if (location3.Point.AtOrigin)
                return true;

            Position location4 = ProcessInstructions(instructions, location3);
            if (location4.Point.AtOrigin)
                return true;

            return false;
        }

        public static int Max(int a, int b) => a > b ? a : b;
        public static int Abs(int a) => a < 0 ? a * -1 : a;

        public static Position ProcessInstructions(string instructions)
        {
            return ProcessInstructions(instructions, new Position());
        }

        public static Position ProcessInstructions(string instructions, Position startLocation)
        {
            var robot = new Robot(startLocation);
            foreach (char c in instructions)
            {
                switch (c)
                {
                    case 'G':
                        robot.Move();
                        break;
                    case 'L':
                        robot.Turn(TurnDirection.Left);
                        break;
                    case 'R':
                        robot.Turn(TurnDirection.Right);
                        break;
                    default:
                        break;
                }
            }

            return new Position(robot.Orientation, robot.Location);
        }
    }

    class Robot
    {
        public Orientation Orientation { get; private set; } = Orientation.North;
        public Point Location { get; private set; } = new Point(0, 0);
        public bool AtOrigin { get => this.Location.X == 0 && this.Location.Y == 0; }

        public Robot() { }

        public Robot(Position startLocation)
        {
            Orientation = startLocation.Orientation;
            Location = startLocation.Point;
        }

        public void Turn(TurnDirection direction)
        {
            if (direction == TurnDirection.Left)
            {
                if ((int)Orientation == 0)
                    Orientation = Orientation.West;
                else
                    Orientation--;
            }
            else if (direction == TurnDirection.Right)
            {
                if ((int)Orientation == 3)
                    Orientation = Orientation.North;
                else
                    Orientation++;
            }
        }

        public void Move()
        {
            Location = Orientation switch
            {
                Orientation.North => Location = new Point(Location.X, Location.Y + 1),
                Orientation.East => Location = new Point(Location.X + 1, Location.Y),
                Orientation.South => Location = new Point(Location.X, Location.Y - 1),
                Orientation.West => Location = new Point(Location.X - 1, Location.Y),
                _ => Location,
            };
        }
    }
}
