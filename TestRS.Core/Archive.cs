namespace TestRS.Core;
public class Archive
{
    public Guid Id { get; set; }
    public string FileName { get; set; }
    public DateTime UploadedDate { get; set; }
    public int ArchiveTime { get; set; }
    public bool Status { get; set; }
    public byte[] Data { get; set; }
}
