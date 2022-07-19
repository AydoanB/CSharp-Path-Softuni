using System.Collections.Generic;
using Artillery.Data.Models.Enums;

namespace Artillery.DataProcessor.ExportDto
{
    public class ExportShellsDto
    {
        public double ShellWeight { get; set; }
        public string Caliber { get; set; }
        public ICollection<GunsExportDto> Guns { get; set; }
    }

    public class GunsExportDto
    {
        public string GunType{ get; set; }
        public int GunWeight{ get; set; }
        public double BarrelLength { get; set; }
        public string Range { get; set; }
    }
}