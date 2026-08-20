using System;

public class Student
{
    private string name;
    private double score;
    private static int totalStudents = 0;

    public Student(string name, double score)
    {
        this.name = name;
        this.score = score;
        totalStudents++;
    }
    // Instance method dùng để lấy tên học sinh
    public string GetName()
    {
        return this.name;
    }
    // Instance method dùng để lấy điểm học sinh
    public double GetScore()
    {
        return this.score;
    }
    // Instance method dùng để kiểm tra học sinh có đậu hay không
    public bool IsPassed()
    {
        if (this.score >= 5.0)
            return true;
        else
            return false;
    }
    // Instance method dùng để xếp loại học sinh
    public string GetClassification()
    {
        if (this.score >= 8.0) return "Excellent";
        else if (this.score >= 6.5) return "Good";
        else if (this.score >= 5.0) return "Average";
        else return "Weak";
    }
    // Static method dùng để lấy tổng số học sinh
    public static int GetTotalStudents()
    {
        return totalStudents;
    }
    // Static method dùng để tìm học sinh có điểm cao nhất
    public static Student FindTopStudent(Student[] students)
    {
        Student top = students[0];

        for (int i = 1; i < students.Length; i++)
        {
            if (students[i].score > top.score)
            {
                top = students[i];
            }
        }

        return top;
    }
    // Static method dùng để tính điểm trung bình của cả lớp
    public static double CalculateAverageScore(Student[] students)
    {
        double sum = 0;

        for (int i = 0; i < students.Length; i++)
        {
            sum = sum + students[i].score;
        }

        return sum / students.Length;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Tạo một mảng gồm 5 học sinh
        Student[] students = new Student[5];

        students[0] = new Student("An", 8.5);
        students[1] = new Student("Binh", 6.8);
        students[2] = new Student("Chi", 4.5);
        students[3] = new Student("Dung", 7.2);
        students[4] = new Student("Ha", 9.0);

        Console.WriteLine("Total students: " + Student.GetTotalStudents());

        Console.WriteLine("\nStudent List:");

        for (int i = 0; i < students.Length; i++)
        {
            // In tên, điểm, xếp loại và trạng thái đậu/rớt
            Console.WriteLine(
                students[i].GetName() +
                " - Score: " +
                students[i].GetScore() +
                " - " +
                students[i].GetClassification() +
                " - " +
                (students[i].IsPassed() ? "Passed" : "Failed")
            );
        }
        // Tìm học sinh có điểm cao nhất
        Student top = Student.FindTopStudent(students);
        // In tiêu đề học sinh có điểm cao nhất
        Console.WriteLine("\nTop Student:");
        // In tên và điểm của học sinh cao nhất
        Console.WriteLine(top.GetName() + " - " + top.GetScore());
        // Tính điểm trung bình của cả lớp
        double average = Student.CalculateAverageScore(students);
        // In điểm trung bình của cả lớp
        Console.WriteLine("\nClass Average Score: " + average);
    }
}
