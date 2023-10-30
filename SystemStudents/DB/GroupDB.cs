using System.Collections.Generic;
using System.Text.Json;

class GroupDB
{
    Dictionary<string, Group> groups;

    public GroupDB()
    {
        //load file (json)
        if (!File.Exists("fileg.json"))
            groups = new Dictionary<string, Group>();
        else
        {
            using (var fs = File.OpenRead("fileg.json"))
            {
                groups = JsonSerializer.Deserialize<Dictionary<string, Group>>(fs);

            }
        }
    }

    public List<Group> Search(string num)
    {
        List<Group> result = new();
        foreach (var group in groups.Values)
        {
            if (group.NumberGroup.Contains(num))
                result.Add(group);
        }
        return result;
    }

    public bool Update(Group group)
    {
        if (!groups.ContainsKey(group.UID))
            return false;
        groups[group.UID] = group;
        Save();
        return true;
    }


    public Group Create()
    {
        Group newGroup = new Group { UID = Guid.NewGuid().ToString() };
        groups.Add(newGroup.UID, newGroup);
        return newGroup;
    }

    public bool Delete(string uid)
    {
        if (!groups.ContainsKey(uid))
            return false;
        groups.Remove(uid);
        Save();
        return true;
    }



    void Save()
    {
        using (FileStream fs = new FileStream("fileg.json", FileMode.OpenOrCreate))
        {
            JsonSerializer.Serialize(fs, groups);
            Console.WriteLine("Сохранено");
        }
        // save file (json)
    }
}
