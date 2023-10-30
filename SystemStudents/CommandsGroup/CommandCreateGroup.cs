class CommandCreateGroup : CommandUser
{
    private GroupDB groupDB;

    public CommandCreateGroup(GroupDB groupDB)
    {
        this.groupDB = groupDB;
    }

    public override void Execute()
    {
        Console.WriteLine("Создание группы...");
        Group newGroup = groupDB.Create();
        Console.WriteLine("Укажите номер...");
        newGroup.NumberGroup = Console.ReadLine();
        if (groupDB.Update(newGroup))
            Console.WriteLine("Группа создана!");
        else
            Console.WriteLine("Возникли необъяснимые ошибки! Информация потеряна.");
    }
}

