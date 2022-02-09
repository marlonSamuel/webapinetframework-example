namespace WEBAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using WEBAPI.Models.dtos;

    public partial class people
    {
        public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

        public List<PeopleDto> GetAll()
        {
            var peoples = new List<PeopleDto>();
            using(var _db = new DB())
            {
                peoples = _db.people.Select(x =>new PeopleDto { id = x.id, nombre = x.name }).ToList();
            }

            return peoples;
        }

        public bool CreatePeople(PeopleDto model)
        {
            var _people = new people()
            {
                name = model.nombre
            };

            using (var _db = new DB())
            {
                var r1 = _db.people.Add(_people);
                var r2 = _db.SaveChanges();
            }

            return true;
        }

        public people Get(int id)
        {
            var people = new people();

            using (var db = new DB())
            {
                people = db.people.Where(x => x.id == id).FirstOrDefault();
            }

            return people;
        }

        public bool Update(int id, PeopleDto model)
        {
            var res = true;

            using(var _db = new DB())
            {
                var people_ant = _db.people.Where(x => x.id == id).FirstOrDefault();
                people_ant.name = model.nombre;
                _db.SaveChanges();
            }

            return res;
        }

        public bool Remove(int id)
        {
            var res = true;

            using (var _db = new DB())
            {
                var people_ant = _db.people.Where(x => x.id == id).First();
                _db.people.Remove(people_ant);
                _db.SaveChanges();
            }

            return res;
        }
    }
}
