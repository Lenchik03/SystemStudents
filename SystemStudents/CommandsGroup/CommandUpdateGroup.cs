class CommandUpdateGroup : CommandUser
{
    private GroupDB groupDB;

    public CommandUpdateGroup(GroupDB groupDB)
    {
        this.groupDB = groupDB;
    }

    public override void Execute()
    {
        Console.WriteLine("Редактирование группу...");
        string search = Console.ReadLine();
        List<Group> searchGroup = groupDB.Search("");

        for (int i = 0; i < searchGroup.Count; i++)
        {
            Console.WriteLine($"{i + 1}  {searchGroup[i].NumberGroup}");
        }

        Console.WriteLine("Введите порядковый номер...");
        int num = int.Parse(Console.ReadLine()) - 1;
        Group edit = searchGroup[num];
        Console.WriteLine("Введите новый номер группы");
        edit.NumberGroup = Console.ReadLine();

        groupDB.Update(edit);



    }
}
