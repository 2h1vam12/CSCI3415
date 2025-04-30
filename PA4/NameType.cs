public struct NameType
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public NameType(string first, string last)
    {
        FirstName = first;
        LastName = last;
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }
}


