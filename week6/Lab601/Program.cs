﻿using System;
 
namespace Lab601
{
  class MainApp
  {
    public static void Main()
    {
      ContinentFactory africa = new AfricaFactory();
      AnimalWorld world = new AnimalWorld(africa);
      world.RunFoodChain();
 
      ContinentFactory america = new AmericaFactory();
      world = new AnimalWorld(america);
      world.RunFoodChain();

      ContinentFactory america = new AmericaFactory();
      world = new AnimalWorld(america);
      world.RunFoodChain();
      
      // Wait for user input
       Console.ReadKey();
    }
  }
 
  abstract class ContinentFactory
  {
    public abstract Herbivore CreateHerbivore();
    public abstract Carnivore CreateCarnivore();
  }
  class AsiaFactory : ContinentFactory
    {
        public override Herbivore CreateHerbivore()
        {
            return new Rabbit();
        }
        public override Carnivore CreateCarnivore()
        {
            return new Fox();
        }
    }
    class Rabbit : Herbivore
    {
    }
    class Fox : Carnivore
    {
        public override void Eat(Herbivore h)
        {
            // Eats Rabbit
            Console.WriteLine(this.GetType().Name +
              " eats " + h.GetType().Name);
        }
    }
    class AfricaFactory : ContinentFactory
  {
    public override Herbivore CreateHerbivore()
    {
      return new Wildebeest();
    }
    public override Carnivore CreateCarnivore()
    {
      return new Lion();
    }
  }
  class AmericaFactory : ContinentFactory
  {
    public override Herbivore CreateHerbivore()
    {
      return new Bison();
    }
    public override Carnivore CreateCarnivore()
    {
      return new Wolf();
    }
  }
 
  abstract class Herbivore
  {
  }
 
  abstract class Carnivore
  {
    public abstract void Eat(Herbivore h);
  }
 
  class Wildebeest : Herbivore
  {
  }

  class Lion : Carnivore
  {
    public override void Eat(Herbivore h)
    {
      // Eats Wildebeest
      Console.WriteLine(this.GetType().Name +
        " eats " + h.GetType().Name);
    }
  }
 
  class Bison : Herbivore
  {
  }
 
  class Wolf : Carnivore
  {
    public override void Eat(Herbivore h)
    {
      // Eats Bison
      Console.WriteLine(this.GetType().Name +
        " eats " + h.GetType().Name);
    }
  }
 
  class AnimalWorld
  {
    private Herbivore _herbivore;
    private Carnivore _carnivore;
 
    // Constructor
    public AnimalWorld(ContinentFactory factory)
    {
      _carnivore = factory.CreateCarnivore();
      _herbivore = factory.CreateHerbivore();
    }
 
    public void RunFoodChain()
    {
      _carnivore.Eat(_herbivore);
    }
   }
 }
  