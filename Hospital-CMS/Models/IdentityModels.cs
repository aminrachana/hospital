using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Hospital_CMS.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        // add doctor entity in our system

        public DbSet<Doctor> Doctors { get; set; }

        // Add Patient entity in our system

        public DbSet<Patient> Patients { get; set; }

        //add specilization entity in our system

        public DbSet<Specilization> Specilization { get; set; }

        //add Room entity to our system
        public DbSet<Room> Rooms { get; set; }


        //add Appointment entity to our system
        public DbSet<Appointment> Appointments { get; set; }

        //add Discharge entity to our system
        public DbSet<Discharge> Discharges { get; set; }



        public DbSet<Department> Departments { get; set; }

        public DbSet<Donor> Donors { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}