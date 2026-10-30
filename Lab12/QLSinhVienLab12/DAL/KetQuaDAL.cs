using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace QLSinhVienLab12.DAL
{
    public class KetQuaDAL
    {
        public DataTable GetLop()
        {
            using SqlConnection conn =
                new SqlConnection(Database.ConnectionString);

            using SqlCommand cmd =
                new SqlCommand("sp_Lop_GetAll", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adapter =
                new SqlDataAdapter(cmd);

            DataTable table = new DataTable();

            adapter.Fill(table);

            return table;
        }

        public DataTable GetMonHoc()
        {
            using SqlConnection conn =
                new SqlConnection(Database.ConnectionString);

            using SqlCommand cmd =
                new SqlCommand("sp_MonHoc_GetAll", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adapter =
                new SqlDataAdapter(cmd);

            DataTable table = new DataTable();

            adapter.Fill(table);

            return table;
        }

        public DataTable GetKetQua(string maLop, string maMon)
        {
            using SqlConnection conn =
                new SqlConnection(Database.ConnectionString);

            using SqlCommand cmd =
                new SqlCommand("sp_KetQua_GetByLopMon", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@MaLop", maLop);
            cmd.Parameters.AddWithValue("@MaMon", maMon);

            SqlDataAdapter adapter =
                new SqlDataAdapter(cmd);

            DataTable table = new DataTable();

            adapter.Fill(table);

            return table;
        }

        public int SaveAll(string maMon, DataTable table)
        {
            using SqlConnection conn =
                new SqlConnection(Database.ConnectionString);

            conn.Open();

            SqlTransaction trans =
                conn.BeginTransaction();

            try
            {
                int count = 0;

                foreach (DataRow row in table.Rows)
                {
                    using SqlCommand cmd =
                        new SqlCommand(
                            "sp_KetQua_Save",
                            conn,
                            trans);

                    cmd.CommandType =
                        CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(
                        "@MaSV",
                        row["MaSV"]);

                    cmd.Parameters.AddWithValue(
                        "@MaMon",
                        maMon);

                    cmd.Parameters.AddWithValue(
                        "@Diem",
                        Convert.ToDouble(row["Diem"]));

                    cmd.Parameters.AddWithValue(
                        "@GhiChu",
                        row["GhiChu"]);

                    cmd.ExecuteNonQuery();

                    count++;
                }

                trans.Commit();

                return count;
            }
            catch
            {
                trans.Rollback();
                throw;
            }
        }
    }
}
