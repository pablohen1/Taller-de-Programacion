using System;
using System.Collections.Generic;

namespace Carteleria_Digital
{//Clase que posee todos los metodos que interactuan con la base de datos utilizando el framework Entity como intermediario.
    public partial class Controlador
    {   
        /// <summary>
        /// Incorpora una nueva campaña al sistema.
        /// </summary>
        /// <param name="camp">Objeto de tipo campaña.</param>
        public static void agregarCampaña(Campaña camp)
        {
            Repositorio.agregarCampañaSQL(camp);
        }

        /// <summary>
        /// Incorpora una fuente RSS al sistema, esta luego puede ser reutilizada por otros banners.
        /// </summary>
        /// <param name="rss1"></param>
        public static void agregarRss(RSS rss1)
        {
            Repositorio.agregarRssSQL(rss1);
        }

        /// <summary>
        /// Incorpora un Banner al sistema.
        /// </summary>
        /// <param name="banner1"></param>
        public static void agregarBanner(Banner banner1)
        {
            Repositorio.agregarBannerSQL(banner1);
            
         }

        /// <summary>
        /// Modifica un banner especifico.
        /// </summary>
        /// <param name="ban"></param>
        public static void modificarBanner (Banner ban)
        {
            Repositorio.modificarBannerSQL(ban);
        }

        /// <summary>
        /// Elimina el primer banner que coincida con el ID entrante.
        /// </summary>
        /// <param name="idBanner"></param>
        public static void eliminarBanner(int idBanner)
        {
            Repositorio.eliminarBannerSQL(idBanner);
        }

        /// <summary>
        /// Obtiene la lista de todos los RSS cargados actualmente.
        /// </summary>
        /// <returns></returns>
        public static List<RSS> obtenerRss()
        {           
            return Repositorio.obtenerRssSQL();
        }

        /// <summary>
        /// Modifica un RSS en particular.
        /// </summary>
        /// <param name="unaUrl"></param>
        /// <param name="unaDescripcion"></param>
        /// <param name="nuevaDescripcion"></param>
        /// <param name="nuevaURL"></param>
        public static void modificarRss(string unaUrl, string unaDescripcion, string nuevaDescripcion, string nuevaURL)
        {
            Repositorio.modificarRssSQL(unaUrl,unaDescripcion,nuevaDescripcion,nuevaURL);
        }

        /// <summary>
        /// Eliminar un RSS en particular.
        /// </summary>
        /// <param name="unaUrl"></param>
        /// <param name="unaDescripcion"></param>
        public static void eliminarRss(string unaUrl, string unaDescripcion)
        {
            Repositorio.eliminarRssSQL(unaUrl,unaDescripcion);
         }

        /// <summary>
        /// Obtiene una lista de imagenes corresponientes a todas aquellas campañas cuyo intervalo de fecha y hora corresponden con el tiempo actual.
        /// </summary>
        /// <returns></returns>
        public static List<Imagen> obtenerImagenesCampañas()
        {
            List<Imagen> listaIMGCampañas = new List<Imagen>();

            try
            {
                            List<Campaña> Campañas = new List<Campaña>();
                            Campañas = obtenerListaCampañas();

                            foreach (Campaña cmp in Campañas)
                            {   //Se comprueba que campañas que se encuentran en el intervalo de fecha y hora actuales, y se los va añadiendo a una lista de tipo Imagen.
                                DateTime tiempoActual = DateTime.Now;

                                DateTime Fini = new DateTime(cmp.fechaInicial.Year, cmp.fechaInicial.Month, cmp.fechaInicial.Day, 0, 0, 0);
                                DateTime FFin = new DateTime(cmp.fechaFinal.Year, cmp.fechaFinal.Month, cmp.fechaFinal.Day, 0, 0, 0);
                                DateTime Hini = new DateTime(tiempoActual.Year, tiempoActual.Month, tiempoActual.Day, cmp.horaInicial.Hour, cmp.horaInicial.Minute, cmp.horaInicial.Second);
                                DateTime HFin = new DateTime(tiempoActual.Year, tiempoActual.Month, tiempoActual.Day, cmp.horaFinal.Hour, cmp.horaFinal.Minute, cmp.horaFinal.Second);

                                if ((((Fini < tiempoActual || Fini.Equals(tiempoActual)) && (FFin.AddDays(1) > tiempoActual || FFin.Equals(tiempoActual)))) && ((Hini < tiempoActual || Hini.Equals(tiempoActual)) && HFin > tiempoActual))
                                {
                                    {
                                        if (cmp.imagens != null)
                                        {
                                            foreach (Imagen img in cmp.imagens)
                                            {
                                                listaIMGCampañas.Add(img);
                                            }
                                        }
                                    }
                                }
                }
            }
            catch { }
            return listaIMGCampañas;
        }



