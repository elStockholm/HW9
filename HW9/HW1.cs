using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW9
{
    //Создать класс Figure для работы с геометрическими фигурами. В качестве полей класса задаются цвет фигуры, состояние «видимое/невидимое».
    //Реализовать операции: передвижение геометрической фигуры по горизонтали, по вертикали, изменение цвета, опрос состояния (видимый/невидимый).
    //Метод вывода на экран должен выводить состояние всех полей объекта. Создать класс Point (точка) как потомок геометрической фигуры.
    //Создать класс Circle (окружность) как потомок точки. В класс Circle добавить метод, который вычисляет площадь окружности.
    //Создать класс Rectangle (прямоугольник) как потомок точки, реализовать метод вычисления площади прямоугольника.
    //Точка, окружность, прямоугольник должны поддерживать методы передвижения по горизонтали и вертикали, изменения цвета.
    //Подумать, какие методы можно объявить в интерфейсе, нужно ли объявлять абстрактный класс, какие методы и поля будут в абстрактном классе, какие
    //методы будут виртуальными, какие перегруженными.

    interface IMovable
    {
        void MoveHorizontal(int dx);
        void MoveVertical(int dy);
    }

    abstract class Figure : IMovable
    {
        protected string color = "Черный";
        protected bool isVisible = true;

        public abstract void MoveHorizontal(int dx);
        public abstract void MoveVertical(int dy);

        public void ChangeColor(string newColor)
        {
            color = newColor;
        }

        public void ChangeColor()
        {
            color = "Черный";
        }

        public bool IsVisible()
        {
            return isVisible;
        }

        public virtual void Print()
        {
            Console.WriteLine($"Цвет: {color}, Видимый: {isVisible}");
        }
    }

    class Point : Figure
    {
        protected int x;
        protected int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override void MoveHorizontal(int dx)
        {
            x += dx;
        }

        public override void MoveVertical(int dy)
        {
            y += dy;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Координаты: ({x}; {y})");
        }
    }

    class Circle : Point
    {
        private double r;

        public Circle(int x, int y, double r) : base(x, y)
        {
            this.r = r;
        }

        public double GetArea()
        {
            return Math.PI * r * r;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Радиус: {r}, Площадь: {GetArea()}");
        }
    }

    class Rectangle : Point
    {
        private double a;
        private double b;

        public Rectangle(int x, int y, double a, double b) : base(x, y)
        {
            this.a = a;
            this.b = b;
        }

        public double GetArea()
        {
            return a * b;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Стороны: {a} и {b}, Площадь: {GetArea()}");
        }
    }

    class Program
    {
        static void Main()
        {
            Point p = new Point(1, 2);
            p.ChangeColor("Красный");
            p.MoveHorizontal(5);
            p.Print();

            Console.WriteLine();

            Circle c = new Circle(0, 0, 3);
            c.ChangeColor("Синий");
            c.MoveVertical(4);
            c.Print();

            Console.WriteLine();

            Rectangle rect = new Rectangle(2, 5, 4, 6);
            rect.Print();
            Console.WriteLine("Видимость: " + rect.IsVisible());
        }
    }
}