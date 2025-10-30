using System;
namespace CompAndDel.Pipes
{
    public class PipeConditionalFork : IPipe
    {
        private IConditionalFilter conditionalFilter;
        private IPipe truePipe;
        private IPipe falsePipe;

        public PipeConditionalFork(IConditionalFilter conditionalFilter, IPipe truePipe, IPipe falsePipe)
        {
            this.conditionalFilter = conditionalFilter;
            this.truePipe = truePipe;
            this.falsePipe = falsePipe;
        }

        public IPicture Send(IPicture picture)
        {
            // Se aplica el filtro que detecta si hay rostro o no
            IPicture filtered = conditionalFilter.Filter(picture);

            // Según el resultado, se elige el camino deseado
            if (conditionalFilter.Result)
            {
                Console.WriteLine("Rostro detectado: enviando por el camino TRUE");
                return truePipe.Send(filtered);
            }
            else
            {
                Console.WriteLine("No se detectó rostro: enviando por el camino FALSE");
                return falsePipe.Send(filtered);
            }
        }
    }

}