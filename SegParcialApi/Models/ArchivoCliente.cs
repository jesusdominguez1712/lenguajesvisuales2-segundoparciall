using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ArchivoCliente
{
    [Key]
    public int IdArchivo { get; set; }

    [ForeignKey("Cliente")]
    public string CICliente { get; set; }

    public string NombreArchivo { get; set; }
    public string UrlArchivo { get; set; }

    public Cliente Cliente { get; set; }
}
