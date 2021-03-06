﻿
using CBU2SINIFPROJE.Core.Enums;
using CBU2SINIFPROJE.Core.ViewModels;
using CBU2SINIFPROJE.ViewModels.Adress;

namespace CBU2SINIFPROJE.ViewModels.Actor
{
    public class ActorAddModel:IViewModel
    {
        public ActorAddModel()
        {
            Adress = new AdressModel();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Salary { get; set; }
        public AdressModel Adress { get; set; }
        public Field Field { get; set; }
    }
}
