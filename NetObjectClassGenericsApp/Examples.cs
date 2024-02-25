using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetObjectClassGenericsApp
{
    static class Examples
    {
        public static void ObjectMetodsExample()
        {
            Employee employee = new() { Name = "Bobby", Age = 25 };

            Console.WriteLine(employee);

            Employee bob = new() { Name = "Bobby", Age = 25 };

            Console.WriteLine(employee == bob);

            //Console.WriteLine(employee.GetType().Equals(new Employee()));

        }

        public static void GenericsExamples()
        {
            //Person[] persons = new Person[]
            //{
            //    new() { Id = 123, Name = "Bob", Age = 35 },
            //    new() { Id = "123", Name = "Tom", Age = 35 },
            //};

            //int number;
            //foreach (Person person in persons)
            //    number = (int)person.Id;


            Person<int> person = new();
            Person<Passport<string, int>> person2 = new();
            Person<int> tom = new();

            Passport<int, int> rfPassport = new();

            int x = 30;
            int y = 50;
            Swap<int>(ref x, ref y);


            Person<int> p1 = new();
            Person<int> p2 = new();
            Swap<Person<int>>(ref p1, ref p2);


            void Swap<T>(ref T a, ref T b)
            {
                T temp = a;
                a = b;
                b = temp;
            }
        }
        public static void WhereExample()
        {
            SendMessage(new Message("Hello world"));

            SendMessage(new EmailMessage("Email Hello"));
            SendMessage(new SmsMessage("Sms Hello"));


            void SendMessage<T>(T message) where T : Message
            {
                Console.WriteLine($"Message: {message.Text} send!");
            }
        }
    }
}

class Employee
{
    public string Name { set; get; } = "";
    public int Age { set; get; }

    //public void Print()
    //{
    //    Console.WriteLine($"Name: {Name}, Age: {Age}");
    //}

    public override string ToString()
    {
        return $"Name: {Name}, Age: {Age}";
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode() + Age.GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        if (obj is Employee employee)
        {
            return this.GetHashCode() == employee.GetHashCode();
        }

        return false;
    }
}

class Person<T>
{
    public T Id { get; set; }
    public string Name { set; get; } = "";
    public int Age { set; get; }

    public static void Method() { }
}

class Passport<T1, T2>
{
    public T1 Series { set; get; }
    public T2 Number { set; get; }
}



class Messanger<T> where T : Message
{
    T message;
    public Messanger(T message)
    {
        this.message = message;
    }

    public void Send()
    {
        Console.WriteLine($"Message: {this.message.Text} send!");
    }
}

class Message
{
    public string Text { set; get; }
    public Message(string text)
    {
        Text = text;
    }
}

class EmailMessage : Message
{
    public EmailMessage(string text) : base(text) { }
}

class SmsMessage : Message
{
    public SmsMessage(string text) : base(text) { }
}
