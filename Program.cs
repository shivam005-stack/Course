using System;

namespace Assing
{
    class Program
    {
        static void Main(String[] args)
        {
            SqlConnection sqlConnection;
            string connectionString = @"Data Source.; Initial Catalog=ProfDB;Integrated Security=True";
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                Console.WriteLine("Connection Established Successfully");

                //Create
                // Create Student Table//

                Console.WriteLine("Enter Student Name:");
                String studentName = Console.ReadLine();

                Console.WriteLine("Enter Student Id:");
                int StudentId = int.Parse(Console.ReadLine());

                //Create Course Table
                Console.WriteLine("Enter CourseName:");
                String courseName = Console.ReadLine();

                Console.WriteLine("Enter CourseId:");
                int courseId = int.Parse(Console.ReadLine());



                //Create Professors Table
                Console.WriteLine("Enter Professor's Name:");
                String professorName = Console.ReadLine();

                Console.WriteLine("Enter CourseId Of Professor:");

                String insertQuery = "INSERT INTO DETAILS(studentName,studentId,courseName,courseId,professorName, courseId) VALUES(" + studentName + "," + StudentId + ", "+ courseName + "," + courseId + "," + professorName + ", " + courseId + ")";
                SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection);
                insertCommand.executeNonQuery();
                Console.WriteLine("Data Successfully Enterted");

                // Display
                  String displayQuery = "SELECT * FROM Details";
                  SqlCommand displayCommand = new SqlCommand(displayQuery,sqlConnection);
                sqlDataReader dataReader = displayCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    Console.WriteLine("studentName:" + dataReader.GetValue().ToString());
                    Console.WriteLine("studentId:" + dataReader.GetVlaue().ToString());
                    Console.WriteLine("Professor's Name:" + dataReader.GetValue().ToString());
                    Console.WriteLine("Course Id:" + dataReader.GetValue().ToString());
                    Console.WriteLine("Course Name:" + dataReader.GetValue().ToString());
                }
                   dataReader.Close();

                // Update
                   int s_Id;
                   String s_Name;
                   int c_Id;
                String c_Name;
                String p_Name;

                Console.WriteLine("Enter The Name Of Student To Be Updated Along With Course:");
                s_Name = Console.ReadLine()
                c_Id = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter The Id Of The Student:");
                s_Id = int.Parse(Console.ReadLine());
                c_Name = Console.ReadLine();

                Console.WriteLine("Enter Name Of The Professor To Be Updated Along With CourseName:");
                p_Name = Console.ReadLine();

                String updateQuery = "UPDATE Details SET student_Name && student_Id = " + s_Name + s_Id + "WHERE course_Id && course_Name = " + c_Id + c_Name + "WHERE professor_Name && professor_courseName= " + p_Name + c_Name+"";
                SqlCommand updateCommand = new SqlCommand(updateQuery, sqlConnection);
                updateCommand.ExecuteNonQuery();
                Console.WriteLine("Data Updated SuccessFully");

                sqlConnection.Close();

            } catch(Exception e)
            {
                Console.WriteLine(e.message);
            }
        }
    }
}