        /// <summary>
        /// Obtiene la lista de todas las campañas.
        /// </summary>
        /// <returns></returns>
        public static List<Campaña> obtenerListaCampañas()
        {
            return Repositorio.obtenerListaCampañasSQL();
        }


        /// <summary>
        /// Obtiene una campaña en particular por su ID.
        /// </summary>
        /// <param name="idCamp"></param>
        /// <returns></returns>
        public static Campaña obtenerCampaña(int idCamp)
        {
            return Repositorio.obtenerCampañaSQL(idCamp);
        }

        /// <summary>
        /// Obtiene un texto formado por union de todos los banners cuyos intevalos de fecha y hora verifiquen con el tiempo actual.
        /// </summary>
        /// <returns></returns>
        public static List<string> obtenerBannersActuales()
        {
            List<string> bnr = new List<string>();
            List<Banner> listaContenidos = Repositorio.obtenerTodosLosBannersSQL();

                                try
                                {   //Se comprueba que banners que se encuentran en el intervalo de fecha y hora actuales, y se los va añadiendo a un string.
                                    foreach (var item in listaContenidos)
                                    {
                                        DateTime tiempoActual = DateTime.Now;

                                        DateTime Fini = new DateTime(item.fechaInicial.Year, item.fechaInicial.Month, item.fechaInicial.Day, 0, 0, 0);
                                        DateTime FFini = new DateTime(item.fechaFinal.Year, item.fechaFinal.Month, item.fechaFinal.Day, 0, 0, 0);
                                        DateTime Hini = new DateTime(tiempoActual.Year, tiempoActual.Month, tiempoActual.Day, item.horaInicial.Hour, item.horaInicial.Minute, item.horaInicial.Second);
                                        DateTime HFini = new DateTime(tiempoActual.Year, tiempoActual.Month, tiempoActual.Day, item.horaFinal.Hour, item.horaFinal.Minute, item.horaFinal.Second);

                                        if ((((Fini < tiempoActual || Fini.Equals(tiempoActual)) && (FFini.AddDays(1) > tiempoActual || FFini.Equals(tiempoActual)))) && ((Hini < tiempoActual || Hini.Equals(tiempoActual)) && HFini > tiempoActual))
                                        {
                                            var unBanner = item.unafuente;
                                            bnr.Add(unBanner.obtenerTexto());
                                        }
                                    }

                                }
                                catch
                                { }
                            
            return bnr;
        }

        /// <summary>
        /// Elimina una campaña en particular utilizando su ID.
        /// </summary>
        /// <param name="idCamp"></param>
        public static void eliminarCampaña(int idCamp)
        {
            Repositorio.eliminarCampañaSQL(idCamp);
            }

        /// <summary>
        /// Modifica una campaña en particular, con los datos de un objeto tipo Campaña.
        /// </summary>
        /// <param name="campaña"></param>
        public static void modificarCampaña(Campaña campaña)
        {
            Repositorio.modificarCampañaSQL(campaña);
        }

        /// <summary>
        /// Obtiene la lista de todos los banners cargados al sistema.
        /// </summary>
        /// <returns></returns>
        public static List<Banner> obtenerTodosLosBanners()
        {    
            return Repositorio.obtenerTodosLosBannersSQL();
            }

        public static bool verificarRss(String unRss)
        {
            return Repositorio.verificarRssSQL(unRss);
        }
        }
    }

