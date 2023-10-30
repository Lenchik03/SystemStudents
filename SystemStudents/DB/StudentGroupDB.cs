using System.Text.Json;

class StudentGroupDB
{

    private StudentDB studentDB;
    private GroupDB groupDB;

    Dictionary<string, string> studentGroup = new Dictionary<string, string>();
    Dictionary<string, List<string>> groupStudents = new Dictionary<string, List<string>>();

    public StudentGroupDB(StudentDB studentDB, GroupDB groupDB)
    {
        this.studentDB = studentDB;
        this.groupDB = groupDB;

        if (!File.Exists("students.json"))
            studentGroup = new Dictionary<string, string>();
        else
            using (FileStream fs = new FileStream("students.json", FileMode.OpenOrCreate))
            {
                studentGroup = JsonSerializer.Deserialize<Dictionary<string, string>>(fs);
            }

        if (!File.Exists("groups.json"))
            groupStudents = new Dictionary<string, List<string>>();
        else
            using (FileStream fs = new FileStream("groups.json", FileMode.OpenOrCreate))
            {
                groupStudents = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(fs);
            }
    }
    

    public void StudentGroup(Student student, Group group)
    {
        if (studentGroup.ContainsKey(student.UID))
        {
            Group group1 =  GroupByStudent(student);
            groupStudents[group1.UID].Remove(student.UID);
            studentGroup[student.UID] = group.UID;
        }
        else
            studentGroup.Add(student.UID, group.UID);

        if(groupStudents.ContainsKey(group.UID))
            groupStudents[group.UID].Add(student.UID);
        else
        {
           groupStudents.Add(group.UID, new List<string> { student.UID });
        }
        Save();

    }

    public Group GroupByStudent(Student student)
    {
        string groupUID = studentGroup[student.UID];

        List<Group> searchGroup = groupDB.Search("");

        Group groupByStudent = searchGroup.FirstOrDefault(s => s.UID == groupUID);

        return groupByStudent;
    }


    public List<Student> StudentsByGroup(Group group)
    {
        List<string> studentsUID = groupStudents[group.UID];

        List<Student> searchStudent = studentDB.Search("");

        List<Student> studentsByGroup = new List<Student>();

        foreach (var studentUID in studentsUID)
        {
            studentsByGroup.Add(searchStudent.FirstOrDefault(s => s.UID == studentUID));
        }
        return studentsByGroup;
    }

    void Save()
    {
        using (FileStream fs = new FileStream("students.json", FileMode.Create))
        {
            JsonSerializer.Serialize(fs, studentGroup);
            Console.WriteLine("Сохранено");
        }

        using (FileStream fs = new FileStream("groups.json", FileMode.Create))
        {
            JsonSerializer.Serialize(fs, groupStudents);
            Console.WriteLine("Сохранено");
        }
        // save file (json)
    }


}
