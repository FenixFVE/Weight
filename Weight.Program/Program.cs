using Weight.Program.WeightDatabase.Tables;
using Weight.Program.CSV;
using Weight.Program.WeightDatabase;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Weight.Program;

public class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.Default;
        
        using (var db = new WeightContext())
        {

            var controlWeighing = db.ControlWeighings
                .Include(wei => wei.ControlWeighingStatus)
                .Include(wei => wei.ControlWeighingSettings)
                    .ThenInclude(set => set!.ControlWeighingEvaluationType)
                .Include(wei => wei.ControlWeighingSettings)
                    .ThenInclude(set => set!.ControlWeighingScheduleType)
                .Include(wei => wei.ControlWeighingSettings)
                    .ThenInclude(set => set!.WeightSetting)
                        .ThenInclude(weiSet => weiSet!.Department)
                .Include(wei => wei.ControlWeighingSettings)
                    .ThenInclude(set => set!.SecondWeightSetting)
                        .ThenInclude(weiSet => weiSet!.Department)
                .Select(wei => new
                {
                    ControlWeighingStatusName = wei.ControlWeighingStatus.Name,
                    EvaluationTypeName = wei.ControlWeighingSettings.ControlWeighingEvaluationType.Name,
                    ScheduleTypeName = wei.ControlWeighingSettings.ControlWeighingScheduleType.Name,
                    WeightSettingDepartmentName = wei.ControlWeighingSettings.WeightSetting.Department.Name,
                    SecondWeightSettingDepartmentName = wei.ControlWeighingSettings.SecondWeightSetting.Department.Name
                })
                .ToList();
            
            foreach (var x in controlWeighing)
            {
                Console.WriteLine($"{x.ControlWeighingStatusName};{x.EvaluationTypeName};{x.ScheduleTypeName};{x.WeightSettingDepartmentName};{x.SecondWeightSettingDepartmentName}");
            }
        }
    }
}