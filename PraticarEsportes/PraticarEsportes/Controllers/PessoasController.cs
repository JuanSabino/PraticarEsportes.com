﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PraticarEsportes.Models;
using PraticarEsportes.Repositories;

namespace PraticarEsportes.Controllers
{
    public class PessoasController : Controller
    {
        private Context db = new Context();

        // GET: Pessoas
        public ActionResult Index()
        {
            return View(db.Pessoas.ToList());
        }

        // GET: Pessoas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = db.Pessoas.Find(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // GET: Pessoas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pessoas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ViewModelPessoas ViewModelPessoas, string tipoPessoa)
        {
            if (String.IsNullOrEmpty(ViewModelPessoas.Email))
            {
                ModelState.AddModelError(string.Empty, "Preencha o e-mail");
                return View(ViewModelPessoas);
            }

            var query = (from u in db.Pessoas
                         where u.Email == ViewModelPessoas.Email 
                         select u).SingleOrDefault();
            if (query != null)
            {
                ModelState.AddModelError(string.Empty, "Email informado já cadastrado!");
                return View(ViewModelPessoas);
            }           

            query = null;

            if(String.IsNullOrEmpty(ViewModelPessoas.Endereco))
            {
                ModelState.AddModelError(string.Empty, "Preencha o endereço");
                return View(ViewModelPessoas);
            }

            if (String.IsNullOrEmpty(ViewModelPessoas.Cidade))
            {
                ModelState.AddModelError(string.Empty, "Preencha a cidade");
                return View(ViewModelPessoas);
            }

            if (String.IsNullOrEmpty(ViewModelPessoas.Estado))
            {
                ModelState.AddModelError(string.Empty, "Preencha o estado");
                return View(ViewModelPessoas);
            }

            if (String.IsNullOrEmpty(ViewModelPessoas.Senha))
            {
                ModelState.AddModelError(string.Empty, "Preencha a senha");
                return View(ViewModelPessoas);
            }

            if (String.IsNullOrEmpty(ViewModelPessoas.ConfirmarSenha))
            {
                ModelState.AddModelError(string.Empty, "Preencha o confirmar senha");
                return View(ViewModelPessoas);
            }

            if(ViewModelPessoas.Senha != ViewModelPessoas.ConfirmarSenha)
            {
                ModelState.AddModelError(string.Empty, "Senha e confirmar senha são diferentes");
                return View(ViewModelPessoas);
            }

            //if (ModelState.IsValid)
            //{
            if (!Funcoes.ValidaCep(ViewModelPessoas.CEP))
            {
                ModelState.AddModelError(string.Empty, "Formato de CEP inválido!");
                return View(ViewModelPessoas);
            }

            if (String.IsNullOrEmpty(ViewModelPessoas.CEP))
            {
                ModelState.AddModelError(string.Empty, "Preencha o CEP");
                return View(ViewModelPessoas);
            }

            if (tipoPessoa == "pessoaFisica")
            {
                if (String.IsNullOrEmpty(ViewModelPessoas.Nome))
                {
                    ModelState.AddModelError(string.Empty, "Preencha o nome");
                    return View(ViewModelPessoas);
                }

                if (String.IsNullOrEmpty(ViewModelPessoas.CPF))
                {
                    ModelState.AddModelError(string.Empty, "Preencha o CPF");
                    return View(ViewModelPessoas);
                }

                query = (from u in db.Pessoas.OfType<Praticante>()
                         where u.CPF == ViewModelPessoas.CPF
                         select u).SingleOrDefault();
                if (query != null)
                {
                    ModelState.AddModelError(string.Empty, "CPF informado já cadastrado!");
                    return View(ViewModelPessoas);
                }
                if (!Funcoes.ValidaCPF(ViewModelPessoas.CPF))
                {
                    ModelState.AddModelError(string.Empty, "Formato de CPF inválido!");
                    return View(ViewModelPessoas);
                }
                var praticante = new Praticante
                {
                    Telefone = ViewModelPessoas.Telefone,
                    Endereco = ViewModelPessoas.Endereco,
                    CEP = ViewModelPessoas.CEP,
                    Cidade = ViewModelPessoas.Cidade,
                    Estado = ViewModelPessoas.Estado,
                    Email = ViewModelPessoas.Email,
                    Senha = ViewModelPessoas.Senha,
                    ConfirmarSenha = ViewModelPessoas.ConfirmarSenha,
                    DataNascimento = ViewModelPessoas.DataNascimento,
                    Habilitado = true,
                    Nome = ViewModelPessoas.Nome,
                    CPF = ViewModelPessoas.CPF,
                    Profissao = ViewModelPessoas.Profissao,
                    EstadoCivil = ViewModelPessoas.EstadoCivil,
                    Pontos = 0
                };

                db.Pessoas.Add(praticante);
                db.SaveChanges();
                Session["Cadastro"] = "1";
            }

            else if (tipoPessoa == "pessoaJuridica")
            {
                if (String.IsNullOrEmpty(ViewModelPessoas.NomeFantasia))
                {
                    ModelState.AddModelError(string.Empty, "Preencha o nome fantasia");
                    return View(ViewModelPessoas);
                }

                if (String.IsNullOrEmpty(ViewModelPessoas.RazaoSocial))
                {
                    ModelState.AddModelError(string.Empty, "Preencha a razão social");
                    return View(ViewModelPessoas);
                }

                if (String.IsNullOrEmpty(ViewModelPessoas.TelComercial))
                {
                    ModelState.AddModelError(string.Empty, "Preencha o telefone comercial");
                    return View(ViewModelPessoas);
                }

                if (String.IsNullOrEmpty(ViewModelPessoas.CNPJ))
                {
                    ModelState.AddModelError(string.Empty, "Preencha o CNPJ");
                    return View(ViewModelPessoas);
                }

                query = (from u in db.Pessoas.OfType<Estabelecimento>()
                         where u.CNPJ == ViewModelPessoas.CNPJ
                         select u).SingleOrDefault();
                if (query != null)
                {
                    ModelState.AddModelError(string.Empty, "CNPJ informado já cadastrado!");
                    return View(ViewModelPessoas);
                }
                if (!Funcoes.ValidaCNPJ(ViewModelPessoas.CNPJ))
                {
                    ModelState.AddModelError(string.Empty, "Formato de CNPJ inválido!");
                    return View(ViewModelPessoas);
                }
                var estabelecimento = new Estabelecimento
                {
                    Telefone = ViewModelPessoas.Telefone,
                    Endereco = ViewModelPessoas.Endereco,
                    CEP = ViewModelPessoas.CEP,
                    Cidade = ViewModelPessoas.Cidade,
                    Estado = ViewModelPessoas.Estado,
                    Email = ViewModelPessoas.Email,
                    Senha = ViewModelPessoas.Senha,
                    ConfirmarSenha = ViewModelPessoas.ConfirmarSenha,
                    Habilitado = false,
                    NomeFantasia = ViewModelPessoas.NomeFantasia,
                    RazaoSocial = ViewModelPessoas.RazaoSocial,
                    CNPJ = ViewModelPessoas.CNPJ,
                    TelComercial = ViewModelPessoas.TelComercial,
                    DataAbertura = ViewModelPessoas.DataAbertura
                };
                Session["Cadastro"] = "2";
                db.Pessoas.Add(estabelecimento);
                db.SaveChanges();
            }

            else
            {
                ViewBag.Error = "Selecione um tipo de usuário!";
                return View(ViewModelPessoas);
            }
            return RedirectToAction("Logar", "Publico");

            //}
            //return View(ViewModelPessoas);
        }

        // GET: Pessoas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = db.Pessoas.Find(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // POST: Pessoas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PessoaId,Telefone,Endereco,CEP,Cidade,Estado,Habilitado")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pessoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pessoa);
        }

        // GET: Pessoas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = db.Pessoas.Find(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // POST: Pessoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pessoa pessoa = db.Pessoas.Find(id);
            db.Pessoas.Remove(pessoa);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

      



    }
}
