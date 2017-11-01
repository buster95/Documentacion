using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace appMpeso.Services
{
    public interface SqliteInterface
    {
        string GetPath(string filename);
    }

    public class sqlService : IDisposable
    {
        private SQLiteConnection conx;
        public sqlService()
        {
            try
            {
                var dependencia = DependencyService.Get<SqliteInterface>();
                conx = new SQLiteConnection(dependencia.GetPath("tuconsulta.db"));
                conx.CreateTable<TucModel>();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Ocurrió un error al instanciar SQLite" + ex.Message);
            }
        }

        public void Dispose()
        {
            conx.Dispose();
        }

        public SQLiteConnection GetInstance()
        {
            return conx;
        }

        public void Save(object obj)
        {
            conx.Insert(obj);
        }

        public void Update(object obj)
        {
            conx.Update(obj);
        }

        public void Delete(object obj)
        {
            conx.Delete(obj);
        }

        public void DeleteAll(Type tipo)
        {
            conx.DeleteAll(new TableMapping(tipo));
        }
    }
}
