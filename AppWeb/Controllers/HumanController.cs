using System;
using AppWeb.DataBase;
using AppWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace AppWeb.Controllers
{
	public class HumanController : Controller
	{
		private readonly DB _context;
		public HumanController(DB DataBase)
		{
			_context = DataBase;

		}
		[HttpGet]
		public ActionResult Read()
		{
			if(_context.human.IsNullOrEmpty())
			{
				var list=new List<Humans>();
				return View(list);
			}
			else
			{
				return View(_context.human.ToList());

			}

		}
		[HttpPost]
		public ActionResult Delete(int Id,int Year,string Name)
		{
			var human = _context.human.Find(Id);
			_context.human.Remove(human);
			_context.SaveChanges();
			return RedirectToAction("Read");

		}
		public ActionResult Create(int Id,string Name,int Year)
		{
			Humans humans = new Humans();
			humans.Name = Name;
			humans.Year = Year;
			_context.Add(humans);
			_context.SaveChanges();
			return RedirectToAction("Read");

		}
		[HttpPost]
		public ActionResult Edit(string Name, int Id,int Year)
		{
			var humans = _context.human.Find(Id);
			humans.Name=Name;
			humans.Id = Id;
			humans.Year=Year;
			_context.human.Update(humans);
			_context.SaveChanges();
			return RedirectToAction("Read");


		}

	}
}

