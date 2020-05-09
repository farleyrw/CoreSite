using CoreSite.Base.Interfaces;
using CoreSite.Logic.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreSite.Logic.Interfaces
{
	public interface ILogicContext : IContext
    {
		DbSet<Stuff> Stuffs { get; set; }
    }
}