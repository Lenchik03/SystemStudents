using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Linq;

class Program
{
    public static void Main()
    {
        CommandManager commandManager = new CommandManager();
        StudentDB studentDB = new StudentDB();
        GroupDB groupDB = new GroupDB();
        StudentGroupDB studentGroupDB = new StudentGroupDB(studentDB, groupDB);
        commandManager.RegisterCommand("Create", new CommandCreateStudent(studentDB, groupDB));
        commandManager.RegisterCommand("Search", new CommandSearchStudent(studentDB));
        commandManager.RegisterCommand("Delete", new CommandDeleteStudent(studentDB));
        commandManager.RegisterCommand("Update", new CommandUpdateStudent(studentDB));

        commandManager.RegisterCommand("Create Group", new CommandCreateGroup(groupDB));
        commandManager.RegisterCommand("Search Group", new CommandSearchGroup(studentDB, groupDB));
        commandManager.RegisterCommand("Student Group", new StudentGroup(groupDB, studentDB, studentGroupDB));
        commandManager.RegisterCommand("Students by group", new CommandStudentByGroup(groupDB, studentGroupDB));
        commandManager.RegisterCommand("Group by student", new CommandGroupByStudent(studentDB, studentGroupDB));

        // добавить команды:
        // Search - поиск студентов по имени/фамилии, должен выводиться UID
        // Delete - удаление выбранного студента (по UID или порядковому номеру в выведенном списке)
        // Edit - редактирование выбранного студента
        commandManager.Start();
    }

}
