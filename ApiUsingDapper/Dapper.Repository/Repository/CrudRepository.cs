﻿using Dapper.Repository.IRepository;
using Dapper.Repository.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Repository.Repository
{
    public class CrudRepository : ICrud
    {
        public readonly string connectionString;
        public CrudRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<EmployeeModel> GetAll()
        {
            IEnumerable<EmployeeModel> listemployee = null;
            using (var connection = new SqlConnection(connectionString))
            {
                listemployee =  connection.Query<EmployeeModel>("select Id, EmployeeName, Role, Salary, Company from Employee");
            }
            return listemployee;
        }
    }
}