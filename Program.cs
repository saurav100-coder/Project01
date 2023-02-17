// See https://aka.ms/new-console-template for more information
using System;
using System.Data;
using System.Linq;
using System.Security.Cryptography;

namespace Project01
{
    class CreateDataTable
    {
        public static void Main(string[] args)
        {
            DataTable T1 = new DataTable();
            DataTable T2 = new DataTable();
            Console.WriteLine("T1 Table");
            Console.WriteLine("Enter StudentId,StudentName, MarksA and MarksB seprated by commas");
            T1.Columns.Add("StudentId");
            T1.Columns.Add("StudentName");
            T1.Columns.Add("MarksA");
            T1.Columns.Add("MarksB");
            T1.PrimaryKey = new DataColumn[] { T1.Columns["StudentId"] };
            for (int i = 0; i < 4; i++)
            {
                DataRow row = T1.NewRow();
                string data = Console.ReadLine();
                string[] values = data.Split(",");
                row["StudentId"] = Convert.ToInt32(values[0]);
                row["StudentName"] = values[1];
                row["MarksA"] = Convert.ToInt32(values[02]);
                row["MarksB"] = Convert.ToInt32(values[03]);
                
                T1.Rows.Add(row);
            }
            Console.WriteLine("T2 Table");
            Console.WriteLine("Enter StudentId,MarksC and MarksD seprated by commas");
            T2.Columns.Add("StudentId");
            T2.Columns.Add("MarksC");
            T2.Columns.Add("MarksD");
            T2.PrimaryKey = new DataColumn[] { T2.Columns["StudentId"] };
                      

            for (int i = 0; i < 3; i++)
            {
                DataRow row = T2.NewRow();
                string data = Console.ReadLine();
                string[] values = data.Split(",");
                row["StudentId"] = Convert.ToInt32(values[0]);
                row["MarksC"] = Convert.ToInt32(values[1]);
                row["MarksD"] = Convert.ToInt32(values[02]);
                T2.Rows.Add(row);
            }
            Console.WriteLine("T1 Table");
            foreach(DataRow R in T1.Rows)
            {
                foreach(DataColumn C in T1.Columns)
                {
                    Console.Write(R[C] + " ");
                }
                Console.WriteLine();

            }
            Console.WriteLine("T2 Table");
            foreach (DataRow R in T2.Rows)
            {
                foreach (DataColumn C in T2.Columns)
                {
                    Console.Write(R[C] + " ");
                }
                Console.WriteLine();

            }
            T1.Merge(T2, false, MissingSchemaAction.Add);
            DataTable T3 = new DataTable();
            T3.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("StudentID"),
                new DataColumn("StudentName"),
                new DataColumn("MarksA"),
                new DataColumn("MarksB"),
                new DataColumn("MarksC"),
                new DataColumn("MarksD")
            });

            var result = (from t1 in T1.AsEnumerable()
                          select new
                          {
                              StudentId = t1["StudentId"],
                              StudentName = t1["StudentName"].ToString(),
                              MarksA = t1["MarksA"],
                              MarksB = t1["MarksB"],
                              MarksC = t1["MarksC"],
                              MarksD = t1["MarksD"],
                          }).ToList();
            foreach(var item in result)
            {
                T3.Rows.Add(item.StudentId,item.StudentName,item.MarksA, item.MarksB, item.MarksC,item.MarksD);
            }
            Console.WriteLine("T3 Table");
            foreach (DataRow R in T3.Rows)
            {
                foreach (DataColumn C in T3.Columns)
                {
                    Console.Write(R[C] + " ");
                }
                Console.WriteLine();

            }
        }
    }
}
