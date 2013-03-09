namespace Noliktava2.Migrations
{
    using Noliktava2.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    using WebMatrix.WebData;

    internal sealed class Configuration : DbMigrationsConfiguration<Noliktava2.Models.NoliktavaDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Noliktava2.Models.NoliktavaDataContext db)
        {
            //  This method will be called after migrating to the latest version.

            WebSecurity.InitializeDatabaseConnection("DefaultConnection",
                    "UserProfile", "UserId", "UserName", autoCreateTables: true);

            var roles = (SimpleRoleProvider)Roles.Provider;
            var membership = (SimpleMembershipProvider)Membership.Provider;

            if (!roles.RoleExists("VAD"))
            {
                roles.CreateRole("VAD");
            }
            if (!roles.RoleExists("TIR"))
            {
                roles.CreateRole("TIR");
            }
            if (!roles.RoleExists("NOL"))
            {
                roles.CreateRole("NOL");
            }

            if (membership.GetUser("admin", false) == null)
            {
                membership.CreateUserAndAccount("admin", "admin");
            }
            if (!roles.GetRolesForUser("admin").Contains("VAD"))
            {
                roles.AddUsersToRoles(new[] { "admin" }, new[] { "VAD" });
            }
            
            
            var positions = new List<PositionModel>()
            {
                { new PositionModel { Code = "VAD", Name = "Vadītājs" }},
                {new PositionModel { Code = "TIR", Name = "Tirdzniecības pārstāvis" }},
                {new PositionModel { Code = "NOL", Name = "Noliktavas darbinieks" }}
            };

            db.Positions.AddOrUpdate(
                  p => p.Code,
                  positions[0],
                  positions[1],
                  positions[2]
                );
            db.Employees.AddOrUpdate(
                  p => p.FirstName,
                  new EmployeeModel { UserName = "admin", FirstName = "Administrators", FromDate = DateTime.Now, Position = positions[0], LastName="ADM" }
                );
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
