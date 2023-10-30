class CommandUpdateStudent : CommandUser
{
    private StudentDB studentDB;

    public CommandUpdateStudent(StudentDB studentDB)
    {
        this.studentDB = studentDB;
    }

    public override void Execute()
    {
        Console.WriteLine("Редактирование студента...");
        //string search = Console.ReadLine();
        List<Student> searchStudent = studentDB.Search("");
        
        for(int i =0; i < searchStudent.Count; i++)
        {
            Console.WriteLine($"{i+1}  {searchStudent[i].LastName}");
        }

        Console.WriteLine("Введите номер студента...");
        int num = int.Parse( Console.ReadLine())-1;
        Student edit = searchStudent[num];
        Console.WriteLine("Введите новое имя");
        edit.FirstName = Console.ReadLine();

        Console.WriteLine("Введите новую фамилию");
        edit.LastName = Console.ReadLine();




        studentDB.Update(edit);

        
        
    }
}
