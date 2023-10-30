class CommandDeleteStudent : CommandUser
{
    private StudentDB studentDB;

    public CommandDeleteStudent(StudentDB studentDB)
    {
        this.studentDB = studentDB;
    }

    public override void Execute()
    {
        Console.WriteLine("Удаление студента...");
        Console.WriteLine("Введите ID...");
        string uid = Console.ReadLine();
        bool deleteStudent = studentDB.Delete(uid);
        Console.WriteLine("Студент удален");
    }
}
