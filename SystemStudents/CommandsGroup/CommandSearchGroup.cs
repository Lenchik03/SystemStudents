class CommandSearchGroup : CommandUser
{
    private StudentDB studentDB;
    private GroupDB groupDB;

    public CommandSearchGroup(StudentDB studentDB, GroupDB groupDB)
    {
        this.studentDB = studentDB;
        this.groupDB = groupDB;
    }

    public override void Execute()
    {
        Console.WriteLine("Поиск группы...");
        string num = Console.ReadLine();
        List<Group> searchGroup = groupDB.Search(num);

        foreach (Group group in searchGroup)
        {
            Console.WriteLine(group.UID);
        }

        List<Student> searchStudent = studentDB.Search("");

        for (int i = 0; i < searchStudent.Count; i++)
        {
            Console.WriteLine($"{i + 1}  {searchStudent[i].LastName}");
        }
    }
}