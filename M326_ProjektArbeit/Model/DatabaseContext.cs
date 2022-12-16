using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M326_ProjektArbeit.Model
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("name=M326ConnectionString")
        {

        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Competence> Competences { get; set; }
        public DbSet<CompetenceGrid> CompetenceGrids { get; set; }
        public DbSet<CompetenceGridCompentence> CompetenceGridCompetences { get; set; }
    }
}
