using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace backend.Classes;

[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
public class StudentForm
{
    [JsonIgnore] public int? Id { get; set; }
    public string? Nume { get; set; }
    public string? Prenume { get; set; }
    public string? Facultate { get; set; }
    public string? Motivatie { get; set; }
    public DateTime? DataSubmisiei { get; set; }
}