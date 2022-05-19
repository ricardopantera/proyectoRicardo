using proyectoRicardo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace proyectoRicardo.Contexto
{
    public class Context : DbContext
    {
        public Context() : base ("name=Conexion_db")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }

        public static  List<Productos> GetProductos()
        {
            Context cx = new Context();
            return cx.Database.SqlQuery<Productos>("SELECT * FROM PRODUCTOS").ToList();
        }

        public static Productos getProductosId(int? id)
        {
            Context cx = new Context();
            SqlParameter idProductos = new SqlParameter("@id", id);
            return cx.Database.SqlQuery<Productos>("SELECT * FROM PRODUCTOS WHERE ID = @id", idProductos).FirstOrDefault();
        }

        public static void updateProductos(Productos actualizarProductos)
        {
            Context cx = new Context();
            SqlParameter editId = new SqlParameter("@id",actualizarProductos.ID);
            SqlParameter editNombre = new SqlParameter("@nombre", actualizarProductos.NOMBRE);
            SqlParameter editDesc = new SqlParameter("@descripcion", actualizarProductos.DESCRIPCION);
            SqlParameter editPrecio = new SqlParameter("@Precio", actualizarProductos.PRECIO);

            cx.Database.ExecuteSqlCommand("UPDATE PRODUCTOS SET  NOMBRE=@nombre,DESCRIPCION=@descripcion,PRECIO=@precio WHERE ID=@id", editNombre,editDesc,editPrecio, editId);
        }


        public static void deleteProductos(int id)
        {
            Context cx = new Context();
            SqlParameter eId = new SqlParameter("@id", id);
            cx.Database.ExecuteSqlCommand("DELETE PRODUCTOS WHERE ID = @id", eId);
        }

        public static void insertProductos(Productos nuevosProductos)
        {
            Context cx = new Context();
            SqlParameter aNombre = new SqlParameter("@nombre", nuevosProductos.NOMBRE);
            SqlParameter aDescripcion = new SqlParameter("@descripcion", nuevosProductos.DESCRIPCION);
            SqlParameter aPrecio = new SqlParameter("@precio", nuevosProductos.PRECIO);
            cx.Database.ExecuteSqlCommand("INSERT INTO PRODUCTOS (NOMBRE,DESCRIPCION,PRECIO)   VALUES  (@nombre, @descripcion, @precio)", aNombre, aDescripcion, aPrecio);
        }

        public System.Data.Entity.DbSet<proyectoRicardo.Models.Productos> Productos { get; set; }
    }
}