using System.Text.Json.Serialization;

public class TaskItem
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("task")]
    public string Task { get; set; }

    [JsonPropertyName("completed")]
    public bool Completed { get; set; }

    [JsonPropertyName("createdDate")]
    public DateTime CreatedDate { get; set; }

    public TaskItem()
    {
        Task = string.Empty;
        CreatedDate = DateTime.Now;
    }

    public TaskItem(int id, string task, bool completed = false)
    {
        Id = id;
        Task = task;
        Completed = completed;
        CreatedDate = DateTime.Now;
    }

    public override string ToString()
    {
        string status = Completed ? "Done" : "Not Done";
        return $"[ID: {Id}] {Task} - {status} (Created on: {CreatedDate:mm/dd/yyyy})";
    }
}