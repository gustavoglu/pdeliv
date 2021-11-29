namespace ProjectDeliv.Domain.Util
{
    public class Paginacao<T>
    {
        public Paginacao(IEnumerable<T> data, int limite, int pagina, long total)
        {
            Data = data;
            Limite = limite;
            Pagina = pagina;
            Total = total;

            PaginasTotal = CalculaPaginasTotal();
        }

        private int CalculaPaginasTotal()
        {
            decimal total = decimal.Parse(Total.ToString());
            decimal limite = decimal.Parse(Limite.ToString());

            var res = total / limite;

            if (res <= 0) return 1;

            var ceiling = Math.Ceiling(res);

            return int.Parse(ceiling.ToString());
        }

        public IEnumerable<T> Data { get; set; }
        public int Limite { get; set; }
        public int Pagina { get; set; }
        public int PaginasTotal { get; set; }
        public long Total { get; set; }
    }
}
