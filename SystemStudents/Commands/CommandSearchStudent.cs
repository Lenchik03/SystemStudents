class CommandSearchStudent : CommandUser
{
    private StudentDB studentDB;

    public CommandSearchStudent(StudentDB studentDB)
    {
        this.studentDB = studentDB;
    }

    public override void Execute()
    {
        Console.WriteLine("Поиск студента...");
        string search = Console.ReadLine();
        List<Student> searchStudent = studentDB.Search(search);

        foreach (Student student in searchStudent)
        {
            Console.WriteLine(student.UID + " - " + student.FirstName + " " + student.LastName);
        }
    }
}
