using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace sistema.Models
{
    public class ImagenPaciente
    {
        public int Id { get; set; }
        public int PacienteID { get; set; }
        public string Titulo { get; set; }
        public string Categoria { get; set; } // 'Evolución', 'Rayos X', 'Ecografía', 'Laboratorio', 'Otro'
        public string Descripcion { get; set; }
        public DateTime FechaTomada { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Formato { get; set; } // 'JPG', 'PNG', etc.
        public int TamanoBytes { get; set; }
        public byte[] ImagenData { get; set; }
        public byte[] MiniaturaData { get; set; }
        public int? UsuarioID { get; set; }

        /// <summary>
        /// Convierte un arreglo de bytes a objeto Image en memoria sin bloquear archivos de disco.
        /// </summary>
        public static Image ByteArrayToImage(byte[] data)
        {
            if (data == null || data.Length == 0) return null;
            using (var ms = new MemoryStream(data))
            {
                // Se clona en un nuevo Bitmap para no depender del MemoryStream original
                using (var temp = Image.FromStream(ms))
                {
                    return new Bitmap(temp);
                }
            }
        }

        /// <summary>
        /// Convierte un Image a arreglo de bytes usando el formato indicado.
        /// </summary>
        public static byte[] ImageToByteArray(Image img, ImageFormat format = null)
        {
            if (img == null) return null;
            if (format == null) format = ImageFormat.Jpeg;
            using (var ms = new MemoryStream())
            {
                img.Save(ms, format);
                return ms.ToArray();
            }
        }

        /// <summary>
        /// Genera una miniatura proporcional de alta calidad con dimensiones máximas especificadas.
        /// </summary>
        public static byte[] GenerarMiniaturaBytes(Image original, int maxAncho = 250, int maxAlto = 250)
        {
            if (original == null) return null;

            int nuevoAncho = original.Width;
            int nuevoAlto = original.Height;

            float ratioX = (float)maxAncho / original.Width;
            float ratioY = (float)maxAlto / original.Height;
            float ratio = Math.Min(ratioX, ratioY);

            if (ratio < 1.0f)
            {
                nuevoAncho = (int)(original.Width * ratio);
                nuevoAlto = (int)(original.Height * ratio);
            }

            using (var bmpThumb = new Bitmap(nuevoAncho, nuevoAlto))
            {
                using (var g = Graphics.FromImage(bmpThumb))
                {
                    g.CompositingQuality = CompositingQuality.HighQuality;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                    g.DrawImage(original, 0, 0, nuevoAncho, nuevoAlto);
                }

                return ImageToByteArray(bmpThumb, ImageFormat.Jpeg);
            }
        }
    }
}
