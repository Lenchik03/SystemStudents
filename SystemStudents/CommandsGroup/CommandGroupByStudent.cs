class CommandGroupByStudent : CommandUser
{
    private StudentDB studentDB;
    private StudentGroupDB studentGroupDB;

    public CommandGroupByStudent(StudentDB studentDB, StudentGroupDB studentGroupDB)
    {
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

        Student groupByStudent = searchStudent.FirstOrDefault(s => s.UID == studentUID);

        Group grouprezult = studentGroupDB.GroupByStudent(groupByStudent);
        Console.WriteLine(grouprezult.UID + " - " +grouprezult.NumberGroup);
    }
}