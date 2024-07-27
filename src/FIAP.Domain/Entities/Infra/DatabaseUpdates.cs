using FIAP.Domain.Entities.Base;

namespace FIAP.Domain.Entities.Infra;

public class DatabaseUpdates : EntityBase<long>
{
    /// <summary>
    /// Data de que foi realziada o update
    /// </summary>
    /// <value></value>
    public DateTime Created { get; set; }

    /// <summary>
    /// Nome do arquivo
    /// </summary>
    /// <value></value>
    public string FileName { get; set; }

    /// <summary>
    /// Conteúdo do arquivo executado
    /// </summary>
    /// <value></value>
    public string Content { get; set; }
}