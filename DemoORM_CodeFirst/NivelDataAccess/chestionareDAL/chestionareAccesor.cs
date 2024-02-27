using Dapper;
using LibrarieModele;
using Repository_CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace NivelDataAccess.chestionareDAL
{
    public class chestionareAccesor : IchestionareAccesor
    {
        private IContextDB _db;

        public chestionareAccesor()
        {
            _db = new ContextDb();
        }

        public chestionareAccesor(IContextDB db)
        {
            _db = db;
        }

        public void AddChestionarPartial(chestionarpartialDTO chestionarpartialDTO)
        {

            if (!ChestionarExists(chestionarpartialDTO.id_student, chestionarpartialDTO.id_disciplina, chestionarpartialDTO.id_tip_activitate, chestionarpartialDTO.numar_activitate))
            {

                var parameters = new DynamicParameters();
                parameters.Add("idStudent", chestionarpartialDTO.id_student, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                parameters.Add("idDisciplina", chestionarpartialDTO.id_disciplina, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                parameters.Add("idAnDeStudiu", chestionarpartialDTO.id_an_de_studiu, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                parameters.Add("idProgramDeStudiu", chestionarpartialDTO.id_program_de_studiu, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                parameters.Add("idTipActivitate", chestionarpartialDTO.id_tip_activitate, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                parameters.Add("numarActivitate", chestionarpartialDTO.numar_activitate, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                parameters.Add("textRaspuns1", chestionarpartialDTO.text_raspuns1, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                parameters.Add("textRaspuns5", chestionarpartialDTO.text_raspuns5, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                parameters.Add("textRaspuns6", chestionarpartialDTO.text_raspuns6, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                parameters.Add("textRaspuns7", chestionarpartialDTO.text_raspuns7, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                parameters.Add("textRaspuns8", chestionarpartialDTO.text_raspuns8, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                parameters.Add("textRaspuns10", chestionarpartialDTO.text_raspuns10, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                parameters.Add("textRaspuns11", chestionarpartialDTO.text_raspuns11, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                parameters.Add("textRaspuns15", chestionarpartialDTO.text_raspuns15, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                parameters.Add("textRaspuns16", chestionarpartialDTO.text_raspuns16, System.Data.DbType.String, System.Data.ParameterDirection.Input);

                var connexion = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["chestionarDisciplineCS"].ConnectionString);

                connexion.Execute("chestionar_partial", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }

        }

        public void AddChestionarComplet(chestionarcompletDTO chestionarcompletDTO)
        {

            if (!ChestionarExists(chestionarcompletDTO.id_student, chestionarcompletDTO.id_disciplina, chestionarcompletDTO.id_tip_activitate, chestionarcompletDTO.numar_activitate))
            {

                var parameters = new DynamicParameters();
                parameters.Add("idStudent", chestionarcompletDTO.id_student, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                parameters.Add("idDisciplina", chestionarcompletDTO.id_disciplina, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                parameters.Add("idAnDeStudiu", chestionarcompletDTO.id_an_de_studiu, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                parameters.Add("idProgramDeStudiu", chestionarcompletDTO.id_program_de_studiu, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                parameters.Add("idTipActivitate", chestionarcompletDTO.id_tip_activitate, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                parameters.Add("numarActivitate", chestionarcompletDTO.numar_activitate, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
                parameters.Add("textRaspuns1", chestionarcompletDTO.text_raspuns1, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                parameters.Add("textRaspuns2", chestionarcompletDTO.text_raspuns2, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                parameters.Add("textRaspuns3", chestionarcompletDTO.text_raspuns3, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                parameters.Add("textRaspuns4", chestionarcompletDTO.text_raspuns4, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                parameters.Add("textRaspuns5", chestionarcompletDTO.text_raspuns5, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                parameters.Add("textRaspuns6", chestionarcompletDTO.text_raspuns6, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                parameters.Add("textRaspuns7", chestionarcompletDTO.text_raspuns7, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                parameters.Add("textRaspuns8", chestionarcompletDTO.text_raspuns8, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                parameters.Add("textRaspuns9", chestionarcompletDTO.text_raspuns9, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                parameters.Add("textRaspuns10", chestionarcompletDTO.text_raspuns10, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                parameters.Add("textRaspuns11", chestionarcompletDTO.text_raspuns11, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                parameters.Add("textRaspuns12", chestionarcompletDTO.text_raspuns12, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                parameters.Add("textRaspuns13", chestionarcompletDTO.text_raspuns13, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                parameters.Add("textRaspuns14", chestionarcompletDTO.text_raspuns14, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                parameters.Add("textRaspuns15", chestionarcompletDTO.text_raspuns15, System.Data.DbType.String, System.Data.ParameterDirection.Input);
                parameters.Add("textRaspuns16", chestionarcompletDTO.text_raspuns16, System.Data.DbType.String, System.Data.ParameterDirection.Input);

                var connexion = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["chestionarDisciplineCS"].ConnectionString);

                connexion.Execute("chestionar_complet", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }

        }

        public List<chestionare> GetChestionareByStudentAndTipActivitateAndDisciplina(activitatineevaluateDTO activitatineevaluateDTO)
        {
            var chestionare = _db.chestionare.Include(x => x.discipline).Where(x => x.id_student == activitatineevaluateDTO.student.id_student 
            && x.id_tip_activitate == activitatineevaluateDTO.tipactivitate.id_tip_activitate 
            && x.id_disciplina == activitatineevaluateDTO.disciplina.id_disciplina).ToList();
            if (chestionare.Count < 1)
            {
                return new List<chestionare>();
            }
            return chestionare;
        }

        public bool ChestionarExists(int id_student, int id_disciplina, int id_tip_activitate, int numar_activitate)
        {

            if (_db.chestionare.Any(e => e.id_student == id_student && e.id_disciplina == id_disciplina && e.id_tip_activitate == id_tip_activitate && e.numar_activitate == numar_activitate))
            {
                return true;
            }
            return false;
        }
    }
}
