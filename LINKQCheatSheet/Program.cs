using LINKQCheatSheet;

var lawyers = new[]
{
    new Lawyer()
    {
        FirstName = "John",
        LastName = "Doe"
    },
    new Lawyer()
    {
        FirstName = "Maria",
        LastName = "Maker"
    }
};

var clients = new[]
{
    new Client()
    {
        FirstName = "Tim",
        LastName = "Funny"
    },
    new Client()
    {
        FirstName = "Jim",
        LastName = "Decker"
    },
    new Client()
    {
        FirstName = "Yana",
        LastName = "Cat"
    }
};

var cases = new[]
{
    new Case()
    {
        Title = "Car accident",
        AmmountInDispute = 10000,
        CaseType = CaseType.Commercial,
        Client = clients[0],
        Lawyer = lawyers[0]

    },
     new Case()
    {
        Title = "Molding flat",
        AmmountInDispute = 65000,
        CaseType = CaseType.ProBono,
        Client = clients[0],
        Lawyer = lawyers[0]

    },
      new Case()
    {
        Title = "Death Threat",
        AmmountInDispute = 15000,
        CaseType = CaseType.Commercial,
        Client = clients[1],
        Lawyer = lawyers[1]

    },
       new Case()
    {
        Title = "Robbery ",
        AmmountInDispute = 1500,
        CaseType = CaseType.Commercial,
        Client = clients[2],
        Lawyer = lawyers[1]

    },
};

//Where
foreach (Lawyer lawyer in lawyers)
{
    lawyer.Cases = cases.Where(c => c.Lawyer == lawyer).ToList();
}

foreach (Client client in clients)
{
    client.Cases = cases.Where(c => c.Client == client).ToList();
}

//First and Single
var workingFirstEx = lawyers.First(l => l.FirstName == "John");

try
{
    var firstExceptionExample = lawyers.First(l => l.FirstName == "Joh");
}
catch (InvalidOperationException ex)
{

    Console.WriteLine("Invalid operation exception has been thrown, cause no matching elements");
}


//FirstOrDefault return the default value for the specified datatype, if no matching elements has been found
//For classes that are null and for value type that have the default value.
//For int it is 0 tex

var firstOrDefaultExample = lawyers.FirstOrDefault(l => l.FirstName == "Joh");

//Single works like First, but ensures that only a single element matches the specified condition
var workingSingleExample = lawyers.Single(l => l.FirstName == "John");
try
{
    var singleExceptionExample = lawyers.Single(l => l.FirstName == "Joh");
}
catch (InvalidOperationException ex)
{

    Console.WriteLine("Invalid operation exception has been thrown, cause no matching elements");
}
try
{
    var singleExceptionExample = lawyers.Single(l => l.LastName.Contains("e"));
}
catch (InvalidOperationException ex)
{

    Console.WriteLine("Throws invalid operation exception, cause more then 1 element matches the contion.");
}

//SingleOrDefault returns the default value for the specified datatype, if no matching element was found.
//For classes that are null and for value type that is the default value.
//For int it is 0 tex
//Everything else works just like Single

var singleOrDefaultExample = lawyers.SingleOrDefault(l => l.FirstName == "John");

//Any and All
var proBonoLawyers = lawyers.Where(l => l.Cases.Any(c => c.CaseType == CaseType.ProBono));
var commercialOnlyLawyers = lawyers.Where(l => l.Cases.All(c => c.CaseType == CaseType.Commercial));

//working with numbers
var sumOfAmountInDispute = cases.Sum(c => c.AmmountInDispute);
var averageAmmountInDispute = cases.Average(c => c.AmmountInDispute);
var maxAmountInDispute = cases.Max(c => c.AmmountInDispute);
var minAmountInDispute = cases.Min(c => c.AmmountInDispute);

//OrderBy
//Ascending
var lawyersByAmmountInDispute = lawyers.OrderBy(l => l.Cases.Sum(c => c.AmmountInDispute));
//descending
var lawyersByAmountInDispute = lawyers.OrderByDescending(l => l.Cases.Sum(c => c.AmmountInDispute));

//Select
var caseTitles = cases.Select(c => c.Title);
var lawyersNames = lawyers.Select(l => l.FirstName + ", " + l.LastName);
//Select return a list of lists here
var casesPerLawyer = lawyers.Select(l => l.Cases);
//SelectMany returns a flattened list
var casesPerLawyerFlat = lawyers.SelectMany(l => l.Cases);

//Fluent = Chaining Linq QUeries
var caseTitleOfCOmmercialOnlyLawyers = lawyers
    .Where(l => l.Cases.All(c => c.CaseType == CaseType.Commercial))
    .SelectMany(l => l.Cases)
    .Select(c => c.Title);

//Challenge:
//1 - Order lawyers by money in dispute for commercial cases only
var challenge1 = lawyers.OrderBy(l=>l.Cases.Where(c=>c.CaseType == CaseType.Commercial).Sum(c => c.AmmountInDispute));

//2 - Select all cases from Clients as an IEnumerable<List>Case>>
var challenge2 = clients.Select(c => c.Cases);

//3  - Select all cases from Clients as a flattened list
var challenge3 = clients.SelectMany(c=> c.Cases);   

//4 - Select a list of strings containing fields: client&lawer name
var challenge4 = cases.Select(c=> c.Lawyer.FirstName + ", " + c.Lawyer.LastName +
", " + c.Client.FirstName + ", " + c.Client.LastName);  

Console.ReadLine();





