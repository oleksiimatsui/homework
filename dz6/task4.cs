﻿using System;
namespace Decorator.Examples
{
    class MainApp
    {
        static void Main()
        {
            // Create ConcreteComponent and two Decorators
            ChristmasTree c = new ChristmasTree();  //create tree
            Balls d1 = new Balls();     //create balls
            Garland d2 = new Garland();     //create garland 

            // Link decorators
            d1.SetComponent(c);     //balls with tree
            d2.SetComponent(d1);    //garland with balls and tree

            d2.Operation();

            // Wait for user
            Console.Read();
        }
    }
    // "Component"
    abstract class Tree
    {
        public abstract void Operation();
    }

    // "ConcreteComponent"
    class ChristmasTree : Tree
    {
        public override void Operation()
        {
            Console.WriteLine("ChristmasTree.Operation()");
        }
    }
    // "Decorator"
    abstract class Decorator : Tree
    {
        protected Tree component;

        public void SetComponent(Tree component)
        {
            this.component = component;
        }
        public override void Operation()
        {
            if (component != null)
            {
                component.Operation();
            }
        }
    }

    // "ConcreteDecoratorA"
    class Balls : Decorator
    {
        private string addedState;

        public override void Operation()
        {
            base.Operation();
            addedState = "New State";
            Console.WriteLine("Balls.Operation()");
        }
    }

    // "ConcreteDecoratorB" 
    class Garland : Decorator
    {
        public override void Operation()
        {
            base.Operation();
            AddedBehavior();
            Console.WriteLine("Garland.Operation()");
        }
        void AddedBehavior()
        {
            Console.WriteLine("lighting");
        }
    }
}