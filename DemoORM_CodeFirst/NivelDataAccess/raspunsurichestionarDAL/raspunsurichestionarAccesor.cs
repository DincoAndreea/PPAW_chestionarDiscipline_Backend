using Dapper;
using LibrarieModele;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NivelDataAccess.raspunsurichestionarDAL
{
    public class raspunsurichestionarAccesor : IraspunsurichestionarAccesor
    {
        public RaportComplet GetRaportComplet(raspunsurichestionarDTO raspunsurichestionarDTO)
        {

            RaportComplet raport = new RaportComplet();
            var parameters = new DynamicParameters();
            parameters.Add("disciplina", raspunsurichestionarDTO.id_disciplina, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameters.Add("tipActivitate", raspunsurichestionarDTO.id_tip_activitate, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            var connexion = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["chestionarDisciplineCS"].ConnectionString);

            var result = connexion.QueryMultiple("raport_complet", parameters, commandType: System.Data.CommandType.StoredProcedure);

            raport.intrebarea1 = result.Read<Raport>().ToList();
            raport.intrebarea2 = result.Read<Raport>().ToList();
            raport.intrebarea3 = result.Read<Raport>().ToList();
            raport.intrebarea4 = result.Read<Raport>().ToList();
            raport.intrebarea5 = result.Read<Raport>().ToList();
            raport.intrebarea6 = result.Read<Raport>().ToList();
            raport.intrebarea7 = result.Read<Raport>().ToList();
            raport.intrebarea8 = result.Read<Raport>().ToList();
            raport.intrebarea9 = result.Read<Raport>().ToList();
            raport.intrebarea10 = result.Read<Raport>().ToList();
            raport.intrebarea11 = result.Read<Raport>().ToList();
            raport.intrebarea12 = result.Read<Raport>().ToList();
            raport.intrebarea13 = result.Read<Raport>().ToList();
            raport.intrebarea14 = result.Read<Raport>().ToList();
            raport.intrebarea15 = result.Read<Raport>().ToList();
            raport.intrebarea16 = result.Read<Raport>().ToList();

            return raport;

        }
    }
}
