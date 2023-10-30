class StudentGroup : CommandUser
{
    private GroupDB groupDB;
    private StudentDB studentDB;
    private StudentGroupDB studentGroupDB;

    public StudentGroup(GroupDB groupDB, StudentDB studentDB, StudentGroupDB studentGroupDB)
    {
        this.groupDB = groupDB;
        this.studentDB = studentDB;
        this.studentGroupDB = studentGroupDB;
    }

    public override void Execute()
    {
        List<Student> searchStudent = studentDB.Search("");

        foreach (Student student in searchStudent)
        {
            Console.WriteLine(student.UID + " - " + student.FirstName + " " + student.LastName);
        }
        Console.WriteLine("Введите UID студента...");
        string studentUID = Console.ReadLine();

        List<Group> searchGroup = groupDB.Search("");

        foreach (Group group in searchGroup)
        {
            Console.WriteLine(group.UID + " - " + group.NumberGroup);
        }
        Console.WriteLine("Введите UID группы...");
        string groupUID = Console.ReadLine();

        Group groupOfStudents =  searchGroup.FirstOrDefault(s => s.UID == groupUID);
        Student studentOfGroup = searchStudent.FirstOrDefault(s => s.UID == studentUID);

        studentGroupDB.StudentGroup(studentOfGroup, groupOfStudents);
    }
}