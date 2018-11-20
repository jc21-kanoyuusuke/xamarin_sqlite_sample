using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SQLiteSample
{
    class MoneyItem
    {
        [PrimaryKey, AutoIncrement]

        public int ID { get; set; }

        public DateTime Created { get; set; }

        public string Name { get; set; }

        public string Notes { get; set; }

        public bool Done { get; set; }

        public int Count { get; set; }
    }
}
