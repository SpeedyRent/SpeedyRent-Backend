namespace Presentation.SpeedyRent.Resources;

public class PostResource
{
    public int Id { get; set; }          // Identificador único del post
    public string Title { get; set; }    // Título del post
    public string Content { get; set; }  // Contenido del post
    public int AuthorId { get; set; }    // Identificador del autor del post
    public DateTime CreatedAt { get; set; } // Fecha de creación del post
    public DateTime UpdatedAt { get; set; } // Fecha de la última actualización del post
}