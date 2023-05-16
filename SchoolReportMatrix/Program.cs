using System;

namespace SchoolReportMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = 5, columns = 2;
            float[,] matrix = new float[lines, columns];
            float[] subjectAverages = new float[columns];

            InsertGrades(lines, columns, matrix);
            ShowEntireSchoolReport(matrix);
            CalculateStudentsGlobalAverage(lines, columns, matrix);
            CalculateSubjectsGlobalAverage(lines, columns, matrix, subjectAverages);
            GetLowerAndHigherGrades(lines, columns, matrix);
            GetLowerAndHigherSubjectAverage(columns, subjectAverages);

            Console.ReadKey();
        }

        private static void InsertGrades(int lines, int columns, float[,] matrix)
        {
            Random random = new Random();
            float min = 0.0f, max = 10.0f;

            for (int line = 0; line < lines; line++)
                for (int column = 0; column < columns; column++)
                {
                    matrix[line, column] = (float)(random.NextDouble() * (max - min) + min);
                    matrix[line, column] = (float)Math.Round(matrix[line, column], 2);
                }
        }

        private static void ShowEntireSchoolReport(float[,] matrix)
        {
            Console.WriteLine("### School Report ###\n");

            for (int line = 0; line < 5; line++)
            {
                for (int column = 0; column < 2; column++)
                    Console.WriteLine("Aluno: " + (line + 1) + " Disciplina: " + (column + 1) + " Nota: " + matrix[line, column]);

                Console.WriteLine("\n");
            }
        }

        private static void CalculateStudentsGlobalAverage(int lines, int columns, float[,] matrix)
        {
            Console.WriteLine("*** Média global dos alunos ***\n");

            for (int line = 0; line < lines; line++)
            {
                float studentGradesSum = 0;

                for (int column = 0; column < columns; column++)
                {
                    studentGradesSum += matrix[line, column];

                    if (column == columns - 1)
                    {
                        var globalAverage = (float)Math.Round(studentGradesSum / columns, 2);

                        Console.WriteLine("Média global do aluno " + (line + 1) + ": " + globalAverage);
                    }
                }
            }
        }

        private static void CalculateSubjectsGlobalAverage(int lines, int columns, float[,] matrix, float[] subjectAverages)
        {
            Console.WriteLine("\n\n*** Média global das disciplinas ***\n");

            for (int column = 0; column < columns; column++)
            {
                float subjectGradesSum = 0;

                for (int line = 0; line < lines; line++)
                {
                    subjectGradesSum += matrix[line, column];

                    if (line == lines - 1)
                    {
                        var globalAverage = (float)Math.Round(subjectGradesSum / lines, 2);

                        subjectAverages[column] = globalAverage;

                        Console.WriteLine("Média global da disciplina " + (column + 1) + ": " + globalAverage);
                    }
                }
            }
        }

        private static void GetLowerAndHigherGrades(int lines, int columns, float[,] matrix)
        {
            float lowerGrade = 0, higherGrade = 0;

            Console.WriteLine("\n\n*** Menor e maior nota de cada aluno ***\n");

            for (int line = 0; line < 5; line++)
            {
                for (int column = 0; column < 2; column++)
                {
                    if (column == 0)
                    {
                        lowerGrade = matrix[line, column];
                        higherGrade = matrix[line, column];
                    }

                    if (matrix[line, column] < lowerGrade)
                        lowerGrade = matrix[line, column];

                    if (matrix[line, column] > higherGrade)
                        higherGrade = matrix[line, column];

                    if (column == columns - 1)
                        Console.WriteLine("Menor nota do aluno " + (line + 1) + ": " + lowerGrade + "\nMaior nota do aluno " + (line + 1) + ": " + higherGrade);
                }

                Console.WriteLine("\n");
            }

            Console.WriteLine("*** Menor e maior nota de cada disciplina ***\n");

            for (int column = 0; column < 2; column++)
            {
                for (int line = 0; line < 5; line++)
                {
                    if (line == 0)
                    {
                        lowerGrade = matrix[line, column];
                        higherGrade = matrix[line, column];
                    }

                    if (matrix[line, column] < lowerGrade)
                        lowerGrade = matrix[line, column];

                    if (matrix[line, column] > higherGrade)
                        higherGrade = matrix[line, column];

                    if (line == lines - 1)
                        Console.WriteLine("Menor nota da disciplina " + (column + 1) + ": " + lowerGrade + "\nMaior nota da disciplina " + (column + 1) + ": " + higherGrade);
                }

                Console.WriteLine("\n");
            }
        }

        private static void GetLowerAndHigherSubjectAverage(int columns, float[] subjectAverages)
        {
            float lowerAverage = 0, higherAverage = 0;

            Console.WriteLine("*** Menor e maior média de uma disciplina ***\n");

            for (int i = 0; i < columns; i++)
            {
                if (i == 0)
                {
                    lowerAverage = subjectAverages[i];
                    higherAverage = subjectAverages[i];
                }

                if (subjectAverages[i] < lowerAverage)
                    lowerAverage = subjectAverages[i];

                if (subjectAverages[i] > higherAverage)
                    higherAverage = subjectAverages[i];
            }

            Console.WriteLine("Menor média de uma disciplina: " + lowerAverage + "\nMaior média de uma disciplina: " + higherAverage);
        }
    }
}