namespace CompAndDel.Filters
{
    ///Para el ejercicio 2
    ///Se crea esta clase para no alterar el Send de los PipeSerial, que fue la primera idea que se me ocurrió.
    /// Este filtro implementa IFilter y se encarga de guardar las fotos 
    
    public class FilterSave: IFilter
    {
        private string path;

        public FilterSave(string path)
        {
            this.path = path;
        }

        public IPicture Filter(IPicture image)
        {
            PictureProvider provider = new PictureProvider();
            provider.SavePicture(image, path);

            return image;
        }
    }
}