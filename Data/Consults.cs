using Reclutamiento.Models;
using MySql.Data.MySqlClient;


namespace Reclutamiento.Data
{
    public class Consults
    {
        public Boolean Capturas(ProspectosModel prosp)
        {
            var conexion = new DBConecction();
            try
            {
                using (var conn = new MySqlConnection(conexion.getCadena()))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO `expediente`.`prospectos` (`Nombre`,`ApellidoPaterno`, " +
                        "`ApellidoMaterno`,`Calle`,`Numero`,`Colonia`,`CodigoPostal`,`Telefono`,`RFC`,`Estatus`, `Descripcion`) " +
                        "VALUES ('" + prosp.Nombre + "', '" + prosp.ApellidoPaterno + "', '" + prosp.ApellidoMaterno + "', '" 
                        + prosp.Calle + "', " + Convert.ToInt32(prosp.Numero) + ", '" + prosp.Colonia + "', "
                        + Convert.ToInt32(prosp.CodigoPostal) + ", " + Convert.ToInt32(prosp.Telefono) + ", '" 
                        + prosp.RFC + "', 'Enviado', 'S/D' );", conn);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception e)
            {
                String error = e.Message;
                Console.WriteLine(error);
                return false;
            }
        }

        public List<ProspectosModel> Listar()
        {
            var lista = new List<ProspectosModel>();
            var conexion = new DBConecction();

            try
            {
                using (var conn = new MySqlConnection(conexion.getCadena()))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("select id, Nombre, ApellidoPaterno, ApellidoMaterno, Estatus, Descripcion from prospectos", conn);

                    using (var read = cmd.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            lista.Add(new ProspectosModel()
                            {
                                id = Convert.ToInt32(read["id"]),
                                Nombre = read["nombre"].ToString(),
                                ApellidoPaterno = read["ApellidoPaterno"].ToString(),
                                ApellidoMaterno = read["ApellidoMaterno"].ToString(),
                                Estatus = read["Estatus"].ToString(),
                                Descripcion = read["Descripcion"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception e)
            {
                String error = e.Message;
                Console.Write(error);
            }

            return lista;
        }

        public List<ProspectosModel> Evaluar()
        {
            var lista = new List<ProspectosModel>();
            var conexion = new DBConecction();

            try
            {
                using (var conn = new MySqlConnection(conexion.getCadena()))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("select id, Nombre, ApellidoPaterno, ApellidoMaterno, Calle, Numero, Colonia, CodigoPostal, Telefono, RFC, Estatus, Descripcion from prospectos", conn);

                    using (var read = cmd.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            lista.Add(new ProspectosModel()
                            {
                                id = Convert.ToInt32(read["id"]),
                                Nombre = read["nombre"].ToString(),
                                ApellidoPaterno = read["ApellidoPaterno"].ToString(),
                                ApellidoMaterno = read["ApellidoMaterno"].ToString(),
                                Calle = read["Calle"].ToString(),
                                Numero = read["Numero"].ToString(),
                                Colonia =  read["Colonia"].ToString(),
                                CodigoPostal = read["CodigoPostal"].ToString(),
                                Telefono = read["Telefono"].ToString(),
                                RFC = read["RFC"].ToString(),
                                Estatus = read["Estatus"].ToString(),
                                Descripcion = read["Descripcion"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception e)
            {
                String error = e.Message;
                Console.Write(error);
            }

            return lista;
        }

        public Boolean Autorizar(int ID)
        {
            var conexion = new DBConecction();
            try
            {
                using (var conn = new MySqlConnection(conexion.getCadena()))
                {
                    conn.Open();
                    Console.WriteLine("Conectado autoixar");
                    MySqlCommand cmd = new MySqlCommand("UPDATE `expediente`.`prospectos` SET `Estatus` = 'Autorizado' WHERE `id` = "+ ID +"", conn);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception e)
            {
                String error = e.Message;
                Console.WriteLine(error);
                return false;
            }
        }

        public Boolean Rechazar(int ID, string Descripcion)
        {
            var conexion = new DBConecction();
            try
            {
                using (var conn = new MySqlConnection(conexion.getCadena()))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("UPDATE `expediente`.`prospectos` SET `Estatus` = 'Rechazado', Descripcion = '"+Descripcion+"' WHERE `id` = "+ID+"", conn);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception e)
            {
                String error = e.Message;
                Console.WriteLine(error);
                return false;
            }
        }

        public ProspectosModel Obtener( int ID) 
        { 
            var prospecto = new ProspectosModel();
            var conexion = new DBConecction();

            try
            {
                using (var conn = new MySqlConnection(conexion.getCadena()))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("select id, Nombre, ApellidoPaterno, ApellidoMaterno, Calle, Numero, Colonia, CodigoPostal, Telefono, RFC, Estatus, Descripcion from prospectos where id = "+ID, conn);

                    using (var read = cmd.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            prospecto.id = Convert.ToInt32(read["id"]);
                            prospecto.Nombre = read["nombre"].ToString();
                            prospecto.ApellidoPaterno = read["ApellidoPaterno"].ToString();
                            prospecto.ApellidoMaterno = read["ApellidoMaterno"].ToString();
                            prospecto.Calle = read["Calle"].ToString();
                            prospecto.Numero = read["Numero"].ToString();
                            prospecto.Colonia = read["Colonia"].ToString();
                            prospecto.CodigoPostal = read["CodigoPostal"].ToString();
                            prospecto.Telefono = read["Telefono"].ToString();
                            prospecto.RFC = read["RFC"].ToString();
                            prospecto.Estatus = read["Estatus"].ToString();
                            prospecto.Descripcion = read["Descripcion"].ToString();
                            
                        }
                    }
                }
            }
            catch (Exception e)
            {
                String error = e.Message;
                Console.Write(error);
            }

            return prospecto;
        }
    }
}
