using BookStore.Interface;

using BookStore.ViewModal;

using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;

namespace BookStore.Service
{
    public class BookInv : IBookInv
    {
        private IConfiguration configuration { get; }
        private readonly string connectionString;
        public BookInv(IConfiguration _configuration)
        {
            configuration = _configuration;
            connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
        }
     


        public (JsonResult result,bool succeeded) BookInvList()
        {
            DataTable datatable = new DataTable();

            SqlConnection val = new SqlConnection (connectionString);
            try
            {
                SqlCommand val2 = new SqlCommand("usp_GetBookData", val);
                try
                {
                    SqlDataAdapter val3 = new SqlDataAdapter(val2);
                    try
                    {
                        ((DbCommand)(object)val2).CommandType = CommandType.StoredProcedure;
                        
                        ((DbDataAdapter)(object)val3).Fill(datatable);
                    }
                    finally
                    {
                        ((IDisposable)val3)?.Dispose();
                    }
                }
                finally
                {
                    ((IDisposable)val2)?.Dispose();
                }
            }
            finally
            {
                ((IDisposable)val)?.Dispose();
            }



            var data = (from DataRow dr in datatable.Rows
                       
                        select new BookData
                        {

                            Id = dr["Id"].ToString(),
                            Price = dr["Price"].ToString(),
                            BookTitle = dr["BookTitle"].ToString(),
                            DateofPublish = dr["DateofPublish"].ToString(),
                            Author = dr["Author"].ToString(),
                            
                            

                        }).ToList();

            return (new JsonResult(data), true);
        }

        public (JsonResult result, bool succeeded) DeleteInvList(int id)
        {
            DataTable datatable = new DataTable();

            SqlConnection val = new SqlConnection(connectionString);
            try
            {
                SqlCommand val2 = new SqlCommand("usp_DeleteBookData", val);
                try
                {
                    SqlDataAdapter val3 = new SqlDataAdapter(val2);
                    try
                    {
                        ((DbCommand)(object)val2).CommandType = CommandType.StoredProcedure;
                        ((DbParameter)(object)val2.Parameters.Add(new SqlParameter("@id", SqlDbType.Int))).Value = id;

                        ((DbDataAdapter)(object)val3).Fill(datatable);
                    }
                    finally
                    {
                        ((IDisposable)val3)?.Dispose();
                    }
                }
                finally
                {
                    ((IDisposable)val2)?.Dispose();
                }
            }
            finally
            {
                ((IDisposable)val)?.Dispose();
            }



            var data = (from DataRow dr in datatable.Rows

                        select new BookData
                        {

                            Id = dr["Id"].ToString(),
                            Price = dr["Price"].ToString(),
                            BookTitle = dr["BookTitle"].ToString(),
                            DateofPublish = dr["DateofPublish"].ToString(),
                            Author = dr["Author"].ToString(),



                        }).ToList();

            return (new JsonResult(data), true);
        }


        public (JsonResult result, bool succeeded) GetBookInvList(int id)
        {
            DataTable datatable = new DataTable();

            SqlConnection val = new SqlConnection(connectionString);
            try
            {
                SqlCommand val2 = new SqlCommand("usp_GetBookData", val);
                try
                {
                    SqlDataAdapter val3 = new SqlDataAdapter(val2);
                    try
                    {
                        ((DbCommand)(object)val2).CommandType = CommandType.StoredProcedure;
                        //((DbParameter)(object)val2.Parameters.Add(new SqlParameter("@id", SqlDbType.Int))).Value = id;
                        ((DbDataAdapter)(object)val3).Fill(datatable);
                    }
                    finally
                    {
                        ((IDisposable)val3)?.Dispose();
                    }
                }
                finally
                {
                    ((IDisposable)val2)?.Dispose();
                }
            }
            finally
            {
                ((IDisposable)val)?.Dispose();
            }



            var data = (from DataRow dr in datatable.Rows
                        where
                        dr["Id"].ToString().Contains(string.IsNullOrEmpty(id.ToString()) ? dr["Id"].ToString() : id.ToString())

                        select new BookData
                        {

                            Id = dr["Id"].ToString(),
                            Price = dr["Price"].ToString(),
                            BookTitle = dr["BookTitle"].ToString(),
                            DateofPublish = dr["DateofPublish"].ToString(),
                            Author = dr["Author"].ToString(),



                        }).ToList();

            return (new JsonResult(data), true);
        }

