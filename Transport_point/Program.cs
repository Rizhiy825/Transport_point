using System;
using System.Collections.Generic;

namespace Transport_point
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(200, 50);

            Point a = new Point(0, 0);
            Point b = new Point(100, 0);
            Point c = new Point(50, 20);
            Point purpose = GetStartPoint(a, b, c);

            Point result = GetResult(a, b, c, purpose);

            WritePoint(a, 'o');
            WritePoint(b, 'o');
            WritePoint(c, 'o');
            WritePoint(result, 'o');
            Console.Write(" (" + 
                Math.Round(result.x, 2) + 
                "; " +
                Math.Round(result.y, 2) + 
                "). Сумма расстояний = " + 
                Math.Round(GetSum(a, b, c, purpose), 4));

            Console.SetCursorPosition(50, 50);
            Console.ReadKey();
        }

        static void WritePoint(Point p, char letter)
        {
            int xCord = (int)Math.Round(p.x);
            int yCord = (int)Math.Round(p.y);

            Console.SetCursorPosition(xCord, yCord);
            Console.Write(letter);
        }

        static Point GetResult(Point a, Point b, Point c, Point purpose)
        {
            List<Point> pointList = new List<Point>();
            pointList.Add(a);
            pointList.Add(b);
            pointList.Add(c);
            double sum = GetSum(a, b, c, purpose);
            
            Point newPoint = new Point(purpose.x, purpose.y);
            WritePoint(purpose, 'o');
            bool globalCicleStop = true;
            int counter = 0;

            while (globalCicleStop)
            {
                for (int i = 0; i < 3; i++)
                {
                    bool cicleStop = true;

                    while (cicleStop)
                    {
                        WritePoint(purpose, ' ');

                        if (purpose.x > pointList[i].x)
                        {
                            newPoint.x = purpose.x - GetDeltaX(purpose, pointList[i]) / 10;
                        }
                        else if (purpose.x < pointList[i].x)
                        {
                            newPoint.x = purpose.x + GetDeltaX(purpose, pointList[i]) / 10;
                        }
                        else
                        {
                            newPoint.x = purpose.x;
                        }

                        if (purpose.y > pointList[i].y)
                        {
                            newPoint.y = purpose.y - GetDeltaY(purpose, pointList[i]) / 10;
                        }
                        else if (purpose.y < pointList[i].y)
                        {
                            newPoint.y = purpose.y + GetDeltaY(purpose, pointList[i]) / 10;
                        }
                        else
                        {
                            newPoint.y = purpose.y;
                        }

                        double newSum = GetSum(a, b, c, newPoint);

                        if (newSum >= sum)
                        {
                            cicleStop = false;
                        }
                        else if (newSum < sum)
                        {
                            purpose = newPoint;
                            sum = newSum;
                            WritePoint(purpose, 'o');
                        }
                    }
                }

                if (counter == 50)
                {
                    break;
                }

                counter++;
            }

            return purpose;
        }

        static Point GetStartPoint(Point a, Point b, Point c)
        {
            double xMax = 0;
            xMax = Math.Max(a.x, b.x);
            xMax = Math.Max(xMax, c.x);

            double yMax = 0;
            yMax = Math.Max(a.y, b.y);
            yMax = Math.Max(yMax, c.y);

            Point result = new Point(xMax / 2, yMax / 2);
            return result;
        }
        static double GetSum(Point a, Point b, Point c, Point purpose)
        {
            double sum = 0;
            sum += GetDistance(a, purpose);
            sum += GetDistance(b, purpose);
            sum += GetDistance(c, purpose);
            return sum;
        }
        static double GetDistance (Point a, Point b)
        {
            double deltaX = Math.Abs(a.x - b.x);
            double deltaY = Math.Abs(a.y - b.y);
            return Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));
        }

        static double GetDeltaX(Point a, Point b)
        {
            return Math.Abs(a.x - b.x);
        }
        static double GetDeltaY(Point a, Point b)
        {
            return Math.Abs(a.y - b.y);
        }


    }
}
