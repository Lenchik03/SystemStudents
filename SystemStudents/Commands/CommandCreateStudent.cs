class CommandCreateStudent : CommandUser
{
    private StudentDB studentDB;
    private GroupDB groupDB;

    public CommandCreateStudent(StudentDB studentDB, GroupDB groupDB)
    {
        this.studentDB = studentDB;
        this.groupDB = groupDB;
    }

    
    public override void Execute()
    {
        Console.WriteLine("Создание студента...");
        Student newStudent = studentDB.Create();
        Console.WriteLine("Укажите имя...");
        newStudent.FirstName = Console.ReadLine();
        Console.WriteLine("Укажите фамилию...");
        newStudent.LastName = Console.ReadLine();

        List<Group> searchGroup = groupDB.Search("");

        for (int i = 0; i < searchGroup.Count; i++)
        {
            Console.WriteLine($"{i + 1}  {searchGroup[i].NumberGroup}");
        }
        //while (true)
        //{
        //    Console.WriteLine("Укажите группу...");
        //    newStudent.NumberGroup = Console.ReadLine();

        //    Group group = searchGroup.FirstOrDefault(s => s.NumberGroup == newStudent.NumberGroup);
        //    if(group != null)
        //        break;
        //    else
        //        Console.WriteLine("Error!!!");
        //}
        if (studentDB.Update(newStudent))
            Console.WriteLine("Студент создан!");
        else
            Console.WriteLine("Возникли необъяснимые ошибки! Информация потеряна.");
    }
}
