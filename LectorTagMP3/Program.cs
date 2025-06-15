using Id3v1Tagespacio;
using System.Text;
Console.WriteLine("Ingrese la ruta del archivo MP3:");
string? path = Console.ReadLine();

if (File.Exists(path))
{
    byte[] buffer = new byte[128];
    using (FileStream MiMP3 = new FileStream(path, FileMode.Open))
    {
        MiMP3.Seek(-128, SeekOrigin.End);
        MiMP3.Read(buffer, 0, 128);
        var tag = new Id3v1Tag();

        tag.Titulo = Encoding.Default.GetString(buffer, 3, 30).Trim('\0',' ');
        tag.Artista = Encoding.Default.GetString(buffer, 33, 30);
        tag.Album = Encoding.Default.GetString(buffer, 63, 30);
        tag.Anio = Encoding.Default.GetString(buffer, 93, 4);
        Console.WriteLine($"Título: {tag.Titulo}");
        Console.WriteLine($"Artista: {tag.Artista}");
        Console.WriteLine($"Álbum: {tag.Album}");
        Console.WriteLine($"Año: {tag.Anio}");

    }

}

else
{
    System.Console.WriteLine("Archivo no encontrado");
}


