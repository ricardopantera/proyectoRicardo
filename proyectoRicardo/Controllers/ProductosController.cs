using proyectoRicardo.Contexto;
using proyectoRicardo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyectoRicardo.Controllers
{
    public class ProductosController : Controller
    {
        // GET: Productos
        public ActionResult ProductosIndex()
        {
            List<Productos> result = Context.GetProductos();

            return View(result);
        }

        [HttpGet]
        public ActionResult DetalleDelProdcuto(int id)
        {

            Productos  resultado = Context.getProductosId(id);
            return View(resultado);
        }

        [HttpGet]
        public ActionResult EditarProducto(int id)
        {
            Productos editar = Context.getProductosId(id);
            return View(editar);
        }
       
        [HttpPost]
        public  ActionResult EditarProducto(Productos editarProductos)
        {
            Context.updateProductos(editarProductos);
            List<Productos> result = Context.GetProductos();
            return View("ProductosIndex", result);
        }


    


        [HttpGet]

        public ActionResult eliminarProductos(int? id)
        {
            Productos resultado = Context.getProductosId(id);
            return View(resultado);
        }

        [HttpPost]
        public ActionResult eliminarProductos(int id)
        {

            Context.deleteProductos(id);
            var result = Context.GetProductos();
            return View("ProductosIndex",result);
        }

        
        public ActionResult agregarProducto()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult agregarProducto(Productos nuevosProductos)
        {
            Context.insertProductos(nuevosProductos);
            var resultado = Context.GetProductos();
            return View ("ProductosIndex", resultado);
        }

        public ActionResult manejoDeEscuchadores()
        {
            return View();
        }


    }
}