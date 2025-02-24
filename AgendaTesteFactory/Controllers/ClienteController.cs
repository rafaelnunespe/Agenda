using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaTesteFactory.Models;
using AgendaTesteFactory.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace AgendaTesteFactory.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteRepositorio _clienteRepositorio;

        public ClienteController(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        public IActionResult Index()
        {
            List<ClienteModel> clientes = _clienteRepositorio.BuscarTodos();
            return View(clientes);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            ClienteModel cliente = _clienteRepositorio.BuscarPorId(id);
            return View(cliente);
        }

        public IActionResult ExcluirConfirma(int id)
        {
            ClienteModel cliente = _clienteRepositorio.BuscarPorId(id);
            return View(cliente);
        }

        public IActionResult Excluir(int id)
        {
            try
            {
                bool deletou = _clienteRepositorio.Apagar(id);

                if (deletou)
                {
                    TempData["MensagemSucesso"] = "Cadastro de cliente excluído com sucesso";
                    
                }
                else
                {
                    TempData["MensagemErro"] = "Falha ao excluir cadastro de cliente";
                }

                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Falha ao excluir cadastro de cliente, erro: {erro.Message}";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Cadastrar(ClienteModel cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _clienteRepositorio.Adicionar(cliente);
                    TempData["MensagemSucesso"] = "Cliente cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(cliente);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Falha ao cadastrar o cliente, erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Editar(ClienteModel cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _clienteRepositorio.Atualizar(cliente);
                    TempData["MensagemSucesso"] = "Informações atualizadas com sucesso!";
                    return RedirectToAction("Index");
                }

                return View("Editar", cliente);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Falha ao atualizar informações, erro: {erro.Message}";
                return RedirectToAction("Editar", cliente);
            }


        }
    }
}
