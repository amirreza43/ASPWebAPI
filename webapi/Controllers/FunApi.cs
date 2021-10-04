using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;


namespace FunController
{
    
    [ApiController]
    [Route("api")]
    public class FunApi : ControllerBase
    {

        [HttpGet("converter/inchToCm/{number}")]
        public ActionResult<double> GetCm(double number){

            var cm = number*2.54;

            return cm;

        }

        [HttpGet("converter/fahToCel/{number}")]
        public ActionResult<double> GetCel(double number){

            var cel = (number-32)*0.5556;

            return cel;

        }

        [HttpGet("nameArray/{number}/{name}")]
        public ActionResult<List<string>> GetArray(int number, string name){

            List<string> nameArray = new List<string>{};
            for(int i = 0; i < number; i++){
                var j = i+1;
                nameArray.Add($"{name}{j}");
            }

            return nameArray;

        }

        [HttpGet("reverse/{input}")]
        public ActionResult<string> GetReverse(string input){

           char[] output = input.ToCharArray();
           Array.Reverse(output);

            return new string( output );

        }

        [HttpGet("createDog/{name}/{age}/{breed}")]
        public ActionResult<Dog> GetDogObject(string name, int age, string breed){

           Dog dog = new Dog(age, name, breed);

            return dog;

        }

        [HttpGet("createDogList/{name}/{age}/{breed}/{number}")]
        public ActionResult<IEnumerable<Dog>> GetDogList(string name,
        int age,
        string breed,
        int number){

           List<Dog> dogs = new List<Dog>{};

           for (int i = 0; i < number; i++)
           {
               dogs.Add(new Dog(age, name, breed));
           }

            return dogs;

        }



    }

    public class Dog{
        public string Name {get; set;}
        public int Age {get; set;}
        public string Breed {get; set;}
        public Dog(int age, string name, string breed){
            Age = age;
            Name = name;
            Breed = breed;
        }
    }

}