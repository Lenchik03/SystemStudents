using System.Collections.Generic;
using System.Text.Json;

class StudentDB
{
    Dictionary<string, Student> students;
    
    public StudentDB()
    {
        //load file (json)
        if (!File.Exists("file.json"))
            students = new Dictionary<string, Student>();
        else
        {
            using (var fs = File.OpenRead("file.json"))
            {
                students = JsonSerializer.Deserialize<Dictionary<string, Student>>(fs);
                
            }
        }
    }

    public List<Student> Search(string text)
    {
        List<Student> result = new();
        foreach (var student in students.Values)
        {
            if (student.FirstName.Contains(text) ||
                    student.LastName.Contains(text))
                result.Add(student);
        }
        return result;
    }

    public bool Update(Student student)
    {
        if (!students.ContainsKey(student.UID))
            return false;
        students[student.UID] = student;
        Save();
        return true;
    }

    public Student Create()
    {
        Student newStudent = new Student {  UID = Guid.NewGuid().ToString()};
        students.Add(newStudent.UID, newStudent);
        return newStudent;
    }

    public bool Delete(string uid)
    {
        if (!students.ContainsKey(uid))
            return false;
        students.Remove(uid);
        Save();
        return true;
    }

    void Save()
    {
        using(FileStream fs = new FileStream("file.json", FileMode.OpenOrCreate))
        {
            JsonSerializer.Serialize(fs, students);
            Console.WriteLine("Сохранено");
        }
        // save file (json)
    }
}
