namespace UnhingedLibrary.Models;

public class SignOffModel
{
    public int Id { get; set; }
    public string? SignOff { get; set; }
    public string? Author { get; set; }
    public bool Approved { get; set; }
    public bool Deleted {  get; set; }
}
