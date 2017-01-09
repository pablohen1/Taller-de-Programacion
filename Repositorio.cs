using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.Entity;
using System.Net;

namespace Carteleria_Digital
{
   public class Repositorio
    {
        public static void agregarCampañaSQL(Campaña camp)
        {
            try
            {
                  //Se utiliza el framework Entity, el cual se encarga de la capa de la persistencia.
                            using (var db = new CarteleriaContext())
                            {
                                db.Campañas.Add(camp);
                                db.SaveChanges();
                            }               
            }
            catch { }
        }

        public static void agregarRssSQL(RSS rss1)
        {
            try
            {
                            using (var db = new CarteleriaContext())
                            {
                                RssReutilizable reuti = new RssReutilizable(rss1.texto, rss1.descripcion);
                                db.RSSreutilizables.Add(reuti);
                                db.SaveChanges();
                            }
            }
            catch { }
        }

        public static void agregarBannerSQL(Banner banner1)
        {
            try
            {
                            using (var db = new CarteleriaContext())
                            {
                                db.Banners.Add(banner1);
                                db.SaveChanges();
                            }
            }
            catch { }
        }

        public static void modificarBannerSQL(Banner ban)
        {
            try
            {
                            using (var db = new CarteleriaContext())
                            {
                                var bannerOriginal = db.Banners.Include(j => j.unafuente).Single(j => j.bannerID == ban.bannerID);

                                db.Entry(bannerOriginal).CurrentValues.SetValues(ban);

                                bannerOriginal.unafuente = null;
                                bannerOriginal.unafuente = ban.unafuente;
                                db.SaveChanges();

                            }
            }
            catch { }
        }

        public static void eliminarBannerSQL(int idBanner)
        {
            try
            {
                Banner banner;

                            using (var ctx = new CarteleriaContext())
                            {
                                banner = ctx.Banners.Include(j => j.unafuente).Single(j => j.bannerID == idBanner);
                                ctx.Entry(banner).State = EntityState.Deleted;
                                ctx.SaveChanges();
                            }

            }
            catch { }
        }

        public static List<RSS> obtenerRssSQL()
        {
            List<RSS> rsses = new List<RSS>();
                            try
                            {
                                using (var db = new CarteleriaContext())
                                {
                                    foreach (var rs in db.RSSreutilizables)
                                    {
                                        RSS unrss = new RSS(rs.url, rs.descripcion);
                                        rsses.Add(unrss);
                                    }
                                }
                            }
                            catch { }
            return rsses;
        }

        public static void modificarRssSQL(string unaUrl, string unaDescripcion, string nuevaDescripcion, string nuevaURL)
        {
            try
            {
                using (var db = new CarteleriaContext())
                {
                    var resultado = db.RSSreutilizables.Where(b => b.url == unaUrl && b.descripcion == unaDescripcion).ToList();
                    if (resultado != null)
                    {
                        resultado.ForEach(a => a.descripcion = nuevaDescripcion);
                        resultado.ForEach(a => a.url = nuevaURL);
                        db.SaveChanges();
                    }
                }
            }

            catch { }
        }

        public static void eliminarRssSQL(string unaUrl, string unaDescripcion)
        {
            try
            {
                            using (var db = new CarteleriaContext())
                            {
                                db.RSSreutilizables.RemoveRange(db.RSSreutilizables.Where(c => c.url == unaUrl));
                                db.SaveChanges();
                            }
            }
            catch { }
        }

        public static List<Campaña> obtenerListaCampañasSQL()
        {
            List<Campaña> listaContenidos = new List<Campaña>();

            try
            {
                            using (var db = new CarteleriaContext())
                            {
                                var LAcampaña = db.Campañas.Include(j => j.imagens);

                                foreach (var item in LAcampaña)
                                {
                                    listaContenidos.Add(item);
                                }
                            }
            }
            catch { }
            return listaContenidos;
        }

        public static Campaña obtenerCampañaSQL(int idCamp)
        {
            Campaña laCampaña = new Campaña();

            try
            {
                            using (var db = new CarteleriaContext())
                            {
                                var LAcampaña = db.Campañas.Include(j => j.imagens);

                                foreach (var item in LAcampaña)
                                {
                                    if (item.campañaID == idCamp)
                                    {
                                        laCampaña = item;
                                        break;
                                    }
                                }
                            }             
            }
            catch { }
            return laCampaña;
        }

        public static void eliminarCampañaSQL(int idCamp)
        {
            try
            {
                            Campaña campABorrar;

                            using (var ctx = new CarteleriaContext())
                            {
                                campABorrar = ctx.Campañas.Where(s => s.campañaID == idCamp).FirstOrDefault<Campaña>();
                                campABorrar.imagens.ToList().ForEach(p => ctx.Imagens.Remove(p));
                                ctx.Entry(campABorrar).State = EntityState.Deleted;
                                ctx.SaveChanges();
                            }
            }
            catch { }
        }

        public static void modificarCampañaSQL(Campaña campaña)
        {
            try
            {
                            using (var db = new CarteleriaContext())
                            {
                                var campañaOriginal = db.Campañas.Include(j => j.imagens).Single(j => j.campañaID == campaña.campañaID);

                                db.Entry(campañaOriginal).CurrentValues.SetValues(campaña);

                                campañaOriginal.imagens = null;
                                campañaOriginal.imagens = campaña.imagens;
                                db.SaveChanges();

                            }
            }
            catch { }
        }

        public static List<Banner> obtenerTodosLosBannersSQL()
        {
            List<Banner> listaContenidos = new List<Banner>();

            try
            {
                            using (var db = new CarteleriaContext())
                            {
                                var LAcampaña = db.Banners.Include(j => j.unafuente);

                              foreach (var item in LAcampaña)
                                {
                                    listaContenidos.Add(item);
                                }
                            }
            }
            catch { }
            return listaContenidos;
        }

        public static bool verificarRssSQL(String unRss)
        {
                            try
                            {
                                //Crea el HttpWebRequest
                                HttpWebRequest request = WebRequest.Create(unRss) as HttpWebRequest;
                                //Setea el metodo Head.
                                request.Method = "HEAD";
                                //Se obtiene la respuesta.
                                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                                //Retorna  TRUE si el codigo Status es 200
                                response.Close();
                                return (response.StatusCode == HttpStatusCode.OK);
                            }
                            catch
                            {
                                //Cualquier exepcion retornara false.
                                return false;
                            }
                        }
        
    }
}
