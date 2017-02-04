using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperRepoWinForm.ClassObjects;
using DapperRepoWinForm.Repository;
using DapperRepoWinForm.Utilities;
using Dapper;

namespace DapperRepoWinForm.Bll
{
    partial class users
    {

        public string insertUpdate( ClassObjects.users _users)
        {
            RepGen  reposGen = new Repository.RepGen();
            DynamicParameters param = new DynamicParameters();
            param.Add("@id", _users.id);
            param.Add("@name", _users.name);
            param.Add("@address", _users.address);
            param.Add("@status", _users.status);
            return reposGen.executeNonQuery ("users_Insert_Update", param);
        }

        public string delete(ClassObjects.users _users)
        {
            RepGen reposGen = new Repository.RepGen();
            DynamicParameters param = new DynamicParameters();
            param.Add("@id", _users.id);
            return reposGen.executeNonQuery("users_DeleteRow_By_id", param);
        }

        public List<ClassObjects.users> allRecords(ClassObjects.users  _usuario)
        {
            RepList<ClassObjects.users> lista = new RepList<ClassObjects.users>();
            DynamicParameters param = new DynamicParameters();
            return lista.returnListClass("users_SelectAll", param);

        }

        public List<ClassObjects.users> AllRecordsById(string id)
        {
            RepList<ClassObjects.users> lista = new RepList<ClassObjects.users>();
            DynamicParameters param = new DynamicParameters();
            param.Add("@id", id);
            return lista.returnListClass("users_SelectRow_By_id", param);
        }

        public ClassObjects.users findById(string id)
        {
            RepList<ClassObjects.users> class_usu = new RepList<ClassObjects.users>();
            DynamicParameters param = new DynamicParameters();
            param.Add("@Id", id);
            return class_usu.returnClass("users_SelectRow_By_id", param);
        }

        public List<dynamic> dynamicsList()
        {
            Funciones FG = new Funciones();
            DynamicParameters param = new DynamicParameters();
            Repository.RepList<dynamic> repo = new Repository.RepList<dynamic>();
            var items = repo.returnListClass("users_SelectwithDate", param);
            return items;
        }

    }




}