        public (JsonResult result, bool succeeded) UpdateBookInvList(BookData book)
        {
            DataTable datatable = new DataTable();

            SqlConnection val = new SqlConnection(connectionString);
            try
            {
                SqlCommand val2 = new SqlCommand("usp_UpdateBookData", val);
                try
                {
                    SqlDataAdapter val3 = new SqlDataAdapter(val2);
                    try
                    {
                        ((DbCommand)(object)val2).CommandType = CommandType.StoredProcedure;
                        ((DbParameter)(object)val2.Parameters.Add(new SqlParameter("@id", SqlDbType.Int))).Value = Convert.ToInt32(book.Id);
                        ((DbParameter)(object)val2.Parameters.Add(new SqlParameter("@author", SqlDbType.VarChar))).Value = book.Author;
                        ((DbParameter)(object)val2.Parameters.Add(new SqlParameter("@booktitle", SqlDbType.VarChar))).Value = book.BookTitle;
                        ((DbParameter)(object)val2.Parameters.Add(new SqlParameter("@dateofpublish", SqlDbType.VarChar))).Value = book.DateofPublish;
                        ((DbParameter)(object)val2.Parameters.Add(new SqlParameter("@price", SqlDbType.VarChar))).Value = book.Price;
                        ((DbDataAdapter)(object)val3).Fill(datatable);
                    }
                    finally
                    {
                        ((IDisposable)val3)?.Dispose();
                    }
                }
                finally
                {
                    ((IDisposable)val2)?.Dispose();
                }
            }
            finally
            {
                ((IDisposable)val)?.Dispose();
            }



            var data = (from DataRow dr in datatable.Rows
                        
                        

                        select new BookData
                        {

                            Id = dr["Id"].ToString(),
                            Price = dr["Price"].ToString(),
                            BookTitle = dr["BookTitle"].ToString(),
                            DateofPublish = dr["DateofPublish"].ToString(),
                            Author = dr["Author"].ToString(),



                        }).ToList();

            return (new JsonResult(data), true);
        }


        public (JsonResult result, bool succeeded) AddNewBookDataList(BookData book)
        {
            DataTable datatable = new DataTable();

            SqlConnection val = new SqlConnection(connectionString);
            try
            {
                SqlCommand val2 = new SqlCommand("usp_AddNewBookData", val);
                try
                {
                    SqlDataAdapter val3 = new SqlDataAdapter(val2);
                    try
                    {
                        ((DbCommand)(object)val2).CommandType = CommandType.StoredProcedure;                       
                        ((DbParameter)(object)val2.Parameters.Add(new SqlParameter("@price", SqlDbType.VarChar))).Value = book.Price;
                        ((DbParameter)(object)val2.Parameters.Add(new SqlParameter("@dateofpublish", SqlDbType.VarChar))).Value = book.DateofPublish;
                        ((DbParameter)(object)val2.Parameters.Add(new SqlParameter("@booktitle", SqlDbType.VarChar))).Value = book.BookTitle;
                        ((DbParameter)(object)val2.Parameters.Add(new SqlParameter("@author", SqlDbType.VarChar))).Value = book.Author;
                        ((DbDataAdapter)(object)val3).Fill(datatable);
                    }
                    finally
                    {
                        ((IDisposable)val3)?.Dispose();
                    }
                }
                finally
                {
                    ((IDisposable)val2)?.Dispose();
                }
            }
            finally
            {
                ((IDisposable)val)?.Dispose();
            }



            var data = datatable.Rows.Count;

            return (new JsonResult(data), true);
        }
    }
}
