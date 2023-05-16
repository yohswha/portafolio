namespace portafolio.Models.Servicios
{
    public interface IRepositorioProyectos{
        List<Proyecto> ObtenerProyectos();
    }
    public class RepositorioProyectos : IRepositorioProyectos
    {
         public List<Proyecto> ObtenerProyectos(){
        return new List<Proyecto>(){
            new Proyecto{
                Titulo= "Amazon",
                Descripcion="E-commerce",
                ImagenUrl="./imagenes/amazon.png",
                Link="https://amazon.com"
            },
             new Proyecto{
                Titulo= "NewYorkTimes",
                Descripcion="E-commerce",
                ImagenUrl="/imagenes/nyt.png",
                Link="https://www.NewYorkTimes.com"
            },
            new Proyecto{
                Titulo= "Reddit",
                Descripcion="Red social para compartir en comunidades",
                ImagenUrl="./imagenes/reddit.png",
                Link="https://www.reddit.com"
            }
        };
    }

    }
}