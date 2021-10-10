using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;

namespace Student
{
    class Program
    {
        static void Main(string[] args)
        {
            Group group1 = new Group("K-25");
            string name1 = "Semen";
            BadStudent st1 = new BadStudent(name1);
            GoodStudent st2 = new GoodStudent(name1);
            BadStudent st3 = new BadStudent(name1);
            group1.AddStudent(st1);
            group1.AddStudent(st2);
            group1.AddStudent(st3);
            st3.Study();
            st2.Study();
            group1.GetInfo();
            group1.GetFullInfo();
        }
    }
    class Group
    {
        public Group(string _name)
        { name = _name; }
        public void AddStudent(Student st)
        {
            list.Add(st);
        }
        public void GetInfo()
        {
            Console.WriteLine("Group name: " + name);
            Console.WriteLine("Students: ");
            foreach (Student student in list) Console.Write(student.GetName() + " ");
        }
        public void GetFullInfo()
        {
            Console.WriteLine("Group name: " + name);
            Console.WriteLine("Students: ");
            foreach (Student student in list) { 
                Console.Write(student.GetName() + " "); 
                Console.Write(student.GetState() + "\n");   
            };
        }
        private string name;
        private List<Student> list = new List<Student>(3);
    }
    abstract class Student
    {
        private string name;
        protected string state;
        protected void Read() { state += "read "; }
        protected void Write() { state += "write "; }
        protected void Relax() { state += "relax "; }
        public Student(string _name) { name = _name; state = ""; }
        public abstract void Study();
        public string GetName() { return name; }
        public string GetState() { return state; }
    }
    class GoodStudent : Student
    {
        public GoodStudent(string _name) : base(_name) 
        {
            state = "good "; 
        }
        override public void Study() { Read(); Write(); Read(); Write(); Relax(); }
    }
    class BadStudent : Student
    {
        public BadStudent(string _name) : base(_name)
        {
            state = "bad ";
        }
        override public void Study() { Relax(); Relax(); Relax(); Relax(); Read(); }
    }
}
