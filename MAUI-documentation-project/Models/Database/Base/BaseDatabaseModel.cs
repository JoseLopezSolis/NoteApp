namespace MAUI_documentation_project.Models.Base;

public class BaseDatabaseModel
{
    public int Id { get; set; }// Se autoincrementa automáticamente
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}