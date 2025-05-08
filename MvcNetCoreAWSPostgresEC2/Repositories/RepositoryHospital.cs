using Microsoft.EntityFrameworkCore;
using MvcNetCoreAWSPostgresEC2.Data;
using MvcNetCoreAWSPostgresEC2.Models;

namespace MvcNetCoreAWSPostgresEC2.Repositories
{
    public class RepositoryHospital
    {
        private HospitalContext context;

        public RepositoryHospital(HospitalContext context) {
            this.context = context;
        }

        public async Task<List<Departamento>> GetDepartamentosAsync() {
            return await this.context.Departamentos.ToListAsync();
        }

        public async Task<Departamento> FindDepartamentoAsync(int id) {
            return await this.context.Departamentos.FindAsync(id);
        }

        public async Task InsertDepartamentoAsync(int id, string nombre, string localidad) {
            Departamento departamento = new Departamento();
            departamento.IdDept = id;
            departamento.Nombre = nombre;
            departamento.Loc = localidad;
            this.context.Departamentos.Add(departamento);
            await this.context.SaveChangesAsync();
        }
    }
}
