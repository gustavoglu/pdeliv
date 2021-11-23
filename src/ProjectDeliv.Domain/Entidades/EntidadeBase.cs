namespace ProjectDeliv.Domain.Entidades
{
    public abstract class EntidadeBase
    {
        public EntidadeBase()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public bool Deletado { get; set; }
        public string? InseridoPor { get; set; }
        public DateTime? InseridoEm { get; set; }
        public string? AtualizadoPor { get; set; }
        public DateTime? AtualizadoEm { get; set; }
        public string? DeletadoPor { get; set; }
        public DateTime? DeletadoEm { get; set; }

    }
}
