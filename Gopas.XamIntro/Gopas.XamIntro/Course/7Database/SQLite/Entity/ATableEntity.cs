using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gopas.XamIntro.Course._7Database.SQLite.Entity
{
    public abstract class ATableEntity
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
    }
}
