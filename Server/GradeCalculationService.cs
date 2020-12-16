using Grpc.Core;
using System;
using System.Threading.Tasks;

namespace Server
{
	public class GradeCalculationService : GradeCalculation.GradeCalculationBase
	{
		private readonly object _locker;
		public GradeCalculationService()
		{
			_locker = new object();
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.Write("FIO".PadRight(20)
				+ "FirstGrade".PadRight(14)
				+ "SecondGrade".PadRight(14)
				+ "ThirdGrade".PadRight(14));
			Console.WriteLine("FinalGrade".PadRight(14));
			Console.ForegroundColor = ConsoleColor.White;
		}

		public override Task<Grade> CalculateGrade(Student request, ServerCallContext context)
		{
			int finalMathGrade = GetFinalGrade(request);
			var grade = new Grade { FinalMathGrade = finalMathGrade };
			lock (_locker)
			{
				Print(request, finalMathGrade);
			}
			return Task.FromResult(grade);
		}

		private int GetFinalGrade(Student request)
		{
			if (request.GradeMathOne < 41 || request.GradeMathTwo < 41 || request.GradeMathThree < 41) return 0;
			return (int)Math.Round(
					(request.GradeMathOne * 5
					+ request.GradeMathTwo * 5
					+ request.GradeMathThree * 3)
					/ 13.0);
		}

		private void Print(Student student, int finalMathGrade)
		{
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.Write(student.Fio.PadRight(20)
				+ student.GradeMathOne.ToString().PadRight(14)
				+ student.GradeMathTwo.ToString().PadRight(14)
				+ student.GradeMathThree.ToString().PadRight(14));
			Console.ForegroundColor = GetColor(finalMathGrade);
			Console.WriteLine(finalMathGrade.ToString().PadRight(14));
			Console.ForegroundColor = ConsoleColor.White;
		}

		private ConsoleColor GetColor(int grade)
		{
			if (grade < 41) return ConsoleColor.Red;
			if (grade < 61) return ConsoleColor.Magenta;
			if (grade < 81) return ConsoleColor.Blue;
			return ConsoleColor.Green;
		}
	}
}
