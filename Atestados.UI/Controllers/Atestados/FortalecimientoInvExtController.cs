﻿using Atestados.Datos.Modelo;
using Atestados.Negocios.Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Atestados.Objetos.Dtos;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using System.Web.Routing;

namespace Atestados.UI.Controllers.Atestados
{
    public class FortalecimientoInvExtController : Controller
    {
        private AtestadosEntities db = new AtestadosEntities();
        private InformacionAtestado infoAtestado = new InformacionAtestado();
        private InformacionGeneral infoGeneral = new InformacionGeneral();
        private readonly string Rubro = "Actividades para el fortalecimiento de la investigación y la extensión";
        public static List<ArchivoDTO> archivosOld = null;

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Si la sesión es null, se redirige a la página de login
            if (Session["Usuario"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        {"controller", "Login"},
                        {"action", "Index"}
                    }
                );
                return;
            }
        }

        // GET: FortalecimientoInvExt
        public ActionResult Index()
        {
            return View(infoAtestado.CargarAtestadosDeTipo(infoAtestado.ObtenerIDdeRubro(Rubro)));
        }

        // GET: FortalecimientoInvExt/Ver/:id
        //probar
        public ActionResult Ver(int? id)
        {
            UsuarioDTO usuario = (UsuarioDTO)Session["Usuario"];

            // Validar los datos ingresados.
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            AtestadoDTO atestado = infoAtestado.CargarAtestado(id);

            if (atestado == null)
                return HttpNotFound();

            // Asignar los datos para visualizar.
            ViewBag.Autores = infoAtestado.CargarAutoresAtestado(id);
            ViewBag.NotasPonderadas = infoAtestado.CargarNotasPonderadasAutores(id);
            ViewBag.Puntos = infoAtestado.CargarPuntosAutores(id);
            Session["TipoUsuario"] = usuario.TipoUsuario;
            Session["idAtestado"] = id;
            Session["idUsuario"] = usuario.UsuarioID;
            return View(atestado);
        }

        // GET: FortalecimientoInvExt/Crear
        public ActionResult Crear()
        {
            AtestadoDTO actFortalecimiento = new AtestadoDTO();
            actFortalecimiento.FechaInicio = DateTime.Now;
            actFortalecimiento.FechaFinal = DateTime.Now;
            actFortalecimiento.NumeroAutores = 1;
            ViewBag.PaisID = new SelectList(db.Pais, "PaisID", "Nombre", infoAtestado.ObtenerIDdePais("costa rica")); ;
            ViewBag.Atestados = infoAtestado.CargarAtestadosDePersonaPorTipo(infoAtestado.ObtenerIDdeRubro(Rubro), (int)Session["UsuarioID"]);

            //Agregar Usuario como autor
            UsuarioDTO usuario = (UsuarioDTO)Session["Usuario"];
            AutorDTO autorUsuario = new AutorDTO();
            autorUsuario.Nombre = usuario.Nombre;
            autorUsuario.PrimerApellido = usuario.PrimerApellido;
            autorUsuario.SegundoApellido = usuario.SegundoApellido;
            autorUsuario.Email = usuario.Email;
            autorUsuario.PersonaID = usuario.UsuarioID;
            autorUsuario.Porcentaje = 100;
            autorUsuario.esFuncionario = true;
            autorUsuario.porcEquitativo = false;
            autorUsuario.numAutor = 1;

            // Limpiar las listas de archivos y autores por si tienen basura.
            Session["Autores"] = new List<AutorDTO> { autorUsuario };
            Session["Archivos"] = new List<ArchivoDTO>();

            return View(actFortalecimiento);
        }

        // POST: FortalecimientoInvExt/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "AtestadoID,Nombre,NumeroAutores,Codigo,Observaciones,HoraCreacion,Enviado,FechaInicio,FechaFinal,Descargado,CantidadHoras,Lugar,CatalogoTipo,Enlace,PaisID,PersonaID,RubroID,AutoresEq,AutoresCheck")] AtestadoDTO atestado)
        {
            if (!atestado.AutoresCheck)
                ModelState.AddModelError("AutoresCheck", "La actividad debe tener al menos un autor.");
            else
            if (ModelState.IsValid)
            {
                List<AutorDTO> autores = (List<AutorDTO>)Session["Autores"];
                List<ArchivoDTO> archivos = (List<ArchivoDTO>)Session["Archivos"];
                // Obtener el id del usuario que está agregando el atestado.
                atestado.PersonaID = (int)Session["UsuarioID"];
                atestado.RubroID = infoAtestado.ObtenerIDdeRubro(Rubro);
                atestado.NumeroAutores = autores.Count();
                atestado.PaisID = infoAtestado.ObtenerIDdePais("costa rica"); // Costa Rica

                // Mappear el atestado una vez que está completo.
                // Esta operación es muy frágil, y podría llevar a errores de llaves en la BD.
                Atestado atestado_mapped = AutoMapper.Mapper.Map<AtestadoDTO, Atestado>(atestado);
                infoAtestado.GuardarAtestado(atestado_mapped);
                // Obtener y guardar información adicional del atestado.
                atestado.AtestadoID = atestado_mapped.AtestadoID;
                Fecha fecha = AutoMapper.Mapper.Map<AtestadoDTO, Fecha>(atestado);
                infoAtestado.GuardarFecha(fecha);

                // Agregar archivos
                AtestadoShared.obj.guardarArchivos(archivos, infoAtestado, atestado_mapped);

                // Agregar autores
                AtestadoShared.obj.guardarAutores(autores, infoGeneral, infoAtestado, atestado.AutoresEq, atestado_mapped);

                Session["Archivos"] = new List<ArchivoDTO>();
                Session["Autores"] = new List<AutorDTO>();

                return RedirectToAction("Crear");
            }
            ViewBag.PaisID = new SelectList(db.Pais, "PaisID", "Nombre", atestado.PaisID);
            ViewBag.Atestados = infoAtestado.CargarAtestadosDePersonaPorTipo(infoAtestado.ObtenerIDdeRubro(Rubro), (int)Session["UsuarioID"]);
            return View(atestado);
        }

        // GET: FortalecimientoInvExt/Editar/:id
        public ActionResult Editar(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            // Asegurarse que los autores y archivos no son nulos.
            if (Session["Archivos"] == null)
                Session["Archivos"] = new List<ArchivoDTO>();
            if (Session["Autores"] == null)
                Session["Autores"] = new List<AutorDTO>();

            // Cargar el atestado y verificar que no es nulo.
            Atestado atestado = infoAtestado.CargarAtestadoParaEditar(id);
            if (atestado == null)
                return HttpNotFound();

            AtestadoDTO atestado_mapped = AutoMapper.Mapper.Map<Atestado, AtestadoDTO>(atestado);

            // Cargar y poner los datos adicionales del formulario en la vista.
            ViewBag.PaisID = new SelectList(db.Pais, "PaisID", "Nombre", atestado.PaisID);
            ViewBag.AtestadoID = new SelectList(db.Fecha, "FechaID", "FechaID", atestado.AtestadoID);
            ViewBag.Atestados = infoAtestado.CargarAtestadosDePersonaPorTipo(infoAtestado.ObtenerIDdeRubro(Rubro), (int)Session["UsuarioID"]);
            // Guardar el estado de los archivos previos a su edición.
            archivosOld = new List<ArchivoDTO>();
            List<ArchivoDTO> tmpList = infoAtestado.CargarArchivosDeAtestado(id);
            tmpList.ForEach((item) => { archivosOld.Add(new ArchivoDTO(item)); });
            Session["Archivos"] = infoAtestado.CargarArchivosDeAtestado(id);
            Session["Autores"] = infoAtestado.CargarAutoresAtestado(atestado.AtestadoID);
            indexarListas();
            return View(atestado_mapped);
        }

        // Indexar las listas de autores y archivos con números.
        private void indexarListas()
        {
            int cont = 1;
            List<ArchivoDTO> archivos = (List<ArchivoDTO>)Session["Archivos"];
            List<AutorDTO> autores = (List<AutorDTO>)Session["Autores"];

            foreach (ArchivoDTO archivo in archivos)
                archivo.numArchivo = cont++;

            cont = 1;
            foreach (AutorDTO autor in autores)
                autor.numAutor = cont++;

            Session["Archivos"] = archivos;
            Session["Autores"] = autores;
        }

        // POST: FortalecimientoInvExt/Editar/:id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "AtestadoID,Nombre,NumeroAutores,Codigo,Observaciones,HoraCreacion,Enviado,FechaInicio,FechaFinal,Fecha,Descargado,CantidadHoras,Lugar,CatalogoTipo,Enlace,PaisID,PersonaID,RubroID,AutoresEq,AutoresCheck")] AtestadoDTO atestado)
        {
            if (!atestado.AutoresCheck)
                ModelState.AddModelError("AutoresCheck", "La actividad debe tener al menos un autor.");
            else
            if (ModelState.IsValid)
            {
                List<ArchivoDTO> archivos = (List<ArchivoDTO>)Session["Archivos"];
                List<AutorDTO> autores = (List<AutorDTO>)Session["Autores"];

                atestado.PersonaID = (int)Session["UsuarioID"];
                atestado.RubroID = infoAtestado.ObtenerIDdeRubro(Rubro);
                atestado.PaisID = infoAtestado.ObtenerIDdePais("costa rica");
                atestado.Fecha.FechaID = atestado.AtestadoID;
                infoAtestado.EditarFecha(AutoMapper.Mapper.Map<FechaDTO, Fecha>(atestado.Fecha));
                atestado.HoraCreacion = DateTime.Now;
                atestado.Archivos = infoAtestado.CargarArchivosDeAtestado(atestado.AtestadoID);
                atestado.AtestadoXPersona = AutoMapper.Mapper.Map<List<AtestadoXPersona>, List<AtestadoXPersonaDTO>>(infoAtestado.CargarAtestadoXPersonasdeAtestado(atestado.AtestadoID));
                
                atestado.NumeroAutores = autores.Count();
                Atestado atestado_mapped = AutoMapper.Mapper.Map<AtestadoDTO, Atestado>(atestado);
                infoAtestado.EditarAtestado(atestado_mapped);

                // Agregar archivos
                AtestadoShared.obj.editarArchivos(archivosOld, archivos, infoAtestado, atestado_mapped);

                // Agregar autores
                AtestadoShared.obj.editarAutores(autores, infoGeneral, infoAtestado, atestado.AutoresEq, atestado_mapped);

                Session["Archivos"] = new List<ArchivoDTO>();
                Session["Autores"] = new List<AutorDTO>();
                archivosOld = new List<ArchivoDTO>();

                return RedirectToAction("Crear");
            }
            ViewBag.PaisID = new SelectList(db.Pais, "PaisID", "Nombre", atestado.PaisID);
            ViewBag.AtestadoID = new SelectList(db.Fecha, "FechaID", "FechaID", atestado.AtestadoID);
            ViewBag.Atestados = infoAtestado.CargarAtestadosDePersonaPorTipo(infoAtestado.ObtenerIDdeRubro(Rubro), (int)Session["UsuarioID"]);
            ViewBag.Autores = infoAtestado.CargarAutoresAtestado(atestado.AtestadoID);
            return View(atestado);
        }

        // GET: FortalecimientoInvExt/Borrar/:id
        public ActionResult Borrar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atestado atestado = infoAtestado.CargarAtestadoParaBorrar(id);
            if (atestado == null)
            {
                return HttpNotFound();
            }
            ViewBag.Autores = infoAtestado.CargarAutoresAtestado(id);
            return View(atestado);
        }

        // POST: FortalecimientoInvExt/Borrar/:id
        [HttpPost, ActionName("Borrar")]
        [ValidateAntiForgeryToken]
        public ActionResult Borrar(int id)
        {
            infoAtestado.BorrarAtestado(id);
            return RedirectToAction("Crear");
        }
    }
}
