using SkillApp.Core.Printouts.Models;
using System.Collections.Generic;

namespace SkillApp.Core.Parsers
{
    public static class ExcelParser
    {

        public static List<Skill> Load(string path) 
        {
            //ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            //var existingFile = new FileInfo(path);
            //using (var package = new ExcelPackage(existingFile)) {
            //    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
            //    int colCount = worksheet.Dimension.End.Column;  //get Column Count
            //    int rowCount = worksheet.Dimension.End.Row;     //get row count
            //    for (int row = 9; row <= rowCount; row++)
            //    {
            //        for (int col = 4; col <= colCount; col++)
            //        {
            //            if (worksheet.Cells[row, col].Value?.ToString().Trim() ==);
            //        }
            //    }
            //    return new List<Skill>();
            //}
            return new List<Skill>();
        }
    }
}
