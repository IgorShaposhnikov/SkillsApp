using OfficeOpenXml;
using OfficeOpenXml.Style;
using SkillApp.Core.Enums;
using SkillApp.Core.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace SkillApp.Core.Printouts
{
    public class ExcelPrintout
    {
        public static void SaveSkillProfile(Core.Models.SkillsProfile skillProfile, string path)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage excelPackage = new ExcelPackage(new FileStream(string.Format("{0}\\{1}-{2}.xlsx", path, skillProfile.Name, DateTime.Now.ToString().Replace(':', '-')), FileMode.Create));
            var sheet = excelPackage.Workbook.Worksheets.Add("Профиль");

            var headerValues = new string[6] { "№", "Формулировка навыков и оценочных аспектов", "Периодичность выполнения", "Вес в баллах", "Тип оценочного аспекта (Z, B, D, J)",
                "Пояснения к оценке выполнения тестового проекта"};


            InitHeader(sheet);

            var skills = ISkillToSkill(skillProfile.Skills);



            for (var i = 4; i < 10; i++)
            {
                sheet.Cells[8, i].Value = headerValues[i - 4];
            }


            var skillsScoreSum = 0.0;
            var t = 9;
            for (var i = 0; i < skills.Count; i++)
            {
                SetSkillStyle(sheet, skills[i], t + i);
                skillsScoreSum += skills[i].Score; 
                t += skills[i].Aspects.Length;
            }

            InitFooter(sheet, t + skills.Count, score: skillsScoreSum);
            excelPackage.Save();
        }


        private static void InitHeader(ExcelWorksheet sheet, int fromCellIndex = 4, int toCellIndex = 9, int rowIndex = 8)
        {
            var headerBackgroundColor = System.Drawing.ColorTranslator.FromHtml("#17365d");
            var headerForegroundColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");

            sheet.Row(rowIndex).CustomHeight = true;
            // Header
            sheet.Row(rowIndex).Height = 55;
            //  Description
            sheet.Column(4).Width = 10;
            sheet.Column(5).Width = 50;
            sheet.Column(6).Width = 25;
            sheet.Column(7).Width = 9;
            sheet.Column(8).Width = 11;
            sheet.Column(9).Width = 100;


            var currentCell = sheet.Cells[rowIndex, fromCellIndex, rowIndex, toCellIndex];
            currentCell.Style.Fill.PatternType = ExcelFillStyle.Solid;
            currentCell.Style.Fill.BackgroundColor.SetColor(headerBackgroundColor);
            currentCell.Style.Font.Size = 11;
            currentCell.Style.Font.Color.SetColor(headerForegroundColor);
            currentCell.Style.WrapText = true;
            currentCell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            currentCell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            currentCell.Style.Font.Bold = true;
            currentCell.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            currentCell.Style.Border.BorderAround(ExcelBorderStyle.Double);
        }


        private static void InitFooter(ExcelWorksheet sheet, int rowIndex, int fromCellIndex = 4, int toCellIndex = 9, double score = 0) 
        {
            var headerBackgroundColor = System.Drawing.ColorTranslator.FromHtml("#17365d");
            var headerForegroundColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");

            var currentCell = sheet.Cells[rowIndex, fromCellIndex, rowIndex, toCellIndex];
            currentCell.Style.Fill.PatternType = ExcelFillStyle.Solid;
            currentCell.Style.Fill.BackgroundColor.SetColor(headerBackgroundColor);
            currentCell.Style.Font.Size = 11;
            currentCell.Style.Font.Color.SetColor(headerForegroundColor);
            currentCell.Style.WrapText = true;
            currentCell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            currentCell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            currentCell.Style.Font.Bold = true;
            currentCell.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            currentCell.Style.Border.BorderAround(ExcelBorderStyle.Double);

            currentCell[rowIndex, fromCellIndex + 1].Value = "ИТОГО"; 
            currentCell[rowIndex, fromCellIndex + 3].Value = score; 
        } 

        private static void SetSkillStyle(ExcelWorksheet sheet, Core.Printouts.Models.Skill skill, int rowIndex = 9, int fromCellIndex = 4, int toCellIndex = 9) 
        {
            var skillBackgroundColor = System.Drawing.ColorTranslator.FromHtml("#b6dde8");
            var skillForegroundColor = System.Drawing.ColorTranslator.FromHtml("#000000");

            var currentCell = sheet.Cells[rowIndex, fromCellIndex, rowIndex, toCellIndex];
            currentCell.Style.Fill.PatternType = ExcelFillStyle.Solid;
            currentCell.Style.Fill.BackgroundColor.SetColor(skillBackgroundColor);
            currentCell.Style.Font.Size = 11;
            currentCell.Style.Font.Color.SetColor(skillForegroundColor);
            currentCell.Style.Border.BorderAround(ExcelBorderStyle.Thin);
            currentCell.Style.Font.Bold = true;
            currentCell.Style.WrapText = true;
            currentCell.Style.HorizontalAlignment= ExcelHorizontalAlignment.Center;
            currentCell.Style.VerticalAlignment= ExcelVerticalAlignment.Top;

            sheet.Cells[rowIndex, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

            var properties = skill.GetType().GetProperties();
            var columnsIndexs = new int[3] { 0, 1, 3 };
            for (var i = 0; i < properties.Length - 2; i++) 
            {
                sheet.Cells[rowIndex, fromCellIndex + columnsIndexs[i]].Value = properties[i].GetValue(skill);
            }

            for (var i = 0; i < skill.Aspects.Length; i++) 
            { 
                SetAspect(sheet, skill.Aspects[i], rowIndex + i + 1, fromCellIndex, toCellIndex);
            }
        }


        private static void SetAspect(ExcelWorksheet sheet, Core.Printouts.Models.Aspect aspect, int rowIndex, int fromCellIndex = 4, int toCellIndex = 9)
        {
            var currentCell = sheet.Cells[rowIndex, fromCellIndex, rowIndex, toCellIndex];
            currentCell.Style.Font.Size = 11;
            currentCell.Style.Border.BorderAround(ExcelBorderStyle.Thin);
            currentCell.Style.WrapText = true;
            currentCell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            currentCell.Style.VerticalAlignment = ExcelVerticalAlignment.Top;
            sheet.Cells[rowIndex, fromCellIndex].Style.Numberformat.Format = "0.0";
            sheet.Cells[rowIndex, fromCellIndex + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
            sheet.Cells[rowIndex, toCellIndex].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;


            var properties = aspect.GetType().GetProperties();
            for (var i = 0; i < properties.Length - 2; i++)
            {
                var propValue = properties[i].GetValue(aspect);
                if ((properties[i].PropertyType) == typeof(ExecutionFrequency))
                {
                    propValue = EnumTools.GetEnumDescription((ExecutionFrequency)propValue);
                }
                else if ((properties[i].PropertyType) == typeof(Core.Printouts.Models.Explanation))
                {
                    propValue = ((Core.Printouts.Models.Explanation)propValue).ResultString;
                }
                sheet.Cells[rowIndex, fromCellIndex + i].Value = propValue;
            }
        }


        private static List<Core.Printouts.Models.Skill> ISkillToSkill(IEnumerable<Core.Models.ISkill> skills)
        {
            var list = new List<Core.Printouts.Models.Skill>();
            var lastId = 0;
            foreach (var skill in skills)
            {
                if (lastId + 1 != skill.Id)
                {
                    skill.Id = lastId + 1;
                }
                lastId++;
                if (skill.IsEnabled)
                {
                    list.Add(new Core.Printouts.Models.Skill(skill));
                }
            }

            foreach (var skill in list)
            {
                skill.Aspects = skill.Aspects.Where(i => i.IsEnabled).ToArray<Core.Printouts.Models.Aspect>();
            }
            return list;
        }
    }
}
