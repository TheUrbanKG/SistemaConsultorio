using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace sistema.Expediente.Odontograma
{
    public static class OdontogramaResourceService
    {
        private static readonly Dictionary<string, Image> _imageCache = new Dictionary<string, Image>(StringComparer.OrdinalIgnoreCase);
        private static string _basePath;

        public static string BasePath
        {
            get
            {
                if (string.IsNullOrEmpty(_basePath))
                {
                    // Buscar en BaseDirectory/Resources/Odontograma o rutas relativas del proyecto
                    string appDir = AppDomain.CurrentDomain.BaseDirectory;
                    string candidate1 = Path.Combine(appDir, "Resources", "Odontograma");
                    string candidate2 = Path.Combine(appDir, "..", "..", "Resources", "Odontograma");
                    string candidate3 = Path.Combine(appDir, "..", "..", "..", "sistema", "Resources", "Odontograma");

                    if (Directory.Exists(candidate1)) _basePath = Path.GetFullPath(candidate1);
                    else if (Directory.Exists(candidate2)) _basePath = Path.GetFullPath(candidate2);
                    else if (Directory.Exists(candidate3)) _basePath = Path.GetFullPath(candidate3);
                    else _basePath = candidate1;
                }
                return _basePath;
            }
        }

        public static Image ObtenerFondoBoca()
        {
            string png = Path.Combine(BasePath, "boca.png");
            if (File.Exists(png))
                return ObtenerImagen("boca.png");

            return ObtenerImagen("odonto.jpg");
        }

        public static Image ObtenerImagen(string nombreOClave)
        {
            if (string.IsNullOrWhiteSpace(nombreOClave))
                nombreOClave = "sincarie";

            string key = nombreOClave.ToLowerInvariant();
            if (!key.EndsWith(".gif") && !key.EndsWith(".jpg") && !key.EndsWith(".png"))
            {
                key += ".gif";
            }

            if (_imageCache.ContainsKey(key) && _imageCache[key] != null)
                return _imageCache[key];

            string fullPath = Path.Combine(BasePath, key);
            if (File.Exists(fullPath))
            {
                try
                {
                    byte[] bytes = File.ReadAllBytes(fullPath);
                    using (var ms = new MemoryStream(bytes))
                    {
                        using (var raw = Image.FromStream(ms))
                        {
                            var bmp = new Bitmap(raw.Width, raw.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                            using (var g = Graphics.FromImage(bmp))
                            {
                                g.DrawImage(raw, 0, 0, raw.Width, raw.Height);
                            }

                            // Si es un icono de diente (25x25), aplicar transparencia circular
                            if (bmp.Width <= 32 && bmp.Height <= 32 && !key.Contains("boca") && !key.Contains("odonto"))
                            {
                                Color corner = bmp.GetPixel(0, 0);
                                bmp.MakeTransparent(corner);

                                // Máscara circular para eliminar esquinas cuadradas
                                int cx = bmp.Width / 2;
                                int cy = bmp.Height / 2;
                                float rSq = (bmp.Width / 2f) * (bmp.Width / 2f);

                                for (int y = 0; y < bmp.Height; y++)
                                {
                                    for (int x = 0; x < bmp.Width; x++)
                                    {
                                        float dx = x - cx;
                                        float dy = y - cy;
                                        if (dx * dx + dy * dy > rSq)
                                        {
                                            bmp.SetPixel(x, y, Color.Transparent);
                                        }
                                    }
                                }
                            }

                            _imageCache[key] = bmp;
                            return bmp;
                        }
                    }
                }
                catch
                {
                    // Fallback
                }
            }

            // Fallback por defecto si no se encuentra
            var fallback = new Bitmap(25, 25, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            using (var g = Graphics.FromImage(fallback))
            {
                g.Clear(Color.Transparent);
                g.FillEllipse(Brushes.White, 1, 1, 23, 23);
                g.DrawEllipse(Pens.Black, 1, 1, 23, 23);
            }
            _imageCache[key] = fallback;
            return fallback;
        }

        public static Dictionary<string, string> ObtenerCatalogoEstados()
        {
            var dict = new Dictionary<string, string>
            {
                { "sincarie", "Diente Sano / Limpio" },
                { "ausente", "Diente Ausente (Pérdida)" },
                { "eindicada", "Extracción Indicada" },
                { "endindicada", "Endodoncia Indicada" },
                { "tcrealizado", "Tratamiento de Conducto Realizado" },
                { "corona", "Corona Protésica" },
                { "pf", "Puente Fijo" },
                { "ds3", "Prótesis Parcial Removible" }
            };

            for (int i = 1; i <= 15; i++)
                dict[$"carie{i}"] = $"Caries (Variante {i})";

            for (int i = 1; i <= 15; i++)
                dict[$"curada{i}"] = $"Curación / Obturación (Variante {i})";

            for (int i = 1; i <= 16; i++)
                dict[$"mez{i}"] = $"Curación con Caries (Variante {i})";

            return dict;
        }
    }
}
