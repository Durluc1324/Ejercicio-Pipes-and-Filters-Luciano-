using Ucu.Poo.Cognitive;
using System.Drawing;
using CompAndDel.Pipes;

namespace CompAndDel.Filters
{
    public class FilterFaceRecognition : IConditionalFilter
    {
        public bool Result { get; private set; }

        public IPicture Filter(IPicture image)
        {
            // Guardamos temporalmente la imagen en disco para pasarle la ruta a CognitiveFace
            var provider = new PictureProvider();
            string tempPath = "temp_face_check.jpg";
            provider.SavePicture(image, tempPath);

            // Analizamos la imagen
            CognitiveFace cognitiveFace = new CognitiveFace(true, Color.GreenYellow);
            cognitiveFace.Recognize(tempPath);

            // Guardamos el resultado en la propiedad Result
            Result = cognitiveFace.FaceFound;

            // (Opcional: podrías guardar tmpFace.jpg si querés ver la detección)
            return image;
        }
    }

}