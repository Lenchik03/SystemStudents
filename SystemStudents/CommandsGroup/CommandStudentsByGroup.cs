class CommandStudentByGroup : CommandUser
{
    private GroupDB groupDB;
    private StudentGroupDB studentGroupDB;

    public CommandStudentByGroup(GroupDB groupDB,StudentGroupDB studentGroupDB)
    {
        this.groupDB = groupDB;
        this.studentGroupDB = studentGroupDB;
    }

    public override void Execute()
    {
        List<Group> searchGroup = groupDB.Search("");

        foreach (Group group in searchGroup)
        {
            Console.WriteLine(group.UID + " - " + group.NumberGroup);
        }

        Console.WriteLine("Введите UID группы...");
        string groupUID = Console.ReadLine();

        Group groupOfStudents = searchGroup.FirstOrDefault(s => s.UID == groupUID);

        List<Student> studentsByGroup = studentGroupDB.StudentsByGroup(groupOfStudents);

        foreach (Student student in studentsByGroup)
        {
            Console.WriteLine(student.UID + " - " + student.FirstName + " " + student.LastName);
        }


    }
}