using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Ejercicio 2:
            
            PipeNull pipeNull = new PipeNull();

            // Aplica el filtro negativo y luego guarda
            PipeSerial pipeNegative = new PipeSerial(new FilterNegative(), pipeNull);

            // Guarda después del filtro de escala de grises
            PipeSerial pipeSaveGray = new PipeSerial(new FilterSave(@"luke_gray_scale_save.jpg"), pipeNegative);

            // Aplica el filtro de escala de grises
            PipeSerial pipeGreyscale = new PipeSerial(new FilterGreyscale(), pipeSaveGray);

            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"luke.jpg");

            // Ejecuta toda la secuencia
            IPicture result = pipeGreyscale.Send(picture);

            // Guardado final del proceso
            provider.SavePicture(result, @"luke_final.jpg");
            */
            
            PipeNull pipeNull = new PipeNull();

            PipeSerial pipeTwitter = new PipeSerial(new FilterTwitter("Hay una cara aquí"), pipeNull);
            PipeSerial pipeNegative = new PipeSerial(new FilterNegative(), pipeNull);

            FilterFaceRecognition faceFilter = new FilterFaceRecognition();
            PipeConditionalFork bifurcacion = new PipeConditionalFork(faceFilter, pipeTwitter, pipeNegative);

            PipeSerial pipeGreyscale = new PipeSerial(new FilterGreyscale(), bifurcacion);

            PictureProvider provider = new PictureProvider();
            string[] paths = { @"luke.jpg", @"beer.jpg" };
            
            
            foreach (var path in paths)
            {
                IPicture picture = provider.GetPicture(path);

                //Ejecuta todo el flujo de código para cada imagen
                pipeGreyscale.Send(picture);
            }

        }
    }
}
