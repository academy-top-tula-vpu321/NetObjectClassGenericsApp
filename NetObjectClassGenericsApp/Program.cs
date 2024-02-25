Passport<int> passport1 = new Passport<int>() { Series = 123 };
Passport<string> passport2 = new Passport<string>() { Series = "123" };



class PersonDocument<T>
{
    public T Series { get; set; }
    public int Number { get; set; }
}

class Passport<T> : PersonDocument<T>
{
    public string Address { get; set; }
}

class RussiaPassport : Passport<int>
{
    
}









