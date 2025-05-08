using Microsoft.AspNetCore.Mvc;
using MvcNetCoreAWSPostgresEC2.Models;
using MvcNetCoreAWSPostgresEC2.Repositories;

namespace MvcNetCoreAWSPostgresEC2.Controllers
{
    public class DepartamentosController : Controller
    {
        private RepositoryHospital repo;

        public DepartamentosController(RepositoryHospital repo) {
            this.repo = repo;
        }

        public async Task<IActionResult> Index() {
            List<Departamento> lista = await this.repo.GetDepartamentosAsync();
            return View(lista);
        }

        public async Task<IActionResult> Details(int id) {
            Departamento departamento = await this.repo.FindDepartamentoAsync(id);
            return View(departamento);
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Departamento departamento) {
            await this.repo.InsertDepartamentoAsync(departamento.IdDept, departamento.Nombre, departamento.Loc);
            return RedirectToAction("Index");
        }
    }
}
