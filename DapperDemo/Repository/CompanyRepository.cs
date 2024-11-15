using Dapper;
using DapperDemo.Data;
using DapperDemo.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DapperDemo.Repository
{
    public class CompnyRepository : ICompanyRepository
    {
        private IDbConnection db;

        public CompnyRepository(IConfiguration configuration)
        {
            this.db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        public Company Add(Company company)
        {
            var sql = "INSERT INTO Companies (Name, Address, City, State, PostalCode) VALUES(@Name, @Address, @City, @State, @PostalCode);"
                + "SELECT CAST(SCOPE_IDENTITY() as int);";
            var id = db.Query<int>(sql,company).Single();
            company.CompayId = id;
            return company;
        }

        public Company Find(int id)
        {
            var sql = "SELECT * FROM Companies WHERE CompayId = @CompayId";
            return db.Query<Company>(sql, new {@CompayId = id}).Single();
        }

        public List<Company> GetAll()
        {
            var sql = "Select * FROM Companies";
            return db.Query<Company>(sql).ToList();   
        }

        public void Remove(int id)
        {
            var sql = "DELETE FROM Companies WHERE CompayId = @id";
            db.Execute(sql, new { id });
        }

        public Company Update(Company company)
        {
            var sql = "UPDATE Companies SET Name = @Name, Address = @Address, City = @City, " +
                "State = @State, PostalCode = @PostalCode WHERE CompayId = @CompayId";
            db.Execute(sql, company);
            return company;
        }
    }
}
